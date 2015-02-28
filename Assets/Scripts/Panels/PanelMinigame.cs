using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelMinigame : MonoBehaviour {

	public GameObject PanelTiles;
	public GameObject PanelPeople;


	internal void Prepare(List<List<TileTemplate>> tiles) {

		PanelTiles.GetComponent<PanelTiles>().Prepare(tiles);
		PanelPeople.GetComponent<PanelPeople>().SpawnPeople();
	}
}
