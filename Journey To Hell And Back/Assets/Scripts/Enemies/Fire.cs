/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is used for the fire, encountered on level 5. 
 * Code QA sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	// Scripts
	public LevelController LevelController;
	public UIController UIController;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2(5.5f, -442.544f);
	}

	// Update is called once per frame
	void Update () {
		// If the player has reached level 5...
		if(LevelController.currentLevel == 5 && !GameController.instance.GameOver() && !LevelController.CompletedLevel5() && gameObject != null){
			// Move the fire.
			if(transform.position.x > -12f){
				transform.Translate(-3.5f * Time.deltaTime, 0, 0);
			}
			else 
			transform.position = new Vector2(4f, -442.544f);
		}
		// Destroy once player completes level 5. 
		else if(LevelController.CompletedLevel5()){
			Destroy(gameObject);
		}
	}

	// If the fire touches the Player...
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == ("Player")) {
			PlayerSystems.playerIsDead = true;
		}
	}
}
