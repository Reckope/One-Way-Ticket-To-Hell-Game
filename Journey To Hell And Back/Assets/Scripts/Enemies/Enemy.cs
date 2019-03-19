/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 19/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	// Using Other Scripts:
	SpawnEnemiesController spawnEnemy;

	private Vector2 enemy;
	GameObject player;

	public static bool enemyIsDead;
	Collider2D _collider;

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		// Using other scripts:
		spawnEnemy = FindObjectOfType(typeof(SpawnEnemiesController)) as SpawnEnemiesController;

		player = GameObject.FindWithTag ("Player");
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		_collider = GetComponent<Collider2D>();
		enemyIsDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyIsDead) {
			FollowPlayer ();
		}
	}

	// If the enemy touches the Player...
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.layer == LayerMask.NameToLayer ("player")) {
			DealDamageToPlayer ();
		}
	}

	// If the enemy touches a trigger box...
	void OnTriggerEnter2D (Collider2D collide){
		// If the enemy touches the Area Force Attack...
		if (collide.gameObject.layer == LayerMask.NameToLayer ("playerAttack")) {
			EnemyDie ();
		}
	}

	void DealDamageToPlayer(){
		float dealDamage = 25f;

		PlayerHealth.currentHealth -= dealDamage;
		PlayerSystems.TakeDamage ();
	}

	public void EnemyDie(){
		enemyIsDead = true;
		_collider.enabled = false;
		rb2d.velocity = (new Vector2 (0, 4f));
		GameController.score += 1;
		StartCoroutine (RespawnEnemy ());
	}

	void FollowPlayer(){
		float moveSpeed = 2f;

		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
	}

	private IEnumerator RespawnEnemy(){
		yield return new WaitForSeconds (1.7f);
		_collider.enabled = true;
		enemyIsDead = false;
        Destroy(gameObject);
		spawnEnemy.RespawnEnemyWhichLevel();
	}
}
