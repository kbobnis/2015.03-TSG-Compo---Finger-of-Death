using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Person : MonoBehaviour {

	internal void Prepare() {
		Sprite s = SpriteManager.RandomPerson();
		GetComponent<Image>().sprite = s;
	}
}
