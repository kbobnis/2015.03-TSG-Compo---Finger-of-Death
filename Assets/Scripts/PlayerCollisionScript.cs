using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {

	Person player;
	void Awake() { 
		player = GetComponent<Person>();
		
	}
	void Update() 
	{
		PanelGUI.GetPanelGUI().UpdateScore(player.Points);
	}

	void OnTriggerEnter(Collider col)
	{
		Person enemy;
		if ((enemy = col.GetComponent<Person>()) == true) 
		{
			if (player.Health>0 && enemy.Health>0  && player._CollisionGroup != enemy._CollisionGroup)
			{
				//player.Health -= enemy.AttackPower;
				enemy.Health -= player.AttackPower;

				if (enemy.Health <= 0 && enemy.GetComponent<Buff>() != null) {
					player.AddBuff(enemy.GetComponent<Buff>());
				}
			}
		}

		ConeOfVisibility cov = null;
		if ((cov = col.GetComponent<ConeOfVisibility>()) && col.gameObject.transform.parent.gameObject.GetComponent<Person>() == player) {
			GetComponent<Person>().SomeoneSeesMe();
		}
	}

	void OnTriggerExit(Collider col){

		ConeOfVisibility cov = null;
		if (cov = col.GetComponent<ConeOfVisibility>()) {
			GetComponent<Person>().SomeoneDoesntSeeMe();
		}

	}
}
