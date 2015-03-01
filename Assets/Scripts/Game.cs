﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public GameObject PanelMinigame;
	public GameObject PanelMainMenu;

	public static Game Me;

	void Awake() {
		Me = this;

		PanelMinigame.SetActive(false);
		PanelMainMenu.SetActive(true);
	}

	public void StartGameBase() {

		try {
			PanelMinigame.SetActive(true);
			PanelMainMenu.SetActive(false);

			List<List<TileTemplate>> tiles = MapReader.LoadMapFromJson(Resources.Load<TextAsset>("Maps/testmap").text);
			List<PersonTemplate> personTemplates = MapReader.LoadPeopleFromJson(Resources.Load<TextAsset>("Maps/testmap").text);
			PanelMinigame.GetComponent<PanelMinigame>().Prepare(tiles, personTemplates);
		} catch (System.Exception e) {
			Debug.Log("Exception: " + e);
		}
	}

	public void EndGame (){
		PanelMainMenu.SetActive (true);
		PanelMinigame.SetActive (false);
		PanelMinigame.GetComponent<PanelMinigame>().PanelPeople.GetComponent<PanelPeople>().ClearBoard();
	}
}

