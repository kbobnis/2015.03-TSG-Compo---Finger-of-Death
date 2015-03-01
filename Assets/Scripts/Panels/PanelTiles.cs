using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelTiles : MonoBehaviour {

	public GameObject TilePrefab;
	public List<List<Tile>> Tiles;

	internal void Prepare(List<List<TileTemplate>> tiles) {

		TilePrefab.SetActive(true);

		Debug.Log("Preparing tiles, count: " + tiles.Count);

		float panelTilesW = GetComponent<RectTransform>().rect.width;
		float panelTilesH = GetComponent<RectTransform>().rect.height;

		float tileW = panelTilesH / tiles.Count;
		float tileH = panelTilesW / tiles[0].Count;
		Tiles = new List<List<Tile>>();

		for(int x=0; x < tiles.Count; x++){
			List<Tile> lineOfTiles = new List<Tile>();
			for(int y=0; y< tiles[x].Count; y++){

				GameObject tileGameObject = Instantiate(TilePrefab) as GameObject;
				lineOfTiles.Add(tileGameObject.GetComponent<Tile>());
				tileGameObject.GetComponent<Tile>().Prepare(tiles[x][y]);
				tileGameObject.name = "Item " + tiles[x][y].TileType.Id + " at " + x + ", " + y + " rot: " + tiles[x][y].Rotation.Value;
				tileGameObject.transform.parent = gameObject.transform;
				tileGameObject.AddComponent<RealSize>().SetSize(tileW, tileH);
				tileGameObject.AddComponent<InGamePos>().UpdatePos(y+0.5f, x+0.5f);
			}
			Tiles.Add(lineOfTiles);
		};
		TilePrefab.SetActive(false);
	}
}
