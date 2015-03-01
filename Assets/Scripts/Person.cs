using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Person : MonoBehaviour {

	public GameObject ImageAvatar;

	public float X, Y;
	public Direction StartDir = Direction.S;
	public Direction DestDir;
	public float Progress = 0;
	public DirectionListener DirectionListener;

	internal void Prepare(int x, int y) {
		X = x;
		Y = y;
		Sprite s = SpriteManager.RandomPerson();
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
			Debug.Log("Start dir: " + StartDir + ", dest dir: " + DestDir);
			DirectionListener.DirectionChanged(StartDir, DestDir);
		}
	}

	void OnDestroy() {
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
