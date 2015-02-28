using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelGUI : MonoBehaviour {

	public Text Timer;

	private int seconds = 0;

	void Start () {
		StartCoroutine ("TimeCount");
	}

	IEnumerator TimeCount (){
		while (true) {
			yield return new WaitForSeconds (1);
			seconds++;
			Timer.text = seconds.ToString ();
		}
	}
}
