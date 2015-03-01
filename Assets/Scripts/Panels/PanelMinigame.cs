using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelMinigame : MonoBehaviour {

	public GameObject PanelTiles;
	public GameObject PanelPeople;
	public GameObject PanelGUI;

	public static int score = 0;
	internal void Prepare(List<List<TileTemplate>> tiles, List<PersonTemplate> personTemplates) {
		score = 0;
		PanelGUI.GetComponent<PanelGUI>().ResetTimer();
		PanelTiles.GetComponent<PanelTiles>().Prepare(tiles);
		PanelPeople.GetComponent<PanelPeople>().SpawnPeople(personTemplates);
	}

	internal static void IncreaseScore(int p){
		score += p;
	}
}
