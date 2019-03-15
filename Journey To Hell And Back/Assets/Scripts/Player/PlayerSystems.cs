/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 14/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : MonoBehaviour {

	static Rigidbody2D rb2d;
	private float transitionDirection = -1f;
    private float transitionSpeed = 8f;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		// When the player has triggered the next level...
		if (NextLevelTrigger.nextLevelTriggered){
			rb2d.bodyType = RigidbodyType2D.Static;
			transform.Translate(0, transitionDirection * transitionSpeed * Time.deltaTime * 1, 0);
		}
		// This is me cheating, since I'm having problems getting OnTriggerExit2D to trigger while
		// the player gameObject has a static RigidBody2D type.
		if (transform.position.y < -100 && transform.position.y > -110){
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			NextLevelTrigger.nextLevelTriggered = false;
		}
	}

	// When the player takes damage...
	public static void TakeDamage(){
		if(rb2d.bodyType != RigidbodyType2D.Static){
			rb2d.velocity = (new Vector2 (0, 10f));
		}
	}
		
}
