using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public GameObject PanelMinigame;
	
	public GameObject PanelTiles;
	public static Game Me;

	void Awake() {
		Me = this;

		List<List<TileTemplate>> tiles =  MapReader.LoadMapFromJson(Resources.Load<TextAsset>("Maps/testmap").text);
		List<PersonTemplate> personTemplates = MapReader.LoadPeopleFromJson(Resources.Load<TextAsset>("Maps/testmap").text);

		PanelMinigame.GetComponent<PanelMinigame>().Prepare(tiles, personTemplates);
		
	}
	
}
