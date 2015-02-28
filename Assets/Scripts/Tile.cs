using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour{

	public GameObject GameObjectImage;
	private TileTemplate template;

	public void Prepare(TileTemplate tt) {
		GameObjectImage.GetComponent<Image>().sprite = tt.TileType.Image;
		template = tt;
		GameObjectImage.transform.Rotate(0, 0, tt.Rotation.Value*90);
	}

	public Direction GetNextDirection(Direction previousDirection){
		template.TileType.Paths.ApplyRotation(template.Rotation);
		return template.TileType.Paths[SwichToThisTileEntrance(previousDirection)];
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
	}
	void Update()
	{
		return;
		switch (template.TileType.Id)
		{
			case "SideUp":
			case "SideDown":
			case "Slant":
				{
					ChangeVersion();
					break;
				}
			case "Cross":
			case "Edge": break;
			default:
				{
					Debug.Log("Undefined type");
					break;
				}
		}
	}

	public void ChangeVersion()
	{
		Debug.Log("Change version");
		switch (template._Version)
		{
			case Version._1:
				{
					GameObjectImage.transform.Rotate(0, 0, 90);
					template._Version = Version._2;
					return;
				}
			case Version._2:
				{
					GameObjectImage.transform.Rotate(0, 0, 90);
					template._Version = Version._1;
					return;
				}
			default:
				{
					Debug.Log("Undefined version");
					return;
				}
		}
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
