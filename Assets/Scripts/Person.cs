using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Person : MonoBehaviour
{
	#region PlayerStats
	public int lives = 1;
	public bool isAlive = true;
	public int attackPower = 1;
	int maxLives = 1;
	public float timeToDeath = 60;
	public float speed = 1;
	public float GetSpeed() { return speed + speedMod; }
	public PersonBuff personBuff;
	bool isPowerful = false;
	public int score = 0;

	public void SetStats(int maxLives, int attackPower, float speed, float timeToDeath)
	{
		this.maxLives = maxLives;
		this.lives = maxLives;
		this.attackPower = attackPower;
		this.speed = speed;
		this.timeToDeath = timeToDeath;
	}
	public void PersonStatsUpdate() 
	{
		timeToDeath -= Time.deltaTime;
		if (isAlive && (timeToDeath <= 0 || lives <= 0)) 
		{
			//Death;
			Death();
		}
	}
	void Death() 
	{
		isAlive = false;
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelPeople.GetComponent<PanelPeople>().PersonDied(gameObject);
		Destroy(gameObject);
	}
	#region Buffs
	public List<PersonBuff> buffs;
	float speedMod = 0;
	public void IncreaseSpeed(float value)
	{
		speedMod = value;
	}
	public void AddBuff(PersonBuff buff) 
	{
		lives += buff.deltaLives;
		if (lives > maxLives) 
		{
			score += 10;
		}
		score += buff.deltaScore;
		timeToDeath += buff.deltaTimeToLive;
		if (buff.timer > 0) 
		{
			buffs.Add(buff);
		}
	}
	#endregion
	#endregion
	public float X, Y;
	public Direction StartDir = Direction.S;
	public Direction DestDir;
	public float Progress = 0;
	public CollisionGroup group = CollisionGroup.Enemies;
	public void SetGroup(CollisionGroup value) { group = value; }
	internal void Prepare(int x, int y){
		buffs = new List<PersonBuff>();
		X = x;
		Y = y;
		Sprite s = SpriteManager.RandomPerson();
		GetComponent<Image>().sprite = s;
		gameObject.AddComponent<InGamePos>();
		GetComponent<InGamePos>().UpdatePos(X, Y);
		StartMe();
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().GetTile((int)X, (int)Y).Lock();
	}

	public void StartMe() {
		Tile t = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().GetTile((int)X, (int)Y);
		DestDir = t.GetDestination(StartDir);
		Progress = 0;
	}

	void OnDestroy() {
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().GetTile((int)X, (int)Y).Unlock();
	}

	private void MoveToNext() {
		
		//unlock old tile from changing version
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().GetTile((int)X,(int)Y).Unlock();

		switch (DestDir) {
			case Direction.N: Y--;  break;
			case Direction.E: X++; break;
			case Direction.S: Y++; break;
			case Direction.W: X--; break;
			default:
				throw new System.Exception("Can not move to direction: " + DestDir);
		}

		//lock this tile from changing version
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().GetTile((int)X, (int)Y).Lock();
		StartDir = DestDir.Opposite();
	}

	void Update() {
		Progress += 0.99f * Time.deltaTime * GetSpeed();

		if (Progress >= 1) {
			MoveToNext();
			StartMe();
		}

		Vector2 offset = StartDir.Offset() + (DestDir.Offset() - StartDir.Offset())*Progress;
		if (offset.x < 0) {
			offset.x++;
		}
		if (offset.y < 0) {
			offset.y++;
		}
		GetComponent<InGamePos>().UpdatePos(X + offset.x, Y + offset.y - 0.1f); //-0.1f to make an illusion that he is going on path
		PersonStatsUpdate();
	}

	public enum CollisionGroup
	{
		Player,
		Enemies
	}
	public enum CharacterType 
	{
		Bonus,
		Weak,
		Soldier,
		Boss,
		Player
	}
}
