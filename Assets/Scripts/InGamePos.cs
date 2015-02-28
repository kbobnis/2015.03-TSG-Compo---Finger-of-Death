using UnityEngine;
using System.Collections;

public class InGamePos : MonoBehaviour {

	public void Set(int x, int y, int originalW=0, int originalH=0, Pivot p=Pivot.MiddleMiddle){

		int panelTilesW = (int)Game.Me.PanelTiles.GetComponent<RectTransform>().rect.width;
		int panelTilesH = (int)Game.Me.PanelTiles.GetComponent<RectTransform>().rect.height;

		int tileW = panelTilesW/5;
		int tileH = panelTilesH/7;

		int elW = originalW == 0 ? tileW : originalW;
		int elH = originalH == 0 ? tileH : originalH;

		int offsetX = 0;
		int offsetY = 0;
		if (p == Pivot.BottomMiddle) {
			offsetX = tileW / 2 - elW / 2;
			offsetY = - tileH + elH ;
		}

		GetComponent<RectTransform>().offsetMin = new Vector2(-panelTilesW / 2 + tileW * x + offsetX , panelTilesH/2 - tileH *y - elH + offsetY);
		GetComponent<RectTransform>().offsetMax = new Vector2(-panelTilesW / 2 + tileW * x + elW + offsetX, panelTilesH/2 - tileH*y + offsetY);
	}
}

public enum Pivot {
	BottomMiddle, MiddleMiddle
}

