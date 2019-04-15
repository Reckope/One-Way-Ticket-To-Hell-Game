/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is the intermediary enemy script. It controls when the enemy dies. Would be beneficial to
 * merge "EnemyMovement.cs" into this script since it's not that big??
 * Code QA sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Components
	private Vector2 enemy;
	Collider2D collide;
	CapsuleCollider2D CapsuleCollider2D;
	SpriteRenderer sprite;
	Rigidbody2D rb2d;

	// GameObjects
	public AudioSource enemyDieAudio;

	// Global Variables
	public bool enemyIsDead;
	private bool preventLoop;
	private float enemyCurrentHealth;
	private float maxHealth;
	private float minHealth;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		collide = GetComponent<Collider2D>();
		CapsuleCollider2D = GetComponent<CapsuleCollider2D>();
		sprite = GetComponent<SpriteRenderer>();
		enemyIsDead = false;
		preventLoop = false;
		minHealth = 0f;

		// Set the health for each type of enemy.
		if(gameObject.tag == ("Demon")){
			maxHealth = 100f;
			enemyCurrentHealth = maxHealth;
		}
		if(gameObject.tag == ("Reaper")){
			maxHealth = 200f;
			enemyCurrentHealth = maxHealth;
		}
		if(gameObject.tag == ("Satan")){
			maxHealth = 800f;
			enemyCurrentHealth = maxHealth;
		}
	}

	// Update is called once per frame
	void Update () {
		// If the enemy isn't dead.
		if (!enemyIsDead) {
			if (enemyCurrentHealth <= minHealth) {
				enemyIsDead = true;
			}
		}
		// If the enemy dies.
		else if(enemyIsDead){
			if(preventLoop){
				return;
			}
			preventLoop = true;
			StartCoroutine(EnemyDie());
		}
	}

	void OnTriggerEnter2D (Collider2D collide){
	// If the enemy touches the Area Force Attack...
		if (collide.gameObject.layer == LayerMask.NameToLayer ("ForceAttack")) {
			enemyIsDead = true;
		}
		// If the enemy gets hit by a projectile...
		if(collide.gameObject.layer == LayerMask.NameToLayer("Projectile")){
			StartCoroutine(TakeDamage());
		}
	}

	// When the enemy takes damage from a projectile.
	private IEnumerator TakeDamage(){
		enemyCurrentHealth -= 12f;
		sprite.color = new Color(1f, 1f, 1f, 0.5f);
		yield return new WaitForSeconds(0.05f);
		sprite.color = new Color(1f, 1f, 1f, 1f);
	}

	// When the enemy dies.
	private IEnumerator EnemyDie(){
		enemyDieAudio.Stop();
		enemyDieAudio.Play();
		collide.enabled = false;
		CapsuleCollider2D.enabled = false;
		rb2d.bodyType = RigidbodyType2D.Dynamic;
		rb2d.velocity = (new Vector2 (0, 4f));
		GameController.score += 1;
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
