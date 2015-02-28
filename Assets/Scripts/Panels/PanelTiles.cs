using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelTiles : MonoBehaviour {

	public GameObject TilePrefab;


	internal void Prepare(List<TileType> tiles) {

		Debug.Log("Preparing tiles, count: " + tiles.Count);

		int panelTilesW = (int)GetComponent<RectTransform>().rect.width;
		int panelTilesH = (int)GetComponent<RectTransform>().rect.height;


		int tileW = panelTilesW/5;
		int tileH = panelTilesH/7;

		int i=0;
		int j = 0;
		foreach (TileType tile in tiles) {

			if (i > 4) {
				j++;
				i = 0;
			}
			Debug.Log("Preparing tile: " + i + ", " + j);

			GameObject tileGameObject = Instantiate(TilePrefab) as GameObject;
			tileGameObject.GetComponent<Tile>().Prepare(tile);
			tileGameObject.name = "Item at " + i + ", " + j;
			tileGameObject.transform.parent = gameObject.transform;

			tileGameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-panelTilesW / 2 + tileW*i, -panelTilesH / 2 + tileH*j);
			tileGameObject.GetComponent<RectTransform>().offsetMax= new Vector2(-panelTilesW / 2 + tileW *(i+1), -panelTilesH / 2 + tileH *(j+1));

			i++;
		}

		TilePrefab.SetActive(false);

	}
}
