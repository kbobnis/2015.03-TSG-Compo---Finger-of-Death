using UnityEngine;
using System.Collections;

public class ConeOfVisibility : MonoBehaviour, DirectionListener {

	public GameObject ImageCone;

	// Update is called once per frame
	void Update () {
	
	}

	internal void Prepare() {
		if (GetComponent<Person>()) {
			GetComponent<Person>().DirectionListener = this;
		}
	}

	public void DirectionChanged(Direction StartDir, Direction DestDir) {
		ImageCone.transform.rotation = new Quaternion();
		ImageCone.transform.Rotate(0, 0, -StartDir.Angle(DestDir));
	}

}


public interface DirectionListener {

	void DirectionChanged(Direction StartDir, Direction DestDir);
}