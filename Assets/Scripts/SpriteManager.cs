using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour {

	public static Sprite TileEdge, TileCross, TileSide, TileSlant, ArrowUp, ArrowDown;
	private static List<Sprite> People = new List<Sprite>();

	

	static SpriteManager(){
		TileEdge = Resources.Load<Sprite>("Images/tileEdge");
		TileCross = Resources.Load<Sprite>("Images/tileCross");
		TileSide = Resources.Load<Sprite>("Images/tileSide");
		TileSlant = Resources.Load<Sprite>("Images/tileSlant");
		ArrowUp = Resources.Load<Sprite>("Images/arrowUp");
		ArrowDown = Resources.Load<Sprite>("Images/arrowDown");

		People.Add(Resources.Load<Sprite>("Images/person1"));
		People.Add(Resources.Load<Sprite>("Images/person2"));
	}


	internal static Sprite RandomPerson() {
		return People[UnityEngine.Random.Range(0, 2)];

	}
}

