using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelTiles : MonoBehaviour {

	public GameObject TilePrefab;


	internal void Prepare(List<TileType> tiles) {

		Debug.Log("Preparing tiles, count: " + tiles.Count);

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
			tileGameObject.AddComponent<InGamePos>().Set(i, j);

			i++;
		}

		TilePrefab.SetActive(false);

	}
}
