using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelEndGame : MonoBehaviour {
	
	public Text EndGameReason, ScoreCalculation;

	public void EndGame(int time, int score, bool won) 
	{
		gameObject.SetActive(true);
		EndGameReason.GetComponentInChildren<Text>().text = won ? "You have won by killing all the monsters. Congratulations." : "You tried to kill a monster with red color, you lost.";
		int result = score - time + (won ? 10 : 0);
		ScoreCalculation.GetComponentInChildren<Text>().text = "Score " + result + " pt\ncalculation: score (" + score + " pt) - time (" + time + " pt)" + (won ? "+ win (10 pt)" : "") + " = " + result + " pt";
	}
}
