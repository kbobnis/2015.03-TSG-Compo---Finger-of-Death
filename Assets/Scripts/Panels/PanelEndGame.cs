using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelEndGame : MonoBehaviour {
	public Text score;
	public Text time;

	public void UpdateEndGameText() 
	{
		gameObject.SetActive(true);
		score.text = "Score:" + PanelMinigame.score.ToString("0");
		time.text = "Time:" + PanelGUI.seconds.ToString("0");
	}
}
