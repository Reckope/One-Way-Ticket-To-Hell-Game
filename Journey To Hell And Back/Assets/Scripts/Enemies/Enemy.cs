/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 19/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Vector2 enemy;
	Collider2D collider;
	SpriteRenderer sprite;
	Rigidbody2D rb2d;

	private bool preventLoop;
	private bool enemyIsDead;
	private float enemyCurrentHealth;
	private float maxHealth;
	private float minHealth = 0f;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		collider = GetComponent<Collider2D>();
		sprite = GetComponent<SpriteRenderer>();
		enemyIsDead = false;
		preventLoop = false;

		if(gameObject.tag == ("Demon")){
			maxHealth = 100f;
			enemyCurrentHealth = maxHealth;
		}
		if(gameObject.tag == ("Reaper")){
			maxHealth = 200f;
			enemyCurrentHealth = maxHealth;
		}
		if(gameObject.tag == ("Satan")){
			maxHealth = 500f;
			enemyCurrentHealth = maxHealth;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyIsDead) {
			if (enemyCurrentHealth <= minHealth) {
				enemyIsDead = true;
			}
		}
		else if(enemyIsDead){
			if(preventLoop){
				return;
			}
			preventLoop = true;
			StartCoroutine(EnemyDie());
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
		if(collide.gameObject.layer == LayerMask.NameToLayer("Projectile")){
			StartCoroutine(TakeDamage());
		}
	}

	void KillPlayer(){
		PlayerSystems.playerIsDead = true;
	}

	private IEnumerator TakeDamage(){
		enemyCurrentHealth -= 10f;
		sprite.color = new Color(1f, 1f, 1f, 0.5f);
		yield return new WaitForSeconds(0.05f);
		sprite.color = new Color(1f, 1f, 1f, 1f);
	}

	private IEnumerator EnemyDie(){
		enemyIsDead = true;
		collider.enabled = false;
		rb2d.velocity = (new Vector2 (0, 4f));
		GameController.score += 1;
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
