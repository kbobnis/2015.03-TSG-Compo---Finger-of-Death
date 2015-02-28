using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public GameObject PanelMinigame;

	void Awake() {
		List<TileType> tiles = new List<TileType>();

		for (int i = 0; i < 35; i++) {
			tiles.Add(TileType.GetRandom());
		}
		PanelMinigame.GetComponent<PanelMinigame>().Prepare(tiles);
	}
	
}
