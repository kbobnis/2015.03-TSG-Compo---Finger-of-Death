using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;
	private List<GameObject> People = new List<GameObject>();

	internal void SpawnPeople (List<PersonTemplate> personTemplates){
		PersonPrefab.SetActive(true);
		foreach(PersonTemplate pt in personTemplates){
			SpawnPerson(pt.PositionX, pt.PositionY, Person.CollisionGroup.Enemies, Person.CharacterType.Weak);
		}
		SpawnPerson(2, 3, Person.CollisionGroup.Player, Person.CharacterType.Player); // PlayerCharacter
		PersonPrefab.SetActive(false);
	}

	private void SpawnPerson(int positionX,int positionY, Person.CollisionGroup group, Person.CharacterType charType)
	{
		GameObject personGameObject = Instantiate(PersonPrefab) as GameObject;
		personGameObject.SetActive(true);
		personGameObject.transform.parent = transform;
		personGameObject.name = "person: " + ", x: " + positionX + ", y: " + positionY;
		Person personScript = personGameObject.AddComponent<Person>();
		personScript.Prepare(positionX, positionY);
		int personW = (int)(personGameObject.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
		int personH = (int)(personGameObject.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);
		personGameObject.AddComponent<RealSize>().SetSize(personW, personH);
		personGameObject.AddComponent<Rigidbody>();
		personGameObject.rigidbody.isKinematic = true;
		personGameObject.rigidbody.useGravity = false;
		personGameObject.AddComponent<BoxCollider>();
		(personGameObject.collider as BoxCollider).size = new Vector3(16, 16, 16);
		personGameObject.collider.isTrigger = true;
		personScript.StartMe();
		personScript.SetGroup(group);
		switch (charType)
		{
			case Person.CharacterType.Player:
				personScript.SetStats(3, 1, 1.5f, 60);
				personGameObject.AddComponent<PlayerCollisionScript>();
				personGameObject.GetComponent<Image>().color = Color.red; //ForDEBUG
				personScript.personBuff = new PersonBuff(0,0,0,0,false,0);
				break;
			case Person.CharacterType.Weak:
				personScript.SetStats(1, 0, 1, 999999);
				personScript.personBuff = new PersonBuff(0,2,5,0,false,0);
				break;
			case Person.CharacterType.Bonus:
				personScript.SetStats(1, 0, 0, 999999);
				personScript.personBuff = new PersonBuff(0,0,0,0,false,0);
				break;
			case Person.CharacterType.Soldier:
				personScript.SetStats(1, 1, 1, 999999);
				personScript.personBuff = new PersonBuff(0,5,10,0,false,0);
				break;
			case Person.CharacterType.Boss:
				personScript.SetStats(1, 3, 1, 999999);
				personScript.personBuff = new PersonBuff(0,5,20,0,false,0);
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
	public bool CheckPeoplePos (Tile t){
		int x = 0, y = 0;

		foreach (List<Tile> tileRow in Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().Tiles) {
			if(tileRow.Contains (t)){
				x = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().Tiles.IndexOf (tileRow);
				y = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().Tiles[x].IndexOf(t);
				break;
			}
		}

		foreach (GameObject person in People) {
			if (person.GetComponent<Person> ().X == y &&
				person.GetComponent<Person> ().Y == x )
				return false;
		}
		return true;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.I))
		{
			SpawnPerson(1, 1, Person.CollisionGroup.Enemies, Person.CharacterType.Weak);
		}
		//foreach()
		//check collisions
	}

}
