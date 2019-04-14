/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is used to move the enemies left to right. Have decided to place this in
 * it's own script in case I want to improve the enemy AI in the future. 
 * Code QA sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Scripts and Components
	public Enemy enemy;
	private Rigidbody2D rb2d;
	private SpriteRenderer mySpriteRenderer;

	// Global Variables
	private int direction;
	private float speed;
	private float checkRadius;
	private bool collidedLeft;
	private bool collidedRight;

	// Game Objects & Layer Masks
	GameObject player;
	public LayerMask whatIsWall;
	public Transform leftCheck;
	public Transform rightCheck;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		player = GameObject.Find("Player");
		direction = -1;
		speed = 2f;
		checkRadius = 0.1f;
	}

	// FixedUpdate can run once, zero, or several times per frame (use if Physics is involved).
	void FixedUpdate () {
		// If the player is within a set distance from the enemy, move them.
		if(!enemy.enemyIsDead && DistanceBetweenPlayerAndEnemy() < 50f && !GameController.instance.GameOver()){
			rb2d.velocity = new Vector2 (direction * speed, 0);
			// Check if the enemy hits a wall.
			collidedLeft = Physics2D.OverlapCircle (leftCheck.position, checkRadius, whatIsWall);
			collidedRight = Physics2D.OverlapCircle (rightCheck.position, checkRadius, whatIsWall);
			// If the enemy hits a wall, change their direction.
			if(collidedLeft){
				direction = 1;
				mySpriteRenderer.flipX = true;
			}
			else if(collidedRight){
				direction = -1;
				mySpriteRenderer.flipX = false;
			}
		}
	}

	// Calculate the distance between the player and the enemy. 
	private float DistanceBetweenPlayerAndEnemy(){
		float distance;

		distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
		return distance;
	}
}
