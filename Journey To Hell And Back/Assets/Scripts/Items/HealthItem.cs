/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 19/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour {

	float increaseHealth = 25f;

	// If the player collides with the health item...
	void OnTriggerEnter2D (Collider2D collide){
		if (collide.gameObject.tag == ("Player")) {
			PlayerHealth.currentHealth += increaseHealth;
		}
	}

}
