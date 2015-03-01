using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public GameObject PanelMinigame;
	public GameObject PanelMainMenu;
	public GameObject PanelEndgame;

	public static Game Me;
	public static bool gameIsRunning = false;
	void Awake() {
		Me = this;

		PanelMinigame.SetActive(false);
		PanelMainMenu.SetActive(true);
		PanelEndgame.SetActive(false);
	}

	public void StartGameBase() {

		try {
			gameIsRunning = true;
			PanelMinigame.SetActive(true);
			PanelMainMenu.SetActive(false);
			PanelEndgame.SetActive(false);
			List<List<TileTemplate>> tiles = MapReader.LoadMapFromJson(Resources.Load<TextAsset>("Maps/testmap").text);
			List<PersonTemplate> personTemplates = MapReader.LoadPeopleFromJson(Resources.Load<TextAsset>("Maps/testmap").text);
			PanelMinigame.GetComponent<PanelMinigame>().Prepare(tiles, personTemplates);
		} catch (System.Exception e) {
			Debug.Log("Exception: " + e);
		}
	}

	public void EndGame (){
		gameIsRunning = false;
		//PanelMainMenu.SetActive (true);
		PanelEndgame.GetComponent<PanelEndGame>().UpdateEndGameText(); 
		PanelMinigame.SetActive (false);
		PanelMinigame.GetComponent<PanelMinigame>().PanelPeople.GetComponent<PanelPeople>().ClearBoard();
		PanelMinigame.GetComponent<PanelMinigame>().PanelBonuses.GetComponent<PanelBonuses>().ClearingBonuses();
		PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().ClearTiles();
	}
}

