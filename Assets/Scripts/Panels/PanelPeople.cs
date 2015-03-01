using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
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
			personGameObject.AddComponent<Person>().Prepare(pt.PositionX, pt.PositionY );
			int personW = (int)(personGameObject.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
			int personH = (int)(personGameObject.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);
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

		SpawnBuff ();

		PersonPrefab.SetActive(false);
	}

public void SpawnBuff (){
		GameObject buffGameObject = Instantiate (PersonPrefab) as GameObject;
		buffGameObject.transform.parent = transform;
		buffGameObject.name = "buff";
		float posX = Random.Range (0, 5)+0.5f;
		float posY = Random.Range (0, 7)+0.5f;

		buffGameObject.AddComponent<Buff> ();
		buffGameObject.GetComponent<Image> ().sprite = SpriteManager.BuffSprite;

		buffGameObject.name = "buff x: "+posX+", y: "+posY;
		int buffW = (int)(buffGameObject.GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
		int buffH = (int)(buffGameObject.GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);
		buffGameObject.AddComponent<RealSize>().SetSize(buffW, buffH);
		buffGameObject.AddComponent<InGamePos>().UpdatePos(posX, posY);
		buffGameObject.AddComponent<Rigidbody>();
		buffGameObject.rigidbody.isKinematic = true;
		buffGameObject.rigidbody.useGravity = false;
		buffGameObject.AddComponent<BoxCollider>();
		(buffGameObject.collider as BoxCollider).size = new Vector3(16, 16, 16);
		buffGameObject.collider.isTrigger = true;
	}
}
