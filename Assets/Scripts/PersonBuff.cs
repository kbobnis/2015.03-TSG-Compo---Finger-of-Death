using UnityEngine;
using System.Collections;

public class PersonBuff {
	public int deltaLives = 0;
	public float deltaTimeToLive = 0;
	public int deltaScore = 0;
	public float deltaSpeed = 0;
	public float timer = 0;
	public bool givesIndestructability;


	public PersonBuff(int deltaLives,float deltaTimeToLive, int deltaScore, float deltaSpeed, bool givesIndestructability, int timer) 
	{
		this.deltaLives = deltaLives;
		this.deltaScore = deltaScore;
		this.deltaSpeed = deltaSpeed;
		this.deltaTimeToLive = deltaTimeToLive;
		this.givesIndestructability = givesIndestructability;
		this.timer = timer;
	}
}
