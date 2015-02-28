using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour {

	public static Sprite TileEdge, TileCross, TileSide, TileSlant;

	static SpriteManager(){
		Sprite[] baseTiles = Resources.LoadAll<Sprite>("Maps/Images/baseTiles");
		TileEdge = baseTiles[2];
		TileCross = baseTiles[1];
		TileSide = baseTiles[6];
		TileSlant = baseTiles[10];
	}

}
