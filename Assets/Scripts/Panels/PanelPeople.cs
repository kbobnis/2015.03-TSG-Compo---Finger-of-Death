using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;

	internal void SpawnPeople (){
		GameObject[] people = new GameObject[4];

		for (int i=0; i<4; i++) {
			people [i] = Instantiate (PersonPrefab) as GameObject;
			people [i].transform.parent = transform;
		}

		people [0].GetComponent<InGamePos> ().Set (0, 0);
		people [1].GetComponent<InGamePos> ().Set (4, 0);
		people [2].GetComponent<InGamePos> ().Set (0, 6);
		people [3].GetComponent<InGamePos> ().Set (4, 6);
	}
}
