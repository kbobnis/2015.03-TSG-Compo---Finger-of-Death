using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {

	Person player;
	void Awake() { 
		player = GetComponent<Person>();
		
	}
	void Update() 
	{
		//ControlbuffsOnPlayer
		PanelGUI.GetPanelGUI().UpdateTimer(player.timeToDeath);
		PanelGUI.GetPanelGUI().UpdateScore(player.score);
	}
	void OnTriggerEnter(Collider col)
	{
		Person enemy;
		if ((enemy = col.GetComponent<Person>()) == true) 
		{
			if (player.lives>0 && enemy.lives>0  && player.group != enemy.group)
			{
				if ((player.lives - enemy.attackPower) > 0) 
				{
					player.lives -= enemy.attackPower;
				}
				else 
				{
				//Player is dead;
					player.lives = 0;
					//ENDGAME
				}
				if ((enemy.lives - player.attackPower) > 0)
				{
					enemy.lives -= player.attackPower;
				}
				else
				{
					//enemy is dead;
					player.AddBuff(enemy.personBuff);
					enemy.lives = 0;

					//GetBonus
				}
			}
		}
	}
}
