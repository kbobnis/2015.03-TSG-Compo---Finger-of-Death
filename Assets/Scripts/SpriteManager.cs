using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour {

	public static Sprite TileEdge, TileCross, TileSide, TileSlantUp, TileSlantDown, ArrowUp, ArrowDown;
	public static Sprite BuffSprite;
	private static List<Sprite> People = new List<Sprite>();
	public static Sprite Boss;

	

	static SpriteManager(){
		TileEdge = Resources.Load<Sprite>("Images/tileEdge");
		TileCross = Resources.Load<Sprite>("Images/tileCross");
		TileSide = Resources.Load<Sprite>("Images/tileSide");
		TileSlantUp = Resources.Load<Sprite>("Images/tileSlant");
		TileSlantDown = Resources.Load<Sprite>("Images/tileSlantDown");
		ArrowUp = Resources.Load<Sprite>("Images/arrowUp");
		ArrowDown = Resources.Load<Sprite>("Images/arrowDown");
		BuffSprite = Resources.Load<Sprite> ("Images/treasure");
		Boss = Resources.Load<Sprite>("Images/boss");


		People.Add(Resources.Load<Sprite>("Images/person1"));
		People.Add(Resources.Load<Sprite>("Images/person2"));
	}


	internal static Sprite RandomPerson() {
		return People[UnityEngine.Random.Range(0, 2)];

	}
}


