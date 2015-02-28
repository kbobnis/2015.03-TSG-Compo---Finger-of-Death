using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;

	internal void SpawnPeople (List<PersonTemplate> personTemplates){

		foreach(PersonTemplate pt in personTemplates){

			GameObject person = Instantiate (PersonPrefab) as GameObject;
			person.transform.parent = transform;
			person.AddComponent<InGamePos>().Set(pt.PositionX, pt.PositionY);
		}

		PersonPrefab.SetActive(false);
	}
}
