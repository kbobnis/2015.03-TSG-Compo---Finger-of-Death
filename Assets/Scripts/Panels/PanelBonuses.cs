using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelBonuses : MonoBehaviour {

	public GameObject PersonPrefab;

	internal void Prepare (){
		StartCoroutine (SpawnBuff ());
	}

	IEnumerator SpawnBuff (){
		while (true) {
			GameObject buffGameObject = Instantiate (PersonPrefab) as GameObject;
			buffGameObject.SetActive (true);
			Person p = buffGameObject.GetComponent<Person> ();
			buffGameObject.transform.parent = transform;
			buffGameObject.name = "buff";
			float posX = Random.Range (0, 5) + 0.5f;
			float posY = Random.Range (0, 6) + 0.5f;
			
			buffGameObject.AddComponent<Buff> ();
			p.ImageCone.SetActive (false);
			p.Prepare ((int)posX, (int)posY);
			p.SetStats (1, 0, 0, Person.CollisionGroup.Chest);
			p.ImageAvatar.GetComponent<Image> ().sprite = SpriteManager.BuffSprite;
			
			buffGameObject.name = "buff x: " + posX + ", y: " + posY;
			int buffW = (int)(p.ImageAvatar.GetComponent<Image> ().sprite.rect.width * AspectRatioKeeper.ActualScale);
			int buffH = (int)(p.ImageAvatar.GetComponent<Image> ().sprite.rect.height * AspectRatioKeeper.ActualScale);
			buffGameObject.AddComponent<RealSize> ().SetSize (buffW, buffH);
			buffGameObject.AddComponent<InGamePos> ().UpdatePos (posX, posY);
			buffGameObject.AddComponent<Rigidbody> ();
			buffGameObject.rigidbody.isKinematic = true;
			buffGameObject.rigidbody.useGravity = false;
			buffGameObject.AddComponent<BoxCollider> ();
			(buffGameObject.collider as BoxCollider).size = new Vector3 (16, 16, 16);
			buffGameObject.collider.isTrigger = true;
			yield return new WaitForSeconds(5);
		}
	}
}
