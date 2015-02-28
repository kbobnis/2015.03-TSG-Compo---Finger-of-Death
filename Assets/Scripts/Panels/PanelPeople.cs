using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;
	public List<Person> listOfPeople;
	public Text PeopleCountText;

	private int peopleCount;

	internal void SpawnPeople (List<PersonTemplate> personTemplates){

		PersonPrefab.SetActive(true);
		listOfPeople = new List<Person>();
		foreach(PersonTemplate pt in personTemplates){

			GameObject person = Instantiate (PersonPrefab) as GameObject;
			person.transform.parent = transform;
			Person personScript = person.GetComponent<Person>();
			personScript.SetPerson(pt.PositionX, pt.PositionY, Direction.S);
			listOfPeople.Add(personScript);
			person.AddComponent<InGamePos>().Set(pt.PositionX, pt.PositionY);
			person.GetComponent<Person>().StartLife ();
		}

		peopleCount = personTemplates.Count;
		PeopleCountText.text = peopleCount.ToString ();

		PersonPrefab.SetActive(false);
	}

	public void KillPerson (){
		peopleCount--;
		PeopleCountText.text = peopleCount.ToString ();
		if (peopleCount == 0)
			Game.Me.EndGame ();
	}
}
