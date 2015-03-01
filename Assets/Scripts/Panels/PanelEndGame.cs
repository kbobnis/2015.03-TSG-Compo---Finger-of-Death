using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelEndGame : MonoBehaviour {
	public Text score;
	public Text time;

	public void UpdateEndGameText(bool won) 
	{
		gameObject.SetActive(true);
		int result = (int)PanelMinigame.score - (int)PanelGUI.seconds + (won ? 10 : 0);
		score.text = "Points:" + result;
		time.text = "";
	}
}
