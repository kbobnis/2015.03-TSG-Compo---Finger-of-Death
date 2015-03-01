using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

			personGameObject.GetComponent<Person>().Prepare(pt.PositionX, pt.PositionY );
			personGameObject.GetComponent<ConeOfVisibility>().Prepare();

			int personW = (int)(personGameObject.GetComponent<Person>().ImageAvatar.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
			int personH = (int)(personGameObject.GetComponent<Person>().ImageAvatar.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);
			personGameObject.AddComponent<RealSize>().SetSize(personW, personH);
			personGameObject.AddComponent<Rigidbody>();
			personGameObject.rigidbody.isKinematic = true;
			personGameObject.rigidbody.useGravity = false;
			personGameObject.AddComponent<BoxCollider>();
			(personGameObject.collider as BoxCollider).size = new Vector3(16, 16, 16);
			personGameObject.collider.isTrigger = true;
			personGameObject.GetComponent<Person>().StartMe();
			personGameObject.AddComponent<TouchToKill>().Prepare() ;

			People.Add(personGameObject);
		}

		PersonPrefab.SetActive(false);
	}

}
