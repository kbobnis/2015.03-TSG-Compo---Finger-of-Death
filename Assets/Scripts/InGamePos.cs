using UnityEngine;
using System.Collections;

public class InGamePos : MonoBehaviour {

	public void Set(float x, float y, int originalW=0, int originalH=0, Pivot p=Pivot.MiddleMiddle){
		float panelTilesW = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.width;
		float panelTilesH = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.height;

		float tileW = panelTilesW/5f;
		float tileH = panelTilesH/7f;

		float elW = originalW == 0 ? tileW : originalW;
		float elH = originalH == 0 ? tileH : originalH;

		float offsetX = 0;
		float offsetY = 0;
		if (p == Pivot.TopLeft) {
			offsetX = - (tileW / 2 - elW / 2) - elW/2;
			offsetY =  + (tileH/2 - elH/2)  + elH/2;
		}

		float offsetMinX = -panelTilesW / 2 +(tileW/2-elW/2) + tileW * x +offsetX ;
		float offsetMinY = panelTilesH / 2 - tileH * y - elH + offsetY -(tileH/2-elH/2);
		GetComponent<RectTransform>().offsetMin = new Vector2(offsetMinX, offsetMinY);
		float offsetMaxX = -panelTilesW / 2 + tileW * x + elW + offsetX + (tileW/2-elW/2);
		float offsetMaxY = panelTilesH / 2 - tileH * y + offsetY - (tileH/2-elH/2);
		GetComponent<RectTransform>().offsetMax = new Vector2(offsetMaxX, offsetMaxY);
	}
}

public enum Pivot {
	TopLeft, MiddleMiddle
}

