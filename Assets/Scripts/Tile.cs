using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour{

	public const float ENTRANCE_DETECTION_DISTANCE = 15; //
	public Vector2 mapPosition;
	public GameObject GameObjectImage;
	//public RectTransform[] tileEntrances;
	public EntranceToGoal[] directionsTable;
	public float rotation;
	TileType TileType;

	public void Prepare(TileType tt) {
		TileType = tt;
		GameObjectImage.GetComponent<Image>().sprite = TileType.Image;

	}
	public Vector2 GetNextDirection(Vector2 previousDirection){
		for (int i = 0; i < directionsTable.Length; i++){
			if (previousDirection == AngleToVec(IncreaseAngle(VecToAngle(directionsTable[i].previousDirection)))){
				Debug.Log("xx");
				return AngleToVec(IncreaseAngle(VecToAngle(directionsTable[i].nextDirection)));
			}
		}
		Debug.LogError("Error: direction directionTable not defined for this tile.");
		return Vector2.zero;
	}
	private float VecToAngle(Vector2 vec)
	{
		if (vec == new Vector2(0 , 1))
		{
			return 0;
		}
		else
			if (vec == new Vector2(0, -1))
			{
				return 180;
			}
			else
				if (vec == new Vector2(1, 0))
				{
					return 90;
				}
				else
					if (vec == new Vector2(-1, 0))
					{
						return 270;
					}
		Debug.LogError("something went wrong 1");
		return 0;
	}
	private float IncreaseAngle(float angle)
	{
		float value = angle + rotation;
		Debug.Log("Pre:" + angle + " Post:" + value);
		if (value >= 360)
		{
			value = value - 360;
		}
		return value;
	}
	private Vector2 AngleToVec(float angle)
	{
		if (angle == 0) { return new Vector2(0, 1); }
		else
			if (angle == 90) { return new Vector2(1, 0); }
			else
				if (angle == 180) { return new Vector2(0, -1); }
				else
					if (angle == 270) { return new Vector2(-1, 0); }
		Debug.LogError("something went wrong 2");
		return Vector2.zero;
	}
	//public RectTransform GetDestination(Vector2 previousTilePosition){
	//	Vector2 vec = previousTilePosition - position;
		
		
	//	//RectTransform entrance;
	//	//for (int i = 0; i < tileEntrances.Length; i++){
	//	//	if (Vector3.Distance(currentPosition.position, tileEntrances[i].position) < ENTRANCE_DETECTION_DISTANCE){
	//	//		entrance = tileEntrances[i];
	//	//		for (int j = 0; j < destinationsTable.Length; j++){
	//	//			if (destinationsTable[j].entrance == entrance){
	//	//				return destinationsTable[j].goal;
	//	//			}
	//	//		}
	//	//	}
	//	//}
	//	return null;
	//}
	
	[Serializable]
	public struct EntranceToGoal{
		public Vector2 previousDirection;
		public Vector2 nextDirection;
	}
	private testDirections GetEntrance(Vector2 vec)
	{
		if (vec.x == 1) {
			return testDirections.E;
		}
		else if (vec.x == -1) {
			return testDirections.W;
		}
		else if (vec.y == 1) {
			return testDirections.N;
		}
		else if (vec.y == -1){
			return testDirections.S;
		}
		else{
			return testDirections.none;
			
		}
	}
	enum testDirections 
	{
		none,
		N,
		S,
		W,
		E
	}
}
