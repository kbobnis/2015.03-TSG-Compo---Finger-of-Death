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
		//if (Input.GetKeyDown(KeyCode.O)) {
		//	for (int i = 0; i < testedTile.tileEntrances.Length; i++){
		//		Debug.Log("entrance " + i + ": " +testedTile.tileEntrances[i].position);
		//	}
		//}

		//if (Input.GetKeyDown(KeyCode.I)){
		//	Vector2 nextDest = testedTile.GetNextDirection(-Vector2.up);
		//	Debug.Log(nextDest);
		//}

		//if (Input.GetKeyDown(KeyCode.K))
		//{
		//	Vector2 nextDest = testedTile.GetNextDirection(Vector2.up);
		//	Debug.Log(nextDest);
		//}


		//if (Input.GetKeyDown(KeyCode.L))
		//{
		//	Vector2 nextDest = testedTile.GetNextDirection(Vector2.right);
		//	Debug.Log(nextDest);
		//}
		//if (Input.GetKeyDown(KeyCode.J))
		//{
		//	Vector2 nextDest = testedTile.GetNextDirection(-Vector2.right);
		//	Debug.Log(nextDest);
		//}
	}
	//IEnumerator GoToDestination(RectTransform destination){
	//	do{
	//		Vector3 vec = destination.position - ownRectTransform.position;
	//		vec.Normalize();
	//		ownRectTransform.position += vec * 20 * Time.deltaTime;
	//		yield return new WaitForEndOfFrame();
	//	}while(Vector3.Distance(destination.position,ownRectTransform.position)>0.5f);
	//}
}
