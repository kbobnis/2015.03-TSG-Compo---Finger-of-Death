using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelMinigame : MonoBehaviour {

	public GameObject PanelTiles;
	public GameObject PanelPeople;
	public GameObject PanelGUI;


	internal void Prepare(List<List<TileTemplate>> tiles, List<PersonTemplate> personTemplates) {

		PanelGUI.GetComponent<PanelGUI>().ResetTimer();
		PanelTiles.GetComponent<PanelTiles>().Prepare(tiles);
		PanelPeople.GetComponent<PanelPeople>().SpawnPeople(personTemplates);
	}
}
