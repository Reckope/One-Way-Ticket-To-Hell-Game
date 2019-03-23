/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 23/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : MonoBehaviour {

	public LevelController levelController;
	public CinematicBars cinematicBars;

	static Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(NextLevelTrigger.nextLevelTriggered){
			PlayerTransitionBetweenLevels();
		}
		else if(GameController.instance.finishGame){
			PlayerFinishGame();
		}
	}

	// When the player takes damage...
	public static void TakeDamage(){
		if(rb2d.bodyType != RigidbodyType2D.Static){
			rb2d.velocity = (new Vector2 (0, 10f));
		}
	}

	// When the player has triggered the next level... (player is transitioning)
	public void PlayerTransitionBetweenLevels(){
		float transitionDirection = -1f;
    	float transitionSpeed = 8.5f;

		rb2d.bodyType = RigidbodyType2D.Static;
		transform.Translate(0, transitionDirection * transitionSpeed * Time.deltaTime * 1, 0);

		// This is me cheating, since I'm having problems getting OnTriggerExit2D to trigger while
		// the player gameObject has a static RigidBody2D type.
		// Level 1 - 2...
		if (transform.position.y > -110 && transform.position.y < -100){
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			NextLevelTrigger.nextLevelTriggered = false;
		}
		// Level 2 - 3...
		else if (transform.position.y > -220 && transform.position.y < -210){
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			NextLevelTrigger.nextLevelTriggered = false;
		}
		// Level 3 - 4...
		else if (transform.position.y > -330 && transform.position.y < -320){
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			NextLevelTrigger.nextLevelTriggered = false;
		}
		// Level 4 - 5...
		else if (transform.position.y > -440 && transform.position.y < -430){
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			NextLevelTrigger.nextLevelTriggered = false;
		}
		else{
			//Debug.Log("TRANSITIONING");
		}
	}

	public void PlayerFinishGame(){
		float transitionDirection = 1f;
    	float transitionSpeed = 18f;
		if(transform.position.y < 0){
			rb2d.bodyType = RigidbodyType2D.Static;
			transform.Translate(0, transitionDirection * transitionSpeed * Time.deltaTime * 1, 0);
		}
		if(transform.position.y >= 0){
			transform.position = new Vector2(transform.position.x, 0);
		}
	}
		
}
