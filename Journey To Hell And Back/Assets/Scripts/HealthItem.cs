using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collide){
		if (collide.gameObject.layer == LayerMask.NameToLayer ("player")) {
			Debug.Log ("COLLECTED_HEALTH");
			PlayerHealth.currentHealth += PlayerHealth.increaseHealth;
		}
	}

}
