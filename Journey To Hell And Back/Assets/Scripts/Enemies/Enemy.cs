/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 08/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.layer == LayerMask.NameToLayer ("player")) {
			DealDamageToPlayer ();
		}
	}

	void DealDamageToPlayer(){
		float damageFromEnemy = 25f;

		PlayerHealth.currentHealth -= damageFromEnemy;
	}
}
