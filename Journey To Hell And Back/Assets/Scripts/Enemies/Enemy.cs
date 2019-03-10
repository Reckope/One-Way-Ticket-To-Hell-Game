/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 09/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public static Collider2D _collider;
	public GameObject player;

	public static bool enemyIsDead;

	static Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		_collider = GetComponent<Collider2D> ();
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

	void DealDamageToPlayer(){
		float dealDamage = 25f;

		PlayerHealth.currentHealth -= dealDamage;
		PlayerSystems.TakeDamage ();
	}

	public static void EnemyDie(){
		enemyIsDead = true;
		_collider.enabled = !_collider.enabled;
		rb2d.constraints = RigidbodyConstraints2D.None;
		rb2d.velocity = (new Vector2 (0, 2f));
		GameController.score += 1;
	}

	void FollowPlayer(){
		float moveSpeed = 2f;

		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
	}
}
