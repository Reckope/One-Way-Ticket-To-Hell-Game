/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is a custom player script used to control the movements, and perform 
 * cool actions (force attack, double jump, shoot projectiles).
 * Code QA sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputControl : MonoBehaviour {

	// Scripts and components.
	public AreaForceAttack forceAttack;
	public ProjectilePool projectilePool;
	private Rigidbody2D rb2d;
	private SpriteRenderer mySpriteRenderer;

	// GameObjects
	public Slider controlSlider;
	public Slider shootSlider;
	public AudioSource jumpAudio;
	public AudioSource shootAudio;
	public LayerMask whatIsGround;
	public Transform groundCheck;

	// Global variables
	public static bool shootingLeft, shootingRight;
	public bool _areaForceAttack;
	public bool areaForceAttack;
	private float fireRate;
	private float nextFire;
	private bool grounded;
	private float speed;
	private float jumpForce;
	private float groundCheckRadius;
	private bool jump;
	private int initialExtraJumps;
	private float moveLeftAndRight;
	private bool preventLoop;

	// Use this for initialization
	void Start (){
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		_areaForceAttack = false;
		areaForceAttack = false;
		controlSlider.value = 0;
		shootSlider.value = 0;
		fireRate = 0.15f;
		nextFire = 0.0f;
		speed = 7f;
		jumpForce = 14f;
		groundCheckRadius = 0.7f;
	}

	// Update is called once per frame
	void Update(){
		// Control the player.
		if(rb2d.bodyType == RigidbodyType2D.Dynamic && LevelController.currentLevel > 0 && !GameController.instance.GameOver()){
			//KeyboardControls();
			MovePlayerWithSlider();
			ShootWithSlider();
		}

		// Check if the player is grounded.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround); // [1]

		// Necessary Methods.
		FaceDirection ();
	}

	// Jump!
	private void Jump(){
		jump = true;
		if(jump){
			if (grounded) {
				jumpAudio.Stop();
				jumpAudio.Play();
				rb2d.velocity = Vector2.up * jumpForce;
			}
		}
		DoubleJump();
	}

	public void PlayerForceAttack(){
		_areaForceAttack = true;
		if(_areaForceAttack && !AreaForceAttack.ForceAttackCooldownActive()){
			areaForceAttack = true;
		}
		forceAttack.ForceAttackCoodownValue();
		_areaForceAttack = false;
	}

	// Reset the Movement control slider once it's released.
	public void ResetControlSlider(){
		controlSlider.value = 0;
	}

	// Keep shooting if the player has dragged the slider to the far left / right.
	// Otherwise, reset it once it's released.
	public void ResetShootSlider(){
		if(shootSlider.value == 1){
			shootSlider.value = 1;
		}
		else if(shootSlider.value == -1){
			shootSlider.value = -1;
		}
		else
		shootSlider.value = 0;
	}

	// Enables Double Jump for the player
	private void DoubleJump(){
		int extraJumps = 2;

		if (grounded) {
			initialExtraJumps = extraJumps;
		}

		if (jump && initialExtraJumps > 0) {
			jumpAudio.Stop();
			jumpAudio.Play();
			rb2d.velocity = Vector2.up * jumpForce;
			initialExtraJumps--;
		}
		else if (jump && initialExtraJumps == 0 && grounded){
			rb2d.velocity = Vector2.up * jumpForce;
		}
		jump = false;
	}

	// Player faces the direction they're moving.
	private void FaceDirection(){
		if (shootSlider.value < 0) {
			mySpriteRenderer.flipX = false;
		}
		else if(shootSlider.value > 0){
			mySpriteRenderer.flipX = true;
		}
	}

	// Move the player with the horizontalMovementSlider.
	private void MovePlayerWithSlider(){
		moveLeftAndRight = Input.GetAxisRaw ("HorizontalControl");
		rb2d.velocity = new Vector2 (controlSlider.value * speed, rb2d.velocity.y);
	}

	// Shoot projectiles using the shooterSlider.
	private void ShootWithSlider(){
		// Shooting left.
		if(shootSlider.value <= -0.2 && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			shootingLeft = true;
			shootingRight = false;
			Shoot();
		}
		// Shooting right.
		else if(shootSlider.value >= 0.2 && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			shootingLeft = false;
			shootingRight = true;
			Shoot();
		}
	}

	// This is for either testing purposes, or PC build.
	void KeyboardControls(){
		// *** JUMP CONTROLS ***
		/*
		jump = Input.GetKeyDown (KeyCode.W);
		if(jump){
			if (grounded) {
				rb2d.velocity = Vector2.up * jumpForce;
				stoppedJumping = false;
			}
		}
		DoubleJump();
		*/

		// *** HORIZONTAL CONTROLS ***
		moveLeftAndRight = Input.GetAxisRaw ("HorizontalControl");
		controlSlider.value = moveLeftAndRight;
		rb2d.velocity = new Vector2 (moveLeftAndRight * speed, rb2d.velocity.y);

		// *** AREA FORCE ATTACK CONTROLS ***
		/*
		_areaForceAttack = Input.GetKeyDown (KeyCode.Space);
		if(_areaForceAttack && !AreaForceAttack.ForceAttackCooldownActive()){
			areaForceAttack = true;
		}
		*/
	}

	// Shoot the projectiles left or right.
	void Shoot(){
		float spawnBallLeft = (this.gameObject.transform.position.x - 1f);
		float spawnBallRight = (this.gameObject.transform.position.x + 1f);

		GameObject lightBall = projectilePool.GetPooledProjectile();
		if (lightBall != null){
			if(shootingLeft){
				lightBall.transform.position = new Vector2(spawnBallLeft, this.gameObject.transform.position.y);
			}
			else if(shootingRight){
				lightBall.transform.position = new Vector2(spawnBallRight, this.gameObject.transform.position.y);
			}
			lightBall.SetActive(true);
		}
	}
}
