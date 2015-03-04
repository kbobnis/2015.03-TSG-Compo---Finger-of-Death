using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;
	public List<GameObject> People = new List<GameObject>();

	internal void SpawnPeople (List<PersonTemplate> personTemplates){
		foreach (GameObject p in People) {
			Destroy(p);
		}
		People.Clear();

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
		int personW = (int)(personScript.ImageAvatar.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale*3/2f);
		int personH = (int)(personScript.ImageAvatar.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale*3/2f);
		personScript.ImageAvatar.AddComponent<RealSize>().SetSize(personW, personH);
		
		personGameObject.AddComponent<InGamePos>().UpdatePos(positionX, positionY);

		personScript.ImageAvatar.AddComponent<Rigidbody>();
		personScript.ImageAvatar.rigidbody.isKinematic = true;
		personScript.ImageAvatar.rigidbody.useGravity = false;
		personScript.ImageAvatar.AddComponent<BoxCollider>();
		(personScript.ImageAvatar.collider as BoxCollider).size = new Vector3(personW, personH, 16);
		personScript.ImageAvatar.collider.isTrigger = true;
		personScript.ImageAvatar.AddComponent<PlayerCollisionScript>();
		personScript.StartMe();
		switch (charType)
		{
			case Person.CharacterType.Player:
				personScript.SetStats(30, 1, 0.7f, group);
				personScript.ImageCone.SetActive(false);
				(personScript.ImageAvatar.collider as BoxCollider).size = new Vector3(personW/4, personH/4, 16);
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

	public void PersonDied(GameObject personGo){
		foreach (GameObject p in People) {
			p.GetComponent<Person>().ShadeOfCones.Remove(personGo.GetComponent<Person>());
		}
		foreach (GameObject b in Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelBonuses.GetComponent<PanelBonuses>().Bonuses) {
			b.GetComponent<Person>().ShadeOfCones.Remove(personGo.GetComponent<Person>());
		}

		People.Remove(personGo);

	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.I)){
			SpawnPerson(1, 1, Person.CollisionGroup.Enemies, Person.CharacterType.Weak);
		}
	}


}
