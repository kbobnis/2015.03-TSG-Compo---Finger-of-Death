using UnityEngine;
using System.Collections;

public class TileTemplate  {

	public TileType TileType;
	public Rotation Rotation;

	public TileTemplate(TileType tt, Rotation r) {
		TileType = tt;
		Rotation = r;
	}

	internal static TileTemplate FromJsonInt(int id) {
		return new TileTemplate(TileType.FromJsonInt(id), Rotation.FromJsonInt(id));
	}


}
