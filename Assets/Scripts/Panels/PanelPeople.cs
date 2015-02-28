using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;

	internal void SpawnPeople (List<PersonTemplate> personTemplates){

		foreach(PersonTemplate pt in personTemplates){

			GameObject person = Instantiate (PersonPrefab) as GameObject;
			person.GetComponent<Person>().Prepare();
			person.transform.parent = transform;

			int personW = (int)(GetComponent<Image>().sprite.rect.width * Game.Me.GameScale);
			int personH = (int)(GetComponent<Image>().sprite.rect.height * Game.Me.GameScale);

			person.AddComponent<InGamePos>().Set(pt.PositionX, pt.PositionY, personW, personH, Pivot.BottomMiddle );
		}

		PersonPrefab.SetActive(false);
	}
}
