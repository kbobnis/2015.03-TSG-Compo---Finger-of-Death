using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DEBUG_TileTester : MonoBehaviour {
	
	public Tile testedTile;

	private RectTransform ownRectTransform;
	
	void Awake(){
		ownRectTransform = GetComponent<RectTransform>();
	}

	void Update(){
	}
}
