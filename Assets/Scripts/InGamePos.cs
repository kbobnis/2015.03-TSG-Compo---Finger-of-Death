using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGamePos : MonoBehaviour {

	internal void UpdatePos(float x, float y) {
		
		float panelTilesW = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.width;
		float panelTilesH = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.height;

		float tileW = panelTilesW/5f;
		float tileH = panelTilesH/7f;

		GetComponent<RectTransform>().localPosition = new Vector3(tileW * x - panelTilesW / 2, -tileH * y + panelTilesH/2);
	}

	internal Tile GetMyTile(int X, int Y) {
		List<List<Tile>> tiles = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().Tiles;
		if (tiles.Count <= Y || tiles[(int)Y].Count <= X || X < 0 || Y < 0){
			throw new System.Exception("There is no tile of number: " + X + ", " + Y);
		}
		return tiles[(int)Y][(int)X];
	}
}

public enum Pivot {
	TopLeft, MiddleMiddle
}

