/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 14/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static int currentLevel;
	public static int previousLevel;

	private bool inTrigger;

	void Update(){
		Debug.Log("InTrigger:" + inTrigger);
		// If the player has triggered the levels...
		if(inTrigger){
			if(gameObject.name == "Level1"){
            	currentLevel = 1;
				previousLevel = 0;
			}
			else if(gameObject.name == "Level2"){
            	currentLevel = 2;
				previousLevel = 1;
			}
			else if(gameObject.name == "Level3"){
            	currentLevel = 3;
				previousLevel = 2;
			}
			else if(gameObject.name == "Level4"){
            	currentLevel = 4;
				previousLevel = 3;
			}
			else{
				// Error Management. Respawn player to level 1 (future improvements)
			}
		}
	}

	// Each level background image has a BoxCollider (trigger). This detects what zone the player
	// is currently in.
	void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.layer == LayerMask.NameToLayer("player")){
			inTrigger = true;
        }
    }

	void OnTriggerExit2D(Collider2D collide)
     {
         if (collide.gameObject.layer == LayerMask.NameToLayer("player")){
             inTrigger = false;
         }
     }
}
