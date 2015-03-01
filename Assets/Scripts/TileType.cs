using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TileType {

	public readonly string Id;
	private Sprite _Image;
	public TileType AfterChange;

	public Sprite Image {
		get { return _Image; }
	}

	public Dictionary<Direction, Direction> Paths;

	public static readonly TileType Edge = new TileType("Edge", SpriteManager.TileEdge, 
		new Dictionary<Direction, Direction> { { Direction.W, Direction.N }, { Direction.N, Direction.W }});
	public static readonly TileType Cross = new TileType("Cross", SpriteManager.TileCross,
		new Dictionary<Direction, Direction> { { Direction.E, Direction.W }, { Direction.W, Direction.E }, { Direction.S, Direction.N }, { Direction.N, Direction.S } });
	public static readonly TileType SideUp = new TileType("SideUp", SpriteManager.TileSide, 
		new Dictionary<Direction, Direction> { { Direction.W, Direction.N }, { Direction.N, Direction.W }, { Direction.S, Direction.W } });
	public static readonly TileType SideDown = new TileType("SideDown", SpriteManager.TileSide,
		new Dictionary<Direction, Direction> { { Direction.W, Direction.S }, { Direction.N, Direction.W }, { Direction.S, Direction.W } });
	public static readonly TileType SlantUp = new TileType("SlantUp", SpriteManager.TileSlant,
		new Dictionary<Direction, Direction> { { Direction.N, Direction.W }, { Direction.W, Direction.N }, { Direction.S, Direction.E }, { Direction.E, Direction.S } });
	public static readonly TileType SlantDown = new TileType("SlantDown", SpriteManager.TileSlant,
		new Dictionary<Direction, Direction> { { Direction.W, Direction.S }, { Direction.S, Direction.W }, { Direction.N, Direction.E }, { Direction.E, Direction.N } });

	static TileType() {
		SideUp.AfterChange = SideDown;
		SideDown.AfterChange = SideUp;
		SlantUp.AfterChange = SlantDown;
		SlantDown.AfterChange = SlantUp;
	}

	private TileType(string id, Sprite image,  Dictionary<Direction, Direction> path) {
		Id = id;
		_Image = image;
		Paths = path;
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
			case 10: return SideUp;
			case 11: return SlantUp;
			case 12: return SlantDown;
			case 13: return SideDown;
			default: throw new Exception("ticket out of range");
		}
	}
	
}
public enum Direction
{
	N,
	S,
	W,
	E
}
public static class DirectionExtension
{
	public static Direction ApplyRotation(this Direction d, Rotation r)
	{
		Direction newDir = d;
		for (int i = 0; i < r.Value; i++)
		{
			newDir = newDir.Rotate();
		}
		return newDir;
	}
	public static Direction Rotate(this Direction d)
	{
		switch (d)
		{
			case Direction.N:
				return Direction.E;
			case Direction.S:
				return Direction.W;
			case Direction.W:
				return Direction.N;
			case Direction.E:
				return Direction.S;
			default:
				throw new Exception("There is no case for direction: " + d);
		}
	}
	public static Vector2 Offset(this Direction d) {
		switch (d) {
			case Direction.N: return new Vector2(0.5f, 0);
			case Direction.E: return new Vector2(1f, 0.5f);
			case Direction.S: return new Vector2(0.5f, 1);
			case Direction.W: return new Vector2(0, 0.5f);
			default:
				throw new Exception("There is no case for direction: " + d);

		}
	}
	public static Direction Opposite(this Direction d) {
		return d.ApplyRotation(Rotation._180);
	}

}

public class Rotation {

	public static readonly Rotation _0 = new Rotation(0);
	public static readonly Rotation _90 = new Rotation(1);
	public static readonly Rotation _180 = new Rotation(2);
	public static readonly Rotation _270 = new Rotation(3);

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
			case 13:
			case 3: return _0;
			case 8: 
			case 12: 
			case 4: return _90;
			case 9: 
			case 5: return _180; 
			case 10: 
			case 6: return Rotation._270;
			default: throw new Exception("ticket out of range");
		}
	}

}