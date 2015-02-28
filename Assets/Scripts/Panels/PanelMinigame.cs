using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelMinigame : MonoBehaviour {

	public GameObject PanelTiles;

	internal void Prepare(List<List<TileTemplate>> tiles) {

		PanelTiles.GetComponent<PanelTiles>().Prepare(tiles);
	}
}
