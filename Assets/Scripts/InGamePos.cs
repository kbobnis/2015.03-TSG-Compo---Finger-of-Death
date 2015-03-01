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

}

public enum Pivot {
	TopLeft, MiddleMiddle
}

