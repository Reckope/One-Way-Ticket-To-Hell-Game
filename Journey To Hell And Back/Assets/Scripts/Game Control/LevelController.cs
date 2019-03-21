/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 20/03/19
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
		Debug.Log("In Level " + levelStaying);
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

	// If the player exits the level...
	private void OnTriggerExit2D(Collider2D collide)
     {
         if (collide.gameObject.tag == ("Player")){
             levelStaying = false;
         }
     }

	// Find which level is currently active.
	 private void DetectWhichLevel(){
		 	if(gameObject.name == "Level1"){
            	currentLevel = 1;
			}
			else if(gameObject.name == "Level2"){
            	currentLevel = 2;
			}
			else if(gameObject.name == "Level3"){
            	currentLevel = 3;
			}
			else if(gameObject.name == "Level4"){
            	currentLevel = 4;
			}
			else if(gameObject.name == "Level5"){
            	currentLevel = 5;
			}
			else{
				Debug.Log("ERROR: Couldn't find Level GameObject.");
			}
	 }

	// Level functions. Create conditions of when the player has completed a level.
	public bool CompletedLevel1(){
		 return true;
	}

	public bool CompletedLevel2(){
		 return true;
	}

	public bool CompletedLevel3(){
		 return true;
	}

	public bool CompletedLevel4(){
		 return true;
	}

	public bool CompletedLevel5(){
		 return true;
	}

}
