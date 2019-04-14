/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is used to switch between each scene.
 * Code QA sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseScene : MonoBehaviour {

	// Gameobjects and Components
	public Text loadingText;

	// Global Variables
	string gameScene = "Game";
	string rulesScene = "Rules";
	string creditsScene = "Credits";
	string mainMenuScene = "Main Menu";

	// Use this for initialization
	void Start(){
		if(loadingText != null){
			loadingText.text = " ";
		}
	}

	// Start the Game
	public void StartGameScene(){
		SceneManager.LoadScene(this.gameScene);
		if(loadingText != null){
			loadingText.text = "Loading...";
		}
	}

	// Show rules
	public void StartRulesScene(){
		SceneManager.LoadScene(this.rulesScene);
	}

	// Show credits
	public void StartCreditsScene(){
		SceneManager.LoadScene(this.creditsScene);
	}

	// Show main menu
	public void StartMainMenuScene(){
		SceneManager.LoadScene(this.mainMenuScene);
	}
}