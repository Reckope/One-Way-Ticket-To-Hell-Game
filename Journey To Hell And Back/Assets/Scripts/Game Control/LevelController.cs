/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 22/03/19
 * THIS IS WORKING
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	// Other Scripts
	public UIController uiController;

    // Global Variables
    public const int LEVEL_1_Y_POSITION = 0;
	public const int LEVEL_2_Y_POSITION = -110;
	public const int LEVEL_3_Y_POSITION = -220;
	public const int LEVEL_4_Y_POSITION = -330;
	public const int LEVEL_5_Y_POSITION = -440;

    public static int currentLevel;
	public static bool levelStaying;
	public bool levelEntered;
	public bool moveToNextLevel;

    void Start(){
		moveToNextLevel = false;
	}

	void Update(){
		//Debug.Log("In Level " + levelStaying);
		Debug.Log("Move: " + moveToNextLevel);
	}

	// Find which level the player is currently active.
	 private void DetectWhichLevel(){
	 	if(gameObject.name == "Level1"){
			currentLevel = 1;
		}
		else if(gameObject.name == "Level2"){
			GameController.preventLoop = false;
			currentLevel = 2;
		}
		else if(gameObject.name == "Level3"){
			GameController.preventLoop = false;
			currentLevel = 3;
		}
		else if(gameObject.name == "Level4"){
			GameController.preventLoop = false;
			currentLevel = 4;
		}
		else if(gameObject.name == "Level5"){
			GameController.preventLoop = false;
			currentLevel = 5;
		}
		else{
			Debug.Log("ERROR: Couldn't find Level GameObject.");
		}
	 }

	// Level functions. Create conditions of when the player has completed a level.
	// Temporary. Planning to have a much more complex way of determining when to progress onto the next level.
	public bool CompletedLevel1(){
		if(GameController.score >= 3 && currentLevel == 1) {
            return true;
        }
		else{
			return false;
		}
	}

	public bool CompletedLevel2(){
		 if(GameController.score >= 6 && currentLevel == 2) {
            return true;
        }
		else{
			return false;
		}
	}

	public bool CompletedLevel3(){
		 if(GameController.score >= 9 && currentLevel == 3) {
            return true;
        }
		else{
			return false;
		}
	}

	public bool CompletedLevel4(){
		 if(GameController.score >= 12 && currentLevel == 4) {
            return true;
        }
		else{
			return false;
		}
	}

	public bool CompletedLevel5(){
		 if(GameController.score >= 15 && currentLevel == 5) {
            return true;
        }
		else{
			return false;
		}
	}

	// ******* TRIGGERS *******
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
	 // ******* END OF TRIGGERS *******

}
