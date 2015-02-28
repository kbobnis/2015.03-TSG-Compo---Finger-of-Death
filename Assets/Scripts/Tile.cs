﻿using System;
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
		return template.TileType.Paths[previousDirection];
	}
	void Update()
	{
		return;
	}

	public void ChangeVersion()
	{
		Debug.Log("Change version on : " + gameObject.name);
		if (template.TileType.AfterChange != null) {
			Debug.Log("Version changing!!!!");
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
