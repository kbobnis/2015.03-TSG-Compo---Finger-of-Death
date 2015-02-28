using UnityEngine;
using System.Collections;
using System.Xml;
using SimpleJSON;
using System.Collections.Generic;

public class MapReader {
	
	public static List<List<TileTemplate>> LoadMapFromJson(string jsonString){
		var N = JSONNode.Parse(jsonString);
		int height = N["layers"][0]["height"].AsInt;
        int width = N["layers"][0]["width"].AsInt;

		Debug.Log("Width: " + width + ", height: " + height);

		List<List<TileTemplate>> tiles = new List<List<TileTemplate>>();
		for (int y = 0; y < height; y++){
			List<TileTemplate> thisRow = new List<TileTemplate>();
			for (int x = 0; x < width; x++){

				int id = N["layers"][0]["data"][y * width + x].AsInt;

				TileTemplate tt = TileTemplate.FromJsonInt(id);
				Debug.Log("reading tile: " + x + ", " + y + ", id: " + tt.TileType.Id + " rot: " + tt.Rotation.Value + ", id: " + id);
				thisRow.Add(tt);
			}
			tiles.Add(thisRow);
		}
		return tiles;
	}
	
}
