using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public GameObject PanelMinigame;
	public GameObject PanelMainMenu;

	public static Game Me;

	void Awake() {
		Me = this;


		
	}

	public void StartGame (){
		PanelMainMenu.SetActive (false);
		PanelMinigame.SetActive (true);

		PanelMinigame.GetComponent<PanelMinigame> ().PanelGUI.GetComponent<PanelGUI> ().ResetTimer ();

		List<List<TileTemplate>> tiles =  MapReader.LoadMapFromJson(Resources.Load<TextAsset>("Maps/testmap").text);
		List<PersonTemplate> personTemplates = MapReader.LoadPeopleFromJson(Resources.Load<TextAsset>("Maps/testmap").text);
		
		PanelMinigame.GetComponent<PanelMinigame>().Prepare(tiles, personTemplates);
	}

	public void EndGame (){
		PanelMainMenu.SetActive (true);
		PanelMinigame.SetActive (false);
	}
}
