﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TouchToKill : MonoBehaviour {

	public void Prepare () {

		EventTrigger et = gameObject.GetComponent<EventTrigger>();
		if (et == null) {
			et = gameObject.AddComponent<EventTrigger>();
			et.delegates = new List<EventTrigger.Entry>();
		}

		EventTrigger.Entry pointerDown = new EventTrigger.Entry();
		pointerDown.eventID = EventTriggerType.PointerDown;
		pointerDown.callback = new EventTrigger.TriggerEvent();
		pointerDown.callback.AddListener(Touched);

		et.delegates.Add(pointerDown);	
	}

	private void Touched(BaseEventData bed) {
		Destroy(gameObject);
	}
	
}
