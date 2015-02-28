using UnityEngine;
using System.Collections;

public class InGamePos : MonoBehaviour {

	public void Set(int x, int y){

		int panelTilesW = (int)Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.width;
		int panelTilesH = (int)Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.height;

		int tileW = panelTilesW/5;
		int tileH = panelTilesH/7;

		GetComponent<RectTransform>().offsetMin = new Vector2(-panelTilesW / 2 + tileW * x, panelTilesH/2 - (tileH *(y+1)));
		GetComponent<RectTransform>().offsetMax = new Vector2(-panelTilesW / 2 + tileW * (x + 1), panelTilesH/2 - tileH*y);
	}
	public static Vector3 GetDestination(int x, int y, Direction direction){
		Vector3 vec = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().ListOfTiles[y][x].GetComponent<RectTransform>().position;
		vec += GetVectorFromDirection(direction);
		return vec;
	}

	private static Vector3 GetVectorFromDirection(Direction d) 
	{
		switch (d)
		{
			case Direction.N:
				return Vector3.up * 32;
			case Direction.S:
				return -Vector3.up * 32;
			case Direction.E:
				return Vector3.right * 32;
			case Direction.W:
				return -Vector3.right * 32;
			default:
				break;
		}
		throw new System.Exception("Direction not recognised:" + d);
	}
}
