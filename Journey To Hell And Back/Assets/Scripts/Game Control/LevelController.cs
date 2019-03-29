/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 23/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	// Other Scripts
	public UIController uiController;
	public LevelOne levelOne;
	public LevelTwo levelTwo;
	public LevelThree levelThree;
	public LevelFour levelFour;
	public LevelFive levelFive;

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
		//Debug.Log("Move: " + moveToNextLevel);
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
			Debug.Log("ERROR: Not detected in any level.");
		}
	}

	// Level functions. Create conditions of when the player has completed a level.
	// Each level tells the controller when they're completed, so the controller can then
	// tell other scripts what to do.
	public bool CompletedLevelOne(){
		if(levelOne.LevelOneCompleted() && currentLevel == 1) {
			return true;
		}
		else{
			return false;
		}
	}

	public bool CompletedLevel2(){
		if(levelTwo.LevelTwoCompleted() && currentLevel == 2) {
			return true;
		}
		else{
			return false;
		}
	}

	public bool CompletedLevel3(){
		if(levelThree.LevelThreeCompleted() && currentLevel == 3) {
			return true;
		}
		else{
			return false;
		}
	}

	public bool CompletedLevel4(){
		if(levelFour.LevelFourCompleted() && currentLevel == 4) {
			return true;
		}
		else{
			return false;
		}
	}

	public bool CompletedLevel5(){
		if(levelFive.LevelFiveCompleted() && currentLevel == 5) {
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

		if(collide.gameObject.tag == ("Projectile")){
			Debug.Log("DESTROY");
			Destroy(gameObject);
		}
		}
	// ******* END OF TRIGGERS *******

}
