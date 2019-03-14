/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 13/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControl : MonoBehaviour {

	public AreaForceAttack forceAttack;

	public GameObject swordLeft;
	public GameObject swordRight;

	public float speed;
	public float jumpForce;
	public float groundDist;

	public bool grounded;
	public bool stoppedJumping;
	public bool goingRight;
	public bool goingLeft;

	public LayerMask whatIsGround;

	public Transform groundCheck;
	public float groundCheckRadius;

	public static bool jump;
	public static bool left;
	public static bool right;
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
	}

	void Update(){

		// This is designed for keyboard input at the moment.
		jump = Input.GetKeyDown (KeyCode.W);
		moveLeftAndRight = Input.GetAxisRaw ("Horizontal");
		_areaForceAttack = Input.GetKeyDown (KeyCode.Space);
		if(rb2d.bodyType == RigidbodyType2D.Dynamic){
			rb2d.velocity = new Vector2 (moveLeftAndRight * speed, rb2d.velocity.y);
		}

		// Check if the player is grounded.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		// If I press down the key...
		if (jump) {
			if (grounded) {
				rb2d.velocity = Vector2.up * jumpForce;
				stoppedJumping = false;
			}
		}

		// 2 bools allow the circle to continue expending without holding down space bar.
		if(_areaForceAttack && !AreaForceAttack.ForceAttackCooldownActive()){
			areaForceAttack = true;
		}
		if (areaForceAttack) {
			forceAttack.ExpandCircle ();
		}

		// Necessary Methods.
		FaceDirection ();
		DoubleJump ();
	}

	void FaceDirection(){
		if (moveLeftAndRight < 0) {
			goingLeft = true;
			mySpriteRenderer.flipX = false;
			goingRight = false;
		}

		if (moveLeftAndRight > 0) {
			goingRight = true;
			goingLeft = false;
			mySpriteRenderer.flipX = true;
		}
	}

	void DoubleJump(){
		int extraJumps = 1;

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
	}
}
