using UnityEngine;
using System.Collections;
using System.Xml;
using SimpleJSON;

public class XMLReader : MonoBehaviour {
    public TextAsset xmlFile;
    int[,] mapTiles;
	
    void Start () {
        //TextAsset textAsset = (TextAsset)Resources.Load("MyXMLFile");
        LoadMapFromJson();

        //XmlDocument xmldoc = new XmlDocument();
        //xmldoc.LoadXml(textAsset.text);
	}

    private void LoadMapFromJson()
    {
        var N = JSONNode.Parse(xmlFile.text);
        int height = N["layers"][0]["height"].AsInt;
        int width = N["layers"][0]["width"].AsInt; ; // read those from json;
        Debug.Log("h" + height  + " w" + width);
        mapTiles = new int[width,height];
        string debug_line = "";
        int id = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                mapTiles[x, y] = N["layers"][0]["data"][id].AsInt;
                id++;
                debug_line += mapTiles[x, y] + ",";
                //Debug.Log("mapTile: " + x + " " + y + " Value:" + mapTiles[x, y] );
            }
            debug_line += "\n";
        }
        Debug.Log(debug_line);
    }
	
    public int [,] GetMap()
    {
        return mapTiles;
    }
}
