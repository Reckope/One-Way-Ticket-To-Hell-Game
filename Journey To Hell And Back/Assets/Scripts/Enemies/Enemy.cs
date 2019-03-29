/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 19/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Vector2 enemy;

	private bool enemyIsDead;
	Collider2D collider;

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		collider = GetComponent<Collider2D>();
		enemyIsDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyIsDead) {

		}
	}

	// If the enemy touches the Player...
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == ("Player")) {
			KillPlayer ();
		}
	}

	// If the enemy touches a trigger box...
	void OnTriggerEnter2D (Collider2D collide){
		// If the enemy touches the Area Force Attack...
		if (collide.gameObject.layer == LayerMask.NameToLayer ("playerAttack")) {
			StartCoroutine(EnemyDie());
		}
	}

	void KillPlayer(){
		PlayerSystems.playerIsDead = true;
	}

	private IEnumerator EnemyDie(){
		enemyIsDead = true;
		collider.enabled = false;
		rb2d.velocity = (new Vector2 (0, 4f));
		GameController.score += 1;
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}

	/*
	private IEnumerator RespawnEnemy(){
		yield return new WaitForSeconds (1.7f);
		_collider.enabled = true;
		enemyIsDead = false;
		Destroy(gameObject);
		spawnEnemy.RespawnEnemyWhichLevel();
	}*/
}
