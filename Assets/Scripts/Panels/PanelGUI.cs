using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelGUI : MonoBehaviour {

	public Text Timer;
	public Text Score;

	private float seconds = 0;

	public void ResetTimer () {
		seconds = 0;
		Timer.text = seconds.ToString ();
		//StartCoroutine(TimeCount());
	}
	void Update() 
	{
		seconds += Time.deltaTime;
		UpdateTimer(seconds);
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
}
