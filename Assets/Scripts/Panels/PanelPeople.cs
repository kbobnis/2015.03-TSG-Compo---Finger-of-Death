using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;
	public Text PeopleCountText;

	private int peopleCount;

	internal void SpawnPeople (List<PersonTemplate> personTemplates){

		PersonPrefab.SetActive(true);

		foreach(PersonTemplate pt in personTemplates){

			GameObject person = Instantiate (PersonPrefab) as GameObject;
			person.GetComponent<Person>().Prepare();
			person.transform.parent = transform;

			int personW = (int)(GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
			int personH = (int)(GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);

			person.AddComponent<InGamePos>().Set(pt.PositionX, pt.PositionY, personW, personH, Pivot.BottomMiddle );
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
