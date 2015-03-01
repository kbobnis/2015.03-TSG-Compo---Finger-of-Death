using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;
	private List<GameObject> People = new List<GameObject>();

	internal void SpawnPeople (List<PersonTemplate> personTemplates){
		
		PersonPrefab.SetActive(true);
		foreach(PersonTemplate pt in personTemplates){
			SpawnPerson(pt.PositionX, pt.PositionY, Person.CollisionGroup.Enemies, Person.CharacterType.Weak);
		}
		SpawnPerson(2, 3, Person.CollisionGroup.Player, Person.CharacterType.Player);

		PersonPrefab.SetActive(false);
	}

	private void SpawnPerson(int positionX,int positionY, Person.CollisionGroup group, Person.CharacterType charType)
	{
		GameObject personGameObject = Instantiate(PersonPrefab) as GameObject;
		personGameObject.SetActive(true);
		personGameObject.transform.parent = transform;
		personGameObject.name = "person: " + ", x: " + positionX + ", y: " + positionY;
		Person personScript = personGameObject.GetComponent<Person>();
		
		personScript.Prepare(positionX, positionY, charType);
		int personW = (int)(personScript.ImageAvatar.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
		int personH = (int)(personScript.ImageAvatar.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);
		personScript.ImageAvatar.AddComponent<RealSize>().SetSize(personW, personH);
		
		personGameObject.AddComponent<InGamePos>().UpdatePos(positionX, positionY);

		personScript.ImageAvatar.AddComponent<Rigidbody>();
		personScript.ImageAvatar.rigidbody.isKinematic = true;
		personScript.ImageAvatar.rigidbody.useGravity = false;
		personScript.ImageAvatar.AddComponent<BoxCollider>();
		(personScript.ImageAvatar.collider as BoxCollider).size = new Vector3(16, 16, 16);
		personScript.ImageAvatar.collider.isTrigger = true;
		personScript.ImageAvatar.AddComponent<PlayerCollisionScript>().SetOwner(personScript);
		personScript.StartMe();
		switch (charType)
		{
			case Person.CharacterType.Player:
				personScript.SetStats(30, 1, 0.7f, group);
				personScript.ImageCone.SetActive(false);
				personScript.ImageAvatar.GetComponent<Image>().color = Color.red; //ForDEBUG
				break;
			case Person.CharacterType.Weak:
				personScript.SetStats(1, 1, 0.5f, group);
				personScript.ImageAvatar.AddComponent<TouchToKill>().Prepare();
				personScript.ImageCone.GetComponent<ConeOfVisibility>().Prepare();
				personScript.DirectionListener = personScript.ImageCone.GetComponent<ConeOfVisibility>();

				break;
			case Person.CharacterType.Soldier:
				personScript.SetStats(1, 1, 1, group);
				break;
			case Person.CharacterType.Boss:
				personScript.SetStats(1, 3, 1, group);
				break;
			default:
				break;
		}
		People.Add(personGameObject);
	}
	public void PersonDied(GameObject personGo) 
	{
		foreach (GameObject p in People) {
			p.GetComponent<Person>().ShadeOfCones.Remove(personGo.GetComponent<Person>());
		}
		People.Remove(personGo);

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			SpawnPerson(1, 1, Person.CollisionGroup.Enemies, Person.CharacterType.Weak);
		}
		if (People.Count == 1) {
			Game.Me.EndGame();
		}
	}

	internal void ClearBoard()
	{
		for (int i = 0; i < People.Count; i++)
		{
			Destroy(People[i]);
		}
		People.Clear();
	}
	IEnumerator SpawnBuff()
	{
		while (true)
		{
			GameObject buffGameObject = Instantiate(PersonPrefab) as GameObject;

			buffGameObject.SetActive(true);
			Person p = buffGameObject.GetComponent<Person>();
			buffGameObject.transform.parent = transform;
			buffGameObject.name = "buff";
			float posX = Random.Range(0, 5) + 0.5f;
			float posY = Random.Range(0, 6) + 0.5f;

			p.ImageAvatar.AddComponent<TouchToKill>().Prepare();
			buffGameObject.AddComponent<Buff>();
			p.ImageCone.SetActive(false);
			p.Prepare((int)posX, (int)posY);
			p.SetStats(1, 0, 0, Person.CollisionGroup.Chest);
			p.ImageAvatar.GetComponent<Image>().sprite = SpriteManager.BuffSprite;
			p.ImageAvatar.AddComponent<PlayerCollisionScript>().SetOwner(p);

			buffGameObject.name = "buff x: " + posX + ", y: " + posY;
			int buffW = (int)(p.ImageAvatar.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
			int buffH = (int)(p.ImageAvatar.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);
			buffGameObject.AddComponent<RealSize>().SetSize(buffW, buffH);
			buffGameObject.AddComponent<InGamePos>().UpdatePos(posX, posY);


			p.ImageAvatar.AddComponent<Rigidbody>();
			p.ImageAvatar.rigidbody.isKinematic = true;
			p.ImageAvatar.rigidbody.useGravity = false;
			p.ImageAvatar.AddComponent<BoxCollider>();
			(p.ImageAvatar.collider as BoxCollider).size = new Vector3(16, 16, 16);
			p.ImageAvatar.collider.isTrigger = true;
			yield return new WaitForSeconds(5);
		}
	}
}
