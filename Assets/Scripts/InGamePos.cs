using UnityEngine;
using System.Collections;

public class InGamePos : MonoBehaviour {

	public void Set(int x, int y, int originalW=0, int originalH=0, Pivot p=Pivot.MiddleMiddle){

		float panelTilesW = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.width;
		float panelTilesH = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.height;

		float tileW = panelTilesW/5f;
		float tileH = panelTilesH/7f;

		float elW = originalW == 0 ? tileW : originalW;
		float elH = originalH == 0 ? tileH : originalH;

		float offsetX = 0;
		float offsetY = 0;
		if (p == Pivot.BottomMiddle) {
			offsetX = tileW / 2 - elW / 2;
			offsetY = - tileH  ;
		}

		GetComponent<RectTransform>().offsetMin = new Vector2(-panelTilesW / 2 + tileW * x + offsetX , panelTilesH/2 - tileH *y - elH + offsetY);
		GetComponent<RectTransform>().offsetMax = new Vector2(-panelTilesW / 2 + tileW * x + elW + offsetX, panelTilesH/2 - tileH*y + offsetY);
	}
}

public enum Pivot {
	BottomMiddle, MiddleMiddle
}

