using UnityEngine;
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

	private void Touched(BaseEventData bed)
	{
		Person p = transform.parent.GetComponent<Person>();
		if (p == null)
		{
			throw new System.Exception("Why are you touching something like this?");
		}
		p.Health--;
		if (p.ShadeOfCones.Count > 0){
			Game.Me.EndGame();
		}
		else 
		{
			PanelMinigame.IncreaseScore(1);
			PanelGUI.GetPanelGUI().UpdateScore(PanelMinigame.score);
		}
	}	
}
