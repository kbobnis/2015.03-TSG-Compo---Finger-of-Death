using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {

	void OnTriggerEnter(Collider col){

		Person player = transform.parent.GetComponent<Person>();

		Person enemy;
		if (col.transform.GetComponent<PlayerCollisionScript>() == true){
			enemy = col.transform.parent.GetComponent<Person>();
			if (player.Health>0 && enemy.Health>0  && player._CollisionGroup != enemy._CollisionGroup){
				//player.Health -= enemy.AttackPower;
				enemy.Health -= player.AttackPower;

				if (enemy.Health <= 0 && enemy.GetComponent<Buff>() != null) {
					player.AddBuff(enemy.GetComponent<Buff>());
				}
			}
		}

		ConeOfVisibility cov = null;
		if ((cov = col.GetComponent<ConeOfVisibility>())){
			Person enemySees = col.gameObject.transform.parent.gameObject.GetComponent<Person>();
			if (enemySees != player) {
				player.SomeoneSeesMe(enemySees);
			}
		}
	}

	void OnTriggerExit(Collider col){
		Person player = transform.parent.GetComponent<Person>();

		ConeOfVisibility cov = null;
		if (cov = col.GetComponent<ConeOfVisibility>()) {
			Person enemySees = col.gameObject.transform.parent.gameObject.GetComponent<Person>();
			player.SomeoneDoesntSeeMe(enemySees);
		}

	}
}
