using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelTiles : MonoBehaviour {

	public GameObject TilePrefab;
	public List<List<Tile>> ListOfTiles;

	internal void Prepare(List<List<TileTemplate>> tiles) {

		TilePrefab.SetActive(true);

		Debug.Log("Preparing tiles, count: " + tiles.Count);

		float panelTilesW = GetComponent<RectTransform>().rect.width;
		float panelTilesH = GetComponent<RectTransform>().rect.height;

		float tileW = tiles.Count;
		float tileH = tiles[0].Count;
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
