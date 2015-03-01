using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelMinigame : MonoBehaviour {

	public GameObject PanelTiles;
	public GameObject PanelPeople;
	public GameObject PanelGUI;
	public GameObject PanelBonuses;

	public static int score = 0;
	internal void Prepare(List<List<TileTemplate>> tiles, List<PersonTemplate> personTemplates) {
		score = 0;
		PanelGUI.GetComponent<PanelGUI>().ResetTimer();
		PanelTiles.GetComponent<PanelTiles>().Prepare(tiles);
		PanelPeople.GetComponent<PanelPeople>().SpawnPeople(personTemplates);
		PanelBonuses.GetComponent<PanelBonuses> ().Prepare ();
	}

	internal static void IncreaseScore(int p){
		score += p;
	}
}
