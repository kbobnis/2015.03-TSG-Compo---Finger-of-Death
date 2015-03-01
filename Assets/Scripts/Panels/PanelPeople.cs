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
		int i=0;
		foreach(PersonTemplate pt in personTemplates){

			GameObject personGameObject = Instantiate (PersonPrefab) as GameObject;
			personGameObject.transform.parent = transform;
			personGameObject.name = "person: " + i++ + ", x: " + pt.PositionX + ", y: " + pt.PositionY;
			personGameObject.AddComponent<Person>().Prepare(pt.PositionX, pt.PositionY );
			int personW = (int)(personGameObject.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
			int personH = (int)(personGameObject.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);
			personGameObject.AddComponent<RealSize>().SetSize(personW, personH);
			personGameObject.GetComponent<Person>().StartMe();
			People.Add(personGameObject);
		}

		PersonPrefab.SetActive(false);
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
		 
		//foreach()
		//check collisions
	}

}
