using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Person : MonoBehaviour {

	internal void Prepare() {
		Sprite s = SpriteManager.RandomPerson();
		GetComponent<Image>().sprite = s;
	}

		public void StartLife (){
		//StartCoroutine ("LifeTime");
	}

	IEnumerator LifeTime (){
		yield return new WaitForSeconds (10);
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelPeople.GetComponent<PanelPeople>().KillPerson ();
	}
}
