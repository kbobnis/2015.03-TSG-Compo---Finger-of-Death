using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelMinigame : MonoBehaviour {

	public GameObject PanelTiles;
	public GameObject PanelPeople;
	public GameObject PanelGUI;
	public GameObject PanelBonuses;
	public GameObject PanelEndGame;

	internal void Prepare(List<List<TileTemplate>> tiles, List<PersonTemplate> personTemplates) {
		PanelGUI.GetComponent<PanelGUI>().Reset();
		PanelTiles.GetComponent<PanelTiles>().Prepare(tiles);
		PanelPeople.GetComponent<PanelPeople>().SpawnPeople(personTemplates);
		PanelBonuses.GetComponent<PanelBonuses> ().Prepare ();
	}

	void Update() {
		if (PanelPeople.GetComponent<PanelPeople>().People.Count == 1) {
			EndGame(true);
		}
	}

	public void EndGame(bool won) {

		PanelEndGame.GetComponent<PanelEndGame>().EndGame(PanelGUI.GetComponent<PanelGUI>().Time, PanelGUI.GetComponent<PanelGUI>().Score, won);
		gameObject.SetActive(false);
	}
}
