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

	public AreaForceAttack forceAttack;

	public Slider horizontalControlSlider;

	public float speed;
	public float jumpForce;
	public float groundDist;

	public static bool grounded;
	public bool stoppedJumping;
	public bool goingRight;
	public bool goingLeft;

	public LayerMask whatIsGround;

	public Transform groundCheck;
	public float groundCheckRadius;

	public bool jump;
	public bool left;
	public bool right;
	public static bool _areaForceAttack = false;
	public static bool areaForceAttack = false;

	private Rigidbody2D rb2d;

	private int initialExtraJumps;
	private float moveLeftAndRight;

	private SpriteRenderer mySpriteRenderer;
	private BoxCollider2D myBoxCollider;

	void Start (){
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		horizontalControlSlider.value = 0;
	}

	void Update(){
		if(rb2d.bodyType == RigidbodyType2D.Dynamic){
			//KeyboardControls();
			if(horizontalControlSlider.value < 0){
				rb2d.velocity = new Vector2 (-1 * speed, rb2d.velocity.y);
			}
			else if(horizontalControlSlider.value > 0){
				rb2d.velocity = new Vector2 (1 * speed, rb2d.velocity.y);
			}
			else if(horizontalControlSlider.value == 0){
				rb2d.velocity = new Vector2 (0 * speed, rb2d.velocity.y);
			}
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

	public void ResetSlider(){
		horizontalControlSlider.value = 0;
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
		if (horizontalControlSlider.value < 0) {
			goingLeft = true;
			mySpriteRenderer.flipX = false;
			goingRight = false;
		}

		if (horizontalControlSlider.value > 0) {
			goingRight = true;
			goingLeft = false;
			mySpriteRenderer.flipX = true;
		}
	}

	// This is for either testing purposes, or PC build.
	void KeyboardControls(){
		// *** JUMP CONTROLS ***
		//jump = Input.GetKeyDown (KeyCode.W);
		//if(jump){
		//	if (grounded) {
		//		rb2d.velocity = Vector2.up * jumpForce;
		//		stoppedJumping = false;
		//	}
		//}
		//DoubleJump();

		// *** HORIZONTAL CONTROLS ***
		moveLeftAndRight = Input.GetAxisRaw ("Horizontal");
		rb2d.velocity = new Vector2 (moveLeftAndRight * speed, rb2d.velocity.y);

		// *** AREA FORCE ATTACK CONTROLS ***
		//_areaForceAttack = Input.GetKeyDown (KeyCode.Space);
		//if(_areaForceAttack && !AreaForceAttack.ForceAttackCooldownActive()){
		//	areaForceAttack = true;
		//}
	}
}
