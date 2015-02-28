using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelTiles : MonoBehaviour {

	public GameObject TilePrefab;


	internal void Prepare(List<List<TileTemplate>> tiles) {

		TilePrefab.SetActive(true);

		Debug.Log("Preparing tiles, count: " + tiles.Count);

		float panelTilesW = GetComponent<RectTransform>().rect.width;
		float panelTilesH = GetComponent<RectTransform>().rect.height;

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
