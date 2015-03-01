using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConeOfVisibility : MonoBehaviour, DirectionListener {

	// Update is called once per frame
	void Update () {
	
	}

	internal void Prepare() {
		if (GetComponent<Person>()) {
			GetComponent<Person>().DirectionListener = this;
		}

		int personW = (int)(GetComponent<Image>().sprite.rect.width * AspectRatioKeeper.ActualScale);
		int personH = (int)(GetComponent<Image>().sprite.rect.height * AspectRatioKeeper.ActualScale);
		gameObject.AddComponent<RealSize>().SetSize(personW, personH);
		Vector3 pos = gameObject.GetComponent<RectTransform>().localPosition;
		gameObject.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y + personH / 2, pos.z);

		gameObject.GetComponent<BoxCollider>().size = new Vector3(personW*4/5, personH, 32);
		gameObject.GetComponent<BoxCollider>().center = new Vector3(0, personH/2, 0);
	}

	public void DirectionChanged(Direction StartDir, Direction DestDir) {
		transform.rotation = new Quaternion();
		transform.Rotate(0, 0, -StartDir.Angle(DestDir));
	}

}


public interface DirectionListener {

	void DirectionChanged(Direction StartDir, Direction DestDir);
}