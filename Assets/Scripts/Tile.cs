using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour{

	public GameObject GameObjectImage;
	TileTemplate TileTemplate;
	public void Prepare(TileTemplate tt) {
		GameObjectImage.GetComponent<Image>().sprite = tt.TileType.Image;
		TileTemplate = tt;
		GameObjectImage.transform.Rotate(0, 0, tt.Rotation.Value);
	}

	public Direction GetNextDirection(Direction previousDirection){
		TileTemplate.TileType.Paths.ApplyRotation(TileTemplate.Rotation);
		return TileTemplate.TileType.Paths[SwichToThisTileEntrance(previousDirection)];
	}
	private Direction SwichToThisTileEntrance(Direction previousDir)
	{
		switch (previousDir)
		{
			case Direction.N:
				return Direction.S;
			case Direction.S:
				return Direction.N;
			case Direction.W:
				return Direction.E;
			case Direction.E:
				return Direction.W;
			default:
				break;
		}
		throw new System.Exception("Direction not recognised:" + previousDir);
		//return Direction.S;
	}
	
}

public static class DictionaryExtension
{
	public static Dictionary<Direction, Direction> ApplyRotation(this Dictionary<Direction, Direction> d, Rotation r)
	{
		Dictionary<Direction, Direction> nDic = new Dictionary<Direction,Direction>();
		foreach(Direction oldKey in d.Keys)
		{
			Direction key = oldKey.ApplyRotation(r);//AngleToDirection(IncreaseAngle(DirectionToAngle(oldKey), r));
			Direction value = d[oldKey].ApplyRotation(r);
			nDic.Add(key,value);
		}
		return nDic;
	}
}
