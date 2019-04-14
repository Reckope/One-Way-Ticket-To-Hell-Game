using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Scripts and Components
	public Enemy enemy;
	private Rigidbody2D rb2d;

	// Global Variables
	private int direction;
	private float speed;
	private float checkRadius;
	private bool collidedLeft;
	private bool collidedRight;

	// Game Objects
	GameObject player;
	public LayerMask whatIsEnemy;
	public LayerMask whatIsWall;
	public Transform leftCheck;
	public Transform rightCheck;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		direction = -1;
		speed = 2f;
		checkRadius = 0.1f;
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!enemy.enemyIsDead && CalculateDistanceBetweenPlayerAndEnemy() < 50f && !GameController.instance.GameOver()){
			rb2d.velocity = new Vector2 (direction * speed, 0);
			collidedLeft = Physics2D.OverlapCircle (leftCheck.position, checkRadius, whatIsWall);
			collidedRight = Physics2D.OverlapCircle (rightCheck.position, checkRadius, whatIsWall);
			if(collidedLeft){
				direction = 1;
			}
			else if(collidedRight){
				direction = -1;
			}
		}
	}

	private float CalculateDistanceBetweenPlayerAndEnemy(){
		float distance;

		distance = Vector2.Distance(player.transform.position, gameObject.transform.position);

		return distance;
	}
}
