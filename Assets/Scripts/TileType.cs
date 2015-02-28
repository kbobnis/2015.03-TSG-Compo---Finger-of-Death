using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TileType {

	public readonly string Id;
	private Sprite _Image;

	public Sprite Image {
		get { return _Image; }
	}

	public static readonly TileType Edge = new TileType("Edge", SpriteManager.TileEdge);
	public static readonly TileType Cross = new TileType("Cross", SpriteManager.TileCross);
	public static readonly TileType Side = new TileType("Side", SpriteManager.TileSide);
	public static readonly TileType Slant = new TileType("Slant", SpriteManager.TileSlant);

	private TileType(string id, Sprite image) {
		Id = id;
		_Image = image;
	}

	internal static TileType GetRandom() {
		return FromJsonInt(UnityEngine.Random.Range(0, 2));
	}

	internal static TileType FromJsonInt(int p) {
		switch (p) {
			case 2: return Cross;
			case 3: 
			case 4: 
			case 5: 
			case 6: return Edge;
			case 7: 
			case 8: 
			case 9:
			case 10: return Side;
			case 11:
			case 12: return Slant;
			default: throw new Exception("ticket out of range");
		}
	}
}

public class Rotation {

	public static readonly Rotation _0 = new Rotation(0);
	public static readonly Rotation _90 = new Rotation(90);
	public static readonly Rotation _180 = new Rotation(180);
	public static readonly Rotation _270 = new Rotation(270);

	private int _Value;

	public int Value {
		get { return _Value; }
	}

	private Rotation(int r) {
		_Value = r;
	}

	internal static Rotation FromJsonInt(int p) {
		switch (p) {
			case 2:
			case 7: 
			case 11: 
			case 3: return _0;
			case 8: 
			case 12: 
			case 4: return _270;
			case 9: 
			case 5: return _180; 
			case 10: 
			case 6: return Rotation._90;
			default: throw new Exception("ticket out of range");
		}
	}
	
}