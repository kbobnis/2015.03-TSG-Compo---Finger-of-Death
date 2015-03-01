using UnityEngine;
using System.Collections;

public class ConeOfVisibility : MonoBehaviour, DirectionListener {

	// Update is called once per frame
	void Update () {
	
	}

	internal void Prepare() {
		if (GetComponent<Person>()) {
			GetComponent<Person>().DirectionListener = this;
		}
	}

	public void DirectionChanged(Direction StartDir, Direction DestDir) {
		transform.rotation = new Quaternion();
		transform.Rotate(0, 0, -StartDir.Angle(DestDir));
	}

}


public interface DirectionListener {

	void DirectionChanged(Direction StartDir, Direction DestDir);
}