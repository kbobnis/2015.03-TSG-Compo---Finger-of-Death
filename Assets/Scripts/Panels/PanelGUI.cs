using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelGUI : MonoBehaviour {

	public Text Timer;
	public Text Points;
	private float StartGameTime;

	public int Score, Time;

	public void Reset() {
		Score = 0;
		Time = 0;
		StartGameTime = UnityEngine.Time.time;
		UpdateGui();
	}

	void Update() {
		Time = (int)(UnityEngine.Time.time - StartGameTime);
		UpdateGui();
	}

	private void UpdateGui() {
		Points.text = "" + Score;
		Timer.text = "" + Time;
	}

	internal void IncreaseScore(int delta) {
		Score += delta;
		UpdateGui();
	}
}