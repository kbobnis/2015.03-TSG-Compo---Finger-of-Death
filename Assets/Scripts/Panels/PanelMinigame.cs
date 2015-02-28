using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelMinigame : MonoBehaviour {

	public GameObject PanelTiles;

	internal void Prepare(List<TileType> tiles) {

		PanelTiles.GetComponent<PanelTiles>().Prepare(tiles);


	}
}
