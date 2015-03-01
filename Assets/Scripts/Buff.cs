using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buff : MonoBehaviour {
	
	public float Time;
	public float DeltaLife;
	public float DeltaSpeed;
	public int DeltaPoints;
	public bool Undestructable;


	public void GainBuff (){
		Debug.Log ("Gain: time: " + Time + ", life: " + DeltaLife + ", speed: " + DeltaSpeed + ", points: " + DeltaPoints + ", immortality: " + Undestructable);
		Destroy (gameObject);
	}
}