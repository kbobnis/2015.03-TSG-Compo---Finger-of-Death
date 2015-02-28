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

		List<List<TileTemplate>> tiles = new List<List<TileTemplate>>();
		for (int y = 0; y < height; y++){
			List<TileTemplate> thisRow = new List<TileTemplate>();
			for (int x = 0; x < width; x++){

				int id = N["layers"][0]["data"][y * width + x].AsInt;

				TileTemplate tt = TileTemplate.FromJsonInt(id);
				thisRow.Add(tt);
			}
			tiles.Add(thisRow);
		}
		return tiles;
	}

	public static List<PersonTemplate> LoadPeopleFromJson(string jsonString) {
		List<PersonTemplate> personTemplates = new List<PersonTemplate>();
		var N = JSONNode.Parse(jsonString);
		int height = N["layers"][0]["height"].AsInt;
		int width = N["layers"][0]["width"].AsInt;

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				int id = N["layers"][1]["data"][y * width + x].AsInt;
				if (id > 0) {
					personTemplates.Add(new PersonTemplate(x, y));
				}
			}
		}
		return personTemplates;
	}
	
}
