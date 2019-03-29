/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 19/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAttackItem : MonoBehaviour {

	//private bool activateForceAttack;

	// If the player collides with the force attack item...
	private void OnTriggerEnter2D (Collider2D collide){
		if (collide.gameObject.tag == ("Player") && gameObject != null) {
			AreaForceAttack.cooldownValue = 100f;
			Destroy(gameObject);
		}
	}

}
