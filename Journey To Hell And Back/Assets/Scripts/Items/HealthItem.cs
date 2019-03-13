﻿/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 08/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour {

	float increaseHealth = 25f;

	void OnTriggerEnter2D (Collider2D collide){
		if (collide.gameObject.layer == LayerMask.NameToLayer ("player")) {
			PlayerHealth.currentHealth += increaseHealth;
		}
	}

}