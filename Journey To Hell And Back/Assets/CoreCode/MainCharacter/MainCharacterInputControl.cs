using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterInputControl : MonoBehaviour {

	public GameObject swordLeft;
	public GameObject swordRight;

	public float speed;
	public float jumpForce;
	public float groundDist;
	public int initialExtraJumps;

	private int extraJumps;
	private float moveLeftAndRight;

	public bool grounded;
	public bool stoppedJumping;
	public bool goingRight;
	public bool goingLeft;

	public LayerMask whatIsGround;

	public Transform groundCheck;
	public float groundCheckRadius;
	private SpriteRenderer mySpriteRenderer;
	private BoxCollider2D myBoxCollider;

	public static bool jump;
	public static bool left;
	public static bool right;
	public bool swingSword;

	private Rigidbody2D rb2d;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		mySpriteRenderer = GetComponent<SpriteRenderer>();

	}

	void Update(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	void FixedUpdate ()
	{
		// This is designed for keyboard input at the moment.
		jump = Input.GetKeyDown (KeyCode.W);
		swingSword = Input.GetKey (KeyCode.Space);
		moveLeftAndRight = Input.GetAxisRaw ("Horizontal");
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

		if (swingSword) {
			StartCoroutine (SwingSword ());
		}
			
	}

	public void FaceDirection(){
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

	public IEnumerator SwingSword(){

		if (goingLeft && swingSword) {
			swordRight.SetActive (false);
			swordLeft.SetActive (true);
			yield return new WaitForSeconds (0.25f);
			swordLeft.SetActive (false);
		} else if (goingRight && swingSword) {
			swordLeft.SetActive (false);
			swordRight.SetActive (true);
			yield return new WaitForSeconds (0.25f);
			swordRight.SetActive (false);
		}

	}
}
