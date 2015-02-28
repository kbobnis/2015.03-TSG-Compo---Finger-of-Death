using UnityEngine;
using System.Collections;

public class InGamePos : MonoBehaviour {

	public void Set(int i, int j){


		int panelTilesW = (int)Game.Me.PanelTiles.GetComponent<RectTransform>().rect.width;
		int panelTilesH = (int)Game.Me.PanelTiles.GetComponent<RectTransform>().rect.height;

		int tileW = panelTilesW/5;
		int tileH = panelTilesH/7;

		GetComponent<RectTransform>().offsetMin = new Vector2(-panelTilesW / 2 + tileW*i, -panelTilesH / 2 + tileH*j);
		GetComponent<RectTransform>().offsetMax= new Vector2(-panelTilesW / 2 + tileW *(i+1), -panelTilesH / 2 + tileH *(j+1));
	}
}
