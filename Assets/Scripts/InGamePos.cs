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
}
