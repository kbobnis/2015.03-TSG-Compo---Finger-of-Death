using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour{

	public GameObject GameObjectImage;


	public void Prepare(TileTemplate tt) {
		GameObjectImage.GetComponent<Image>().sprite = tt.TileType.Image;
		//rotation
		GameObjectImage.transform.Rotate(0, 0, tt.Rotation.Value);
	}

	void Update() {
	}
}
