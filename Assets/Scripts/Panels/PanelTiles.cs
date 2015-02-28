using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelTiles : MonoBehaviour {

	public GameObject TilePrefab;


	internal void Prepare(List<List<TileTemplate>> tiles) {

		Debug.Log("Preparing tiles, count: " + tiles.Count);

		int panelTilesW = (int)GetComponent<RectTransform>().rect.width;
		int panelTilesH = (int)GetComponent<RectTransform>().rect.height;


		int tileW = panelTilesW/5;
		int tileH = panelTilesH/7;

		for(int x=0; x < tiles.Count; x++){
			for(int y=0; y< tiles[x].Count; y++){


			//tileGameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-panelTilesW / 2 + tileW * y, panelTilesH/2 - (tileH *(x+1)));
			//tileGameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-panelTilesW / 2 + tileW * (y + 1), panelTilesH/2 - tileH*x);
			GameObject tileGameObject = Instantiate(TilePrefab) as GameObject;
			tileGameObject.GetComponent<Tile>().Prepare(tiles[x][y]);
			tileGameObject.name = "Item at " + x + ", " + y + " rot: " + tiles[x][y].Rotation.Value;
			tileGameObject.transform.parent = gameObject.transform;
			tileGameObject.AddComponent<InGamePos>().Set(x, y);
			}
		}

		TilePrefab.SetActive(false);

	}
}
