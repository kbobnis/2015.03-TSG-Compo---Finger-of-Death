using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Person : MonoBehaviour {

	public float X, Y;
	public Direction StartDir = Direction.S;
	public Direction DestDir;
	public float Progress = 0;

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
		Progress += 0.99f * Time.deltaTime;

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
}
