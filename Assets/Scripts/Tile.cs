using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour{

	public GameObject GameObjectImage;

	private TileTemplate template;

	public void Prepare(TileTemplate tt) {
		GameObjectImage.GetComponent<Image>().sprite = tt.TileType.Image;
		//rotation
		GameObjectImage.transform.Rotate(0, 0, tt.Rotation.Value);

		template = tt;
	}

	void Update() {
		switch(template.TileType.Id){
			case "Side":
			case "Slant":{
				ChangeVersion ();
				break;
			}
			case "Cross":
			case "Edge": break;
			default:{
				Debug.Log ("Undefined type");
				break;
			}
		}
	}

	void ChangeVersion (){
		switch (template._Version){
			case Version._1: {
				GameObjectImage.transform.Rotate (180,0,0);
				template._Version = Version._2;
				return;
			}
			case Version._2: {
				GameObjectImage.transform.Rotate (180,0,0);
				template._Version = Version._1;
				return;
			}
			default:{
				Debug.Log ("Undefined version");
				return;
			}
		}
	}
}
