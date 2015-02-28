using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public GameObject PanelMinigame;

	void Awake() {

		List<List<TileTemplate>> tiles =  MapReader.LoadMapFromJson(Resources.Load<TextAsset>("Maps/testmap").text);


		PanelMinigame.GetComponent<PanelMinigame>().Prepare(tiles);
	}
	
}
