using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : MonoBehaviour {

	public float damageFromEnemy = 25f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			Debug.Log ("HIT_BY_ENEMY");
		}

		/*if (collide.gameObject.layer == LayerMask.NameToLayer ("healthPickup")) {
			Debug.Log ("COLLECTED_HEALTH");
			PlayerHealth.currentHealth += PlayerHealth.increaseHealth;
		}*/
	}

	public void Invulnerable(){
		
	}
}
