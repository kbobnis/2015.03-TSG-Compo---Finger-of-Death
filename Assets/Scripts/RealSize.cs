using UnityEngine;
using System.Collections;

public class RealSize : MonoBehaviour {

	internal void SetSize(float originalW, float originalH) {
		GetComponent<RectTransform>().offsetMin = new Vector2(-originalW / 2, -originalH/2);
		GetComponent<RectTransform>().offsetMax = new Vector2(originalW / 2, originalH / 2);
		return;

	}
}
