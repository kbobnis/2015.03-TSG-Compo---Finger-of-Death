using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelGUI : MonoBehaviour {

	public Text Timer;
	public Text Score;

	private int seconds = 0;

	public void ResetTimer () {
		seconds = 0;
		Timer.text = seconds.ToString ();
	}

	public void UpdateTimer(float seconds) 
	{
		Timer.text = seconds.ToString("0");
	}
	public void UpdateScore(float value)
	{
		Score.text = value.ToString();
	}

	public static PanelGUI GetPanelGUI()
	{
		return Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelGUI.GetComponent<PanelGUI>();
	}
	//IEnumerator TimeCount (){
	//	while (true) {
	//		yield return new WaitForSeconds (1);
	//		seconds++;
	//		Timer.text = seconds.ToString ();
	//	}
	//}
}
