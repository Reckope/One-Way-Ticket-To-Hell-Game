using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterInputControl : MonoBehaviour {

	public float speed;
	public float jumpForce;
	public float jumpTime;
	public float jumpTimeCounter;
	public float groundDist;
	public int initialExtraJumps;

	private int extraJumps;
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
		jump = Input.GetKeyDown (KeyCode.UpArrow);
		left = Input.GetKey (KeyCode.A);
		right = Input.GetKey (KeyCode.D);
		moveLeftAndRight = Input.GetAxisRaw ("Horizontal");
		rb2d.velocity = new Vector2 (moveLeftAndRight * speed, rb2d.velocity.y);
		checkGround();

		// If I press down the key...
		if (jump) {
			if (grounded) {
				rb2d.velocity = Vector2.up * jumpForce;
				stoppedJumping = false;
			}
		}

		// If I keep holding the key...
		if ((jump) && !stoppedJumping){
			if (jumpTimeCounter > 0) {
				//rb2d.velocity = new Vector2 (moveLeftAndRight, jumpForce);
				rb2d.velocity = (new Vector2 (0, jumpForce));
				jumpTimeCounter -= Time.deltaTime;
			}		
		}

		// If I stop holding the key...
		if (!jump) {
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}
			
		FaceDirection (left, right);
		DoubleJump ();
	}

	void FaceDirection(bool left, bool right){
		if (left) {
			goingLeft = true;
			mySpriteRenderer.flipX = false;
			goingRight = false;
		}

		if (right) {
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

	//Shoot a ray out of the bottom to see if the distance is within a certain tolerance.
	void checkGround(){
		RaycastHit hit;

		if(Physics.Raycast (transform.position, Vector3.down,out hit, Mathf.Infinity)){
			if(hit.distance < groundDist){
				grounded = true;
			}
			else{
				grounded = false;
			}
		}
	}
}
