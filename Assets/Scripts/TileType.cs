using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TileType {

	private Sprite _Image;

	public Sprite Image {
		get { return _Image; }
	}

	public static readonly TileType T1 = new TileType(Resources.Load<Sprite>("Images/Tiles/tile1"));
	public static readonly TileType T2 = new TileType(Resources.Load<Sprite>("Images/Tiles/tile2"));


	private TileType(Sprite image) {
		_Image = image;
	}


	internal static TileType GetRandom() {

		int ticket = UnityEngine.Random.Range(0, 2);

		switch (ticket) {
			case 0: return T1;
			case 1: return T2;
			default: throw new Exception("ticket out of range");
		}
	}
}
