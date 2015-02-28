using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

	public void StartLife (){
		StartCoroutine ("LifeTime");
	}

	public int positionX = 0;
	public int positionY = 0;
	public bool DEBUG = false;
	int speed = 20;
	public const int MINIMAL_DISTANCE_TO_DESTINATION = 1;
	Direction dirFrom;
	public Direction dirTo;
	int progress = 0;
	Vector3 destination;
	RectTransform rectTransform;
	public void SetPerson(int startTileX, int startTileY, Direction endDirection){
		positionX = startTileX;
		positionY = startTileY;
		this.dirTo = endDirection;
		rectTransform = GetComponent<RectTransform>();

		destination = InGamePos.GetDestination(positionX, positionY, endDirection);
		StartCoroutine(MoveToGoal());
		//NewTile();
	}
	public void Update() {
		if(Input.GetKeyDown(KeyCode.P)){
			NewTile();
		}
	}
	public void NewTile() {
		progress = 0;
		dirFrom = SwichDirFromToTileEntrance(dirTo);
		if (DEBUG) {
			Debug.Log(dirTo + ">" + dirFrom);
		}
		switch (dirTo){
			case Direction.N:
				positionY--;
				break;
			case Direction.S:
				positionY++;
				break;
			case Direction.W:
				positionX--;
				break;
			case Direction.E:
				positionX++;
				break;
			default:
				break;
		}
		dirTo = GetDirToFromTile(dirFrom);

		if (DEBUG){
			Debug.Log("newDirTo:" + dirTo + ", DirFrom:" + dirFrom);
		}
		destination = InGamePos.GetDestination(positionX,positionY,dirTo);
		StartCoroutine(MoveToGoal());
	}
	public IEnumerator MoveToGoal() { 
		Vector3 toDestination = (destination - rectTransform.position);
		do{
			yield return new WaitForEndOfFrame();
			rectTransform.position += toDestination.normalized * Time.deltaTime * speed;
			toDestination = (destination - rectTransform.position);
		} while (MINIMAL_DISTANCE_TO_DESTINATION < toDestination.sqrMagnitude);
		
	}
	private Direction GetDirToFromTile(Direction d){
		return Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelTiles.GetComponent<PanelTiles>().ListOfTiles[positionY][positionX].GetNextDirection(d);
	}
	private Direction SwichDirFromToTileEntrance(Direction d){
		switch (d){
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
		throw new System.Exception("Direction not recognised:" + d);
	}
	IEnumerator LifeTime (){
		yield return new WaitForSeconds (10);
		Game.Me.PanelMinigame.GetComponent<PanelMinigame>().PanelPeople.GetComponent<PanelPeople>().KillPerson ();
	}
}
