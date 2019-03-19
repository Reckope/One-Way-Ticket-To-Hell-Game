/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 19/03/19
 * THIS IS WORKING
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	// Global Variables
	public static int currentLevel;
	public static bool levelStaying;
	public bool levelEntered;

	void Start(){
		
	}

	void Update(){
		//Debug.Log("In Level " + levelStaying);
		Debug.Log("Current" + currentLevel);
	}

	// Each level background image has a BoxCollider (trigger). This method detects what zone
	// the player enters.
	private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == ("Player")){
			DetectWhichLevel();
        }
    }

	// If the player is in the level...
	private void OnTriggerStay2D(Collider2D collide){
		if (collide.gameObject.tag == ("Player")){
			levelStaying = true;
        }
	}

	private void OnTriggerExit2D(Collider2D collide)
     {
         if (collide.gameObject.tag == ("Player")){
             levelStaying = false;
         }
     }

	 private void DetectWhichLevel(){
		 	if(gameObject.name == "Level1"){
            	currentLevel = 1;
				//previousLevel = 0;
			}
			else if(gameObject.name == "Level2"){
            	currentLevel = 2;
				//previousLevel = 1;
			}
			else if(gameObject.name == "Level3"){
            	currentLevel = 3;
				//previousLevel = 2;
			}
			else if(gameObject.name == "Level4"){
            	currentLevel = 4;
				//previousLevel = 3;
			}
			else{
				// Error Management. Respawn player to level 1 (future improvements)
			}
	 }
}
