/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is used for the force attack refill item. 
 * Code QA Sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAttackItem : MonoBehaviour {

	// If the player collides with the force attack refill item...
	private void OnTriggerEnter2D (Collider2D collide){
		if (collide.gameObject.tag == ("Player") && gameObject != null) {
			AreaForceAttack.cooldownValue = 100f;
			Destroy(gameObject);
		}
	}
}
