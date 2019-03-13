/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 13/03/19
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
			Debug.Log("NEXT_LEVEL_PLAYER");
			rb2d.bodyType = RigidbodyType2D.Static;
			transform.Translate(0, transitionDirection * transitionSpeed * Time.deltaTime * 1, 0);
		}else{
			rb2d.bodyType = RigidbodyType2D.Dynamic;
		}
	}

	// When the player takes damage...
	public static void TakeDamage(){
		if(rb2d.bodyType != RigidbodyType2D.Static){
			rb2d.velocity = (new Vector2 (0, 10f));
		}
	}
		
}
