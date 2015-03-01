using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buff : MonoBehaviour {

	public float X, Y;
	public float _Time;
	public float DeltaLife;
	public float DeltaSpeed;
	public int DeltaPoints;
	public bool Undestructable;

	internal void Prepare(int x, int y) {
		X = x;
		Y = y;

		Sprite s = Resources.Load<Sprite> ("Images/testBuff");
		GetComponent<Image>().sprite = s;
		gameObject.AddComponent<InGamePos>();
		GetComponent<InGamePos>().UpdatePos(X, Y);

		Debug.Log (X + ", " + Y);
	}

	void OnMouseDown (){
		Debug.Log ("Gain: time: " + _Time + ", life: " + DeltaLife + ", speed: " + DeltaSpeed + ", points: " + DeltaPoints + ", immortality: " + Undestructable);
		Destroy (gameObject);
	}
}