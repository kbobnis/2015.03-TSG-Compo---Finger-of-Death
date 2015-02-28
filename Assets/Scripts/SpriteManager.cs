using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour {

	public static Sprite TileEdge, TileCross, TileSideUp, TileSideDown, TileSlantUp, TileSlantDown;

	static SpriteManager(){
		Sprite[] baseTiles = Resources.LoadAll<Sprite>("Maps/Images/baseTiles");
		TileEdge = baseTiles[2];
		TileCross = baseTiles[1];
		TileSideUp = baseTiles[6];
		TileSideDown = baseTiles[12];
		TileSlantUp = baseTiles[10];
		TileSlantDown = baseTiles[11];
	}

}

