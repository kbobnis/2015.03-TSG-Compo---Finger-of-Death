using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelTiles : MonoBehaviour {

	public GameObject TilePrefab;
	public List<List<Tile>> ListOfTiles;

	internal void Prepare(List<List<TileTemplate>> tiles) {

		Debug.Log("Preparing tiles, count: " + tiles.Count);

		int panelTilesW = (int)GetComponent<RectTransform>().rect.width;
		int panelTilesH = (int)GetComponent<RectTransform>().rect.height;


		int tileW = panelTilesW/5;
		int tileH = panelTilesH/7;
		ListOfTiles = new List<List<Tile>>();
		for(int x=0; x < tiles.Count; x++){
			List<Tile> lineOfTiles = new List<Tile>();
			for(int y=0; y< tiles[x].Count; y++){


			
			GameObject tileGameObject = Instantiate(TilePrefab) as GameObject;
			lineOfTiles.Add(tileGameObject.GetComponent<Tile>());
			tileGameObject.GetComponent<Tile>().Prepare(tiles[x][y]);
			tileGameObject.name = "Item at " + x + ", " + y + " rot: " + tiles[x][y].Rotation.Value;
			tileGameObject.transform.parent = gameObject.transform;
			tileGameObject.GetComponent<InGamePos>().Set(y, x);
			}
			ListOfTiles.Add(lineOfTiles);
		};
		TilePrefab.SetActive(false);

	}
}
