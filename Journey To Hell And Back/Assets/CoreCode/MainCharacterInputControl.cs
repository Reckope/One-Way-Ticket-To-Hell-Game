using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterInputControl : MonoBehaviour {

	public float speed;
	public float jumpForce;
	public float jumpTime;
	public float jumpTimeCounter;

	private float moveLeftAndRight;

	public bool grounded;
	public LayerMask whatIsGround;
	public bool stoppedJumping;
	public bool goingRight;
	public bool goingLeft;

	public Transform groundCheck;
	public float groundCheckRadius;
	private SpriteRenderer mySpriteRenderer;

	public static bool jump;
	public static bool left;
	public static bool right;

	private Rigidbody2D rb2d;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		jumpTimeCounter = jumpTime;
	}

	void Update(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (grounded) {
			jumpTimeCounter = jumpTime;
		}


	}

	void FixedUpdate ()
	{
		// This is designed for keyboard input at the moment.
		moveLeftAndRight = Input.GetAxisRaw ("Horizontal");
		Vector2 moveHorizontal = new Vector2 (moveLeftAndRight, 0);
		rb2d.AddForce (moveHorizontal * speed);
		rb2d.velocity = new Vector2 (moveLeftAndRight, 0);

		jump = Input.GetKey ("w");
		left = Input.GetKey ("a");
		right = Input.GetKey ("d");

		// If I press down the key...
		if (jump == true) {
			if (grounded) {
				rb2d.velocity = new Vector2 (moveLeftAndRight, jumpForce);
				stoppedJumping = false;
				groundCheckRadius = 0f;
			}
		}

		// If I keep holding the key...
		if ((jump == true) && !stoppedJumping){
			if (jumpTimeCounter > 0) {
				rb2d.velocity = new Vector2 (moveLeftAndRight, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}		
		}

		// If I stop holding the key...
		if (jump != true) {
			jumpTimeCounter = 0;
			stoppedJumping = true;
			groundCheckRadius = 0.3f;
		}

		FaceDirection (left, right);

	}

	void FaceDirection(bool left, bool right){
		if (left == true) {
			goingLeft = true;
			mySpriteRenderer.flipX = false;
			goingRight = false;
		}

		if (right == true) {
			goingRight = true;
			goingLeft = false;
			mySpriteRenderer.flipX = true;
		}
	}
}
