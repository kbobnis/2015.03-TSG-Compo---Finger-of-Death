using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;
	public List<Person> listOfPeople;
	internal void SpawnPeople (List<PersonTemplate> personTemplates){
		listOfPeople = new List<Person>();
		int i = 0;
		foreach(PersonTemplate pt in personTemplates){

			GameObject person = Instantiate (PersonPrefab) as GameObject;
			person.transform.parent = transform;
			Person personScript = person.GetComponent<Person>();
			Debug.Log(i + "  "+pt.PositionX + "  " +pt.PositionY);
			i++;
			personScript.SetPerson(pt.PositionX, pt.PositionY, Direction.S);

			person.GetComponent<InGamePos>().Set(pt.PositionX, pt.PositionY);
			listOfPeople.Add(personScript);
		}

		PersonPrefab.SetActive(false);
	}
}
