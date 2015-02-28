using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour{

	public GameObject GameObjectImage;


	TileType TileType;

	public void Prepare(TileType tt) {
		TileType = tt;
		GameObjectImage.GetComponent<Image>().sprite = TileType.Image;

	}
}
