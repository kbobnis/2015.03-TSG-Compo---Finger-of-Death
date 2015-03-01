using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Person : MonoBehaviour
{
	#region PlayerStats
	float timeToDeath = 60;
	public float speed = 1;
	float speedMod = 1;
	public float GetSpeed() { return speed * speedMod; }
	bool isPowerful = false;
	float lives = 3; float maxLives = 3;
	float points = 0;
	public void OnCollisionFood()
	{
		points += 5;
	}
	public void OnCollisionWarrior()
	{
		points += 10;
		if (!isPowerful)
		{
			lives -= 1;
		}
	}
	public void OnCollisonBoss()
	{
		if (!isPowerful)
		{
			lives -= 3;
		}
		else
		{
			points += 50;
		}
	}
	public void OnCollisionLife()
	{
		points += 5;
		lives += 1;
		if (lives > maxLives)
		{
			lives = maxLives;
			points += 5; // bonus points if character have maxLives
		}
	}
	#region stationaryBuffs
	public void OnCollisionPower()
	{
		isPowerful = true;
		StartCoroutine(DisablePowerBuff());
	}
	IEnumerator DisablePowerBuff()
	{
		float timer = 0;
		do
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		} while (timer <= 5);
		isPowerful = false;
	}

	public void OnCollisionSpeed()
	{
		speedMod = 1.5f;
		StartCoroutine(DisableSpeed());
	}
	IEnumerator DisableSpeed()
	{
		float timer = 0;
		do
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		} while (timer <= 5);
		speedMod = 1;
	}
	public void OnCollisonTime()
	{
		timeToDeath += 15;
	}
	#endregion
	#endregion
	public float X, Y;
	public Direction StartDir = Direction.S;
	public Direction DestDir;
	public float Progress = 0;
	public CollisionGroup group = CollisionGroup.Enemies;
	public void SetGroup(CollisionGroup value) { group = value; }
	public bool CompareGroup(CollisionGroup value) { 
		if (group == value) return true; 
		else return false; 
	}
	internal void Prepare(int x, int y) {
		X = x;
		Y = y;
		Sprite s = SpriteManager.RandomPerson();
		GetComponent<Image>().sprite = s;
		gameObject.AddComponent<InGamePos>();
		GetComponent<InGamePos>().UpdatePos(X, Y);
		StartMe();
	}


	public void StartMe() {
		Tile t = GetComponent<InGamePos>().GetMyTile((int)X, (int)Y);
		DestDir = t.GetDestination(StartDir);
		Progress = 0;
	}

	private void MoveToNext() {
		
		switch (DestDir) {
			case Direction.N: Y--;  break;
			case Direction.E: X++; break;
			case Direction.S: Y++; break;
			case Direction.W: X--; break;
			default:
				throw new System.Exception("Can not move to direction: " + DestDir);
		}
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
	
	}
	public enum CollisionGroup
	{
		Player,
		Enemies
	}
}
