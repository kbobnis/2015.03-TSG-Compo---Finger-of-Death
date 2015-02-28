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


			
			GameObject tileGameObject = Instantiate(TilePrefab) as GameObject;
			tileGameObject.GetComponent<Tile>().Prepare(tiles[x][y]);
			tileGameObject.name = "Item at " + x + ", " + y + " rot: " + tiles[x][y].Rotation.Value;
			tileGameObject.transform.parent = gameObject.transform;
			tileGameObject.AddComponent<InGamePos>().Set(y, x);
			}
		}

		TilePrefab.SetActive(false);

	}
}
