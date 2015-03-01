using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;
	private List<GameObject> People = new List<GameObject>();

	internal void SpawnPeople (List<PersonTemplate> personTemplates){
		
		PersonPrefab.SetActive(true);
		foreach(PersonTemplate pt in personTemplates){
			SpawnPerson(pt.PositionX, pt.PositionY, Person.CollisionGroup.Enemies, Person.CharacterType.Weak);
		}
		SpawnPerson(2, 3, Person.CollisionGroup.Player, Person.CharacterType.Player);

		foreach(GameObject go in People){
			go.GetComponent<Person>().ShadeOfCones = 0;
		}

		PersonPrefab.SetActive(false);
	}

	private void SpawnPerson(int positionX,int positionY, Person.CollisionGroup group, Person.CharacterType charType)
	{
		GameObject personGameObject = Instantiate(PersonPrefab) as GameObject;
		personGameObject.SetActive(true);
		personGameObject.transform.parent = transform;
		personGameObject.name = "person: " + ", x: " + positionX + ", y: " + positionY;
		Person personScript = personGameObject.GetComponent<Person>();
		
		personScript.Prepare(positionX, positionY);
		int personW = (int)(personScript.ImageAvatar.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
		int personH = (int)(personScript.ImageAvatar.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);
		personGameObject.AddComponent<RealSize>().SetSize(personW, personH);
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
				personScript.SetStats(30, 1, 1.5f, group);
				
				personScript.ImageCone.SetActive(false);
				personScript.ImageAvatar.GetComponent<Image>().color = Color.red; //ForDEBUG
				break;
			case Person.CharacterType.Weak:
				personScript.SetStats(1, 1, 1, group);
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
	public void PersonDied(GameObject Person) 
	{
		People.Remove(Person);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			SpawnPerson(1, 1, Person.CollisionGroup.Enemies, Person.CharacterType.Weak);
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
}
