using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelPeople : MonoBehaviour {

	public GameObject PersonPrefab;

	internal void SpawnPeople (List<PersonTemplate> personTemplates){

		PersonPrefab.SetActive(true);
		int i=0;
		float offsetX = 0;
		float offsetY = 0;
		foreach(PersonTemplate pt in personTemplates){

			GameObject personGameObject = Instantiate (PersonPrefab) as GameObject;
			personGameObject.transform.parent = transform;

			float x = pt.PositionX + offsetX;
			float y = pt.PositionY + offsetY; 

			personGameObject.name = "person: " + i++ + ", x: " + x + ", y: " + y;

			personGameObject.AddComponent<Person>().Prepare();
			int personW = (int)(personGameObject.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
			int personH = (int)(personGameObject.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);

			personGameObject.AddComponent<InGamePos>().Set(x, y, personW, personH, Pivot.TopLeft);
		}

		PersonPrefab.SetActive(false);
	}

}
