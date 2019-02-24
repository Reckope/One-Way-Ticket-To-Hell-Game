using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour {

	public LayerMask whatIsFriendly;

	void OnTriggerEnter2D (Collider2D collide){
		if (collide.gameObject.layer == LayerMask.NameToLayer ("friendly")) {
			MainCharacterHealth.currentHealth += MainCharacterHealth.increaseHealth;
		}
	}

}
