using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

	public void StartLife (){
		StartCoroutine ("LifeTime");
	}

	IEnumerator LifeTime (){
		yield return new WaitForSeconds (10);
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelPeople.GetComponent<PanelPeople>().KillPerson ();
	}
}
