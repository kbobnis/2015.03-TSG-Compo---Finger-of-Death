using UnityEngine;
using System.Collections;

public class RealSize : MonoBehaviour {

	internal void SetSize(float originalW, float originalH) {
		float panelTilesW = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.width;
		float panelTilesH = Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<RectTransform>().rect.height;

		float tileW = panelTilesW / 5f;
		float tileH = panelTilesH / 7f;

		float elW = originalW == 0 ? tileW : originalW;
		float elH = originalH == 0 ? tileH : originalH;

		float offsetMinX = -panelTilesW / 2 + (tileW / 2 - elW / 2) ;
		float offsetMinY = panelTilesH / 2 - elH  - (tileH / 2 - elH / 2);
		GetComponent<RectTransform>().offsetMin = new Vector2(offsetMinX, offsetMinY);
		float offsetMaxX = -panelTilesW / 2 + elW +  (tileW / 2 - elW / 2);
		float offsetMaxY = panelTilesH / 2 - (tileH / 2 - elH / 2);
		GetComponent<RectTransform>().offsetMax = new Vector2(offsetMaxX, offsetMaxY);
	}
}
