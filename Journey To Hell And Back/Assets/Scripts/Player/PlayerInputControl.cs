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
	public int initialExtraJumps;

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

	private int extraJumps;
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
		_areaForceAttack = Input.GetKeyDown (KeyCode.Space);
		moveLeftAndRight = Input.GetAxisRaw ("Horizontal");

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (areaForceAttack) {
			forceAttack.ExpandCircle ();
		}

		rb2d.velocity = new Vector2 (moveLeftAndRight * speed, rb2d.velocity.y);

		FaceDirection ();
		DoubleJump ();

		// If I press down the key...
		if (jump) {
			if (grounded) {
				rb2d.velocity = Vector2.up * jumpForce;
				stoppedJumping = false;
			}
		}

		if(_areaForceAttack){
			areaForceAttack = true;
		}
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
		if (grounded) {
			extraJumps = initialExtraJumps;
		}

		if (jump && extraJumps > 0) {
			rb2d.velocity = Vector2.up * jumpForce;
			extraJumps--;
		}else if (jump && extraJumps == 0 && grounded){
			rb2d.velocity = Vector2.up * jumpForce;
		}
	}
}
