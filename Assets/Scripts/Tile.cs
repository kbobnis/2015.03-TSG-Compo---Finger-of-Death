using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour{

	public GameObject GameObjectImage, GameObjectImageArrow, GameObjectImageBorder;
	private TileTemplate TileTemplate;
	private int ChangeLocked;

	public void Prepare(TileTemplate tt) {
		TileTemplate = tt;
		UpdateImage();
	}

	private void UpdateImage() {
		GameObjectImage.GetComponent<Image>().sprite = TileTemplate.TileType.Image;
		GameObjectImage.transform.rotation = new Quaternion();
		GameObjectImage.transform.Rotate(0, 0, TileTemplate.Rotation.Value * -90);
		
		GameObjectImageBorder.GetComponent<Image>().color = ChangeLocked>0?Color.red:Color.green;
		GameObjectImageBorder.SetActive(false); //TileTemplate.TileType.AfterChange != null);
		
		
		GameObjectImageArrow.SetActive(TileTemplate.TileType.ModificatorImage != null);
		if (TileTemplate.TileType.ModificatorImage != null) {
			GameObjectImageArrow.GetComponent<Image>().sprite = TileTemplate.TileType.ModificatorImage;
			GameObjectImageArrow.transform.rotation = new Quaternion();
			GameObjectImageArrow.transform.Rotate(0, 0, TileTemplate.Rotation.Value * -90);
		}
	}

	public void ChangeVersion(){
		try {
			if (TileTemplate.TileType.AfterChange != null && ChangeLocked == 0) {
				TileTemplate.TileType = TileTemplate.TileType.AfterChange;
				UpdateImage();
			}
		} catch (Exception e) {
			Debug.Log("Exception: " + e);
		}
	}


	internal Direction GetDestination(Direction StartDir) {
		Dictionary<Direction, Direction> path = TileTemplate.TileType.Paths.ApplyRotation(TileTemplate.Rotation);
		if (!path.ContainsKey(StartDir)) {
			throw new Exception("There is no start dir: " + StartDir + " in tile: " + gameObject.name);
		}
		return path[StartDir];
	}

	internal void Unlock() {
		ChangeLocked--;
		UpdateImage();
	}

	internal void Lock() {
		ChangeLocked++;
		UpdateImage();
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
