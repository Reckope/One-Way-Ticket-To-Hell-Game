/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 12/03/19
 * "[x]" = Reference
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputControl : MonoBehaviour {

	// Scripts and components.
	public AreaForceAttack forceAttack;
	public CameraController cameraController;
	public ProjectilePool projectilePool;
	private Rigidbody2D rb2d;
	private SpriteRenderer mySpriteRenderer;
	//private BoxCollider2D myBoxCollider;

	// GameObjects
	public Slider controlSlider;
	public Slider shootSlider;

	// Global variables.
	public static float playerSpeedValue;
	public static bool shootingLeft, shootingRight;

	public float speed;
	public float jumpForce;
	public float groundDist;

	public static bool grounded;
	public bool stoppedJumping;

	public bool goingRight;
	public bool goingLeft;
	public bool lookingLeft;
	public bool lookingRight;
	public bool shooting;

	private float fireRate;
	private float nextFire;

	public LayerMask whatIsGround;

	public Transform groundCheck;
	public float groundCheckRadius;

	public bool jump;
	public bool left;
	public bool right;
	public static bool _areaForceAttack = false;
	public static bool areaForceAttack = false;

	private int initialExtraJumps;
	private float moveLeftAndRight;
	private float shootLeftAndRight;

	void Start (){
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		controlSlider.value = 0;
		shootSlider.value = 0;
		fireRate = 0.12f;
		nextFire = 0.0f;
	}

	void Update(){
		//Debug.Log("Shooting " + shooting);
		//Debug.Log("Shoot: " + shootSlider.value);
		playerSpeedValue = controlSlider.value;
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

	public void Jump(){
		jump = true;
		if(jump){
			if (grounded) {
				rb2d.velocity = Vector2.up * jumpForce;
				stoppedJumping = false;
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
	void DoubleJump(){
		int extraJumps = 2;

		if (grounded) {
			initialExtraJumps = extraJumps;
		}

		if (jump && initialExtraJumps > 0) {
			rb2d.velocity = Vector2.up * jumpForce;
			initialExtraJumps--;
		}
		else if (jump && initialExtraJumps == 0 && grounded){
			rb2d.velocity = Vector2.up * jumpForce;
		}
		jump = false;
	}

	// Player faces the direction they're moving.
	void FaceDirection(){
		if(controlSlider.value < 0){
			goingRight = false;
			goingLeft = true;
		}
		else if (controlSlider.value > 0) {
			goingRight = true;
			goingLeft = false;
		}

		if (shootSlider.value < 0) {
			mySpriteRenderer.flipX = false;
		}
		else if(shootSlider.value > 0){
			mySpriteRenderer.flipX = true;
		}
	}

	// Move the player with the horizontalMovementSlider.
	void MovePlayerWithSlider(){
		moveLeftAndRight = Input.GetAxisRaw ("HorizontalControl");
		rb2d.velocity = new Vector2 (controlSlider.value * speed, rb2d.velocity.y);
	}

	// Shoot projectiles using the shooterSlider.
	void ShootWithSlider(){
		//shootLeftAndRight = Input.GetAxisRaw("HorizontalShoot");
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
