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
		template = tt;
		UpdateImage();
	}

	private void UpdateImage() {
		GameObjectImage.GetComponent<Image>().sprite = template.TileType.Image;
		GameObjectImage.transform.rotation = new Quaternion();
		GameObjectImage.transform.Rotate(0, 0, template.Rotation.Value * 90);
	}

	public Direction GetNextDirection(Direction previousDirection){
		template.TileType.Paths.ApplyRotation(template.Rotation);
		return template.TileType.Paths[SwichToThisTileEntrance(previousDirection)];
	}

	private Direction SwichToThisTileEntrance(Direction previousDir){
		switch (previousDir){
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

	public void ChangeVersion(){
		if (template.TileType.AfterChange != null) {
			template.TileType = template.TileType.AfterChange;
			UpdateImage();
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
			Direction key = oldKey.ApplyRotation(r);
			Direction value = d[oldKey].ApplyRotation(r);
			nDic.Add(key,value);
		}
		return nDic;
	}
	
}
