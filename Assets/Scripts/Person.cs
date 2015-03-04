using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Person : MonoBehaviour
{
	public GameObject ImageAvatar, ImageCone;

	public int Health = 1;
	public int AttackPower = 1;
	public float Speed;
	public int Points = 0;

	public List<Person> ShadeOfCones = new List<Person>();

	public float X, Y;
	public Direction StartDir = Direction.S;
	public Direction DestDir;
	public float Progress = 0;
	public DirectionListener DirectionListener;
	public CollisionGroup _CollisionGroup = CollisionGroup.Enemies;

	public void SetStats(int health, int attackPower, float speed, CollisionGroup collisionGroup){
		Health = health;
		AttackPower = attackPower;
		Speed = speed + (speed>0?UnityEngine.Random.Range(-0.1f, 0.1f):0);
		_CollisionGroup = collisionGroup;
	}

	internal void Prepare(int x, int y, CharacterType ct=CharacterType.Weak) {
		X = x;
		Y = y;
		Sprite s = SpriteManager.RandomPerson();
		if (ct == CharacterType.Player) {
			s = SpriteManager.Boss;
		}
		ImageAvatar.GetComponent<Image>().sprite = s;
		gameObject.AddComponent<InGamePos>();
		GetComponent<InGamePos>().UpdatePos(X, Y);
		StartMe();
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().GetTile((int)X, (int)Y).Lock();
	}

	public void StartMe() {
		Tile t = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().GetTile((int)X, (int)Y);
		DestDir = t.GetDestination(StartDir);
		Progress = 0;

		if (DirectionListener != null) {
			DirectionListener.DirectionChanged(StartDir, DestDir);
		}
	}

	void OnDestroy() {
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelPeople.GetComponent<PanelPeople>().PersonDied(gameObject);
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelBonuses.GetComponent<PanelBonuses>().Bonuses.Remove(gameObject);
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().GetTile((int)X, (int)Y).Unlock();
	}

	private void MoveToNext() {
		
		//unlock old tile from changing version
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().GetTile((int)X,(int)Y).Unlock();

		switch (DestDir) {
			case Direction.N: Y--; break;
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
		Progress += 0.99f * Time.deltaTime * Speed;

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

		if (Health <= 0) {
			Destroy(gameObject);
		}
		UpdateImage();
	}

	public enum CollisionGroup
	{
		Player,
		Enemies,
		Chest
	}
	public enum CharacterType {
		Weak,
		Soldier,
		Boss,
		Player
	}

	internal void AddBuff(Buff buff) {

		if (buff == null) {
			throw new System.Exception("Adding null buff? Not good");
		}
		Health += buff.DeltaLife;
		Speed += buff.DeltaSpeed;
		Points += buff.DeltaPoints;

	}

	private void UpdateImage() {
		ImageAvatar.GetComponent<Image>().color = _CollisionGroup==CollisionGroup.Player?Color.white:ShadeOfCones.Count > 0 ? Color.red : Color.white;
	}

	internal void SomeoneSeesMe(Person p) {
		ShadeOfCones.Add(p);
		UpdateImage();
	}

	internal void SomeoneDoesntSeeMe(Person p) {
		ShadeOfCones.Remove(p);
		UpdateImage();
	}
}
