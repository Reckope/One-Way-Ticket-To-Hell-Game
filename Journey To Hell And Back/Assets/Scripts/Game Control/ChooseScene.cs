/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 30/03/19
 * Code QA sweep: DONE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour {

	string gameScene = "Game";
	string rulesScene = "Rules";
	string creditsScene = "Credits";
	string mainMenuScene = "Main Menu";
	
	public void StartGameScene(){
		SceneManager.LoadScene(this.gameScene);
	}

	public void StartRulesScene(){
		SceneManager.LoadScene(this.rulesScene);
	}

	public void StartCreditsScene(){
		SceneManager.LoadScene(this.creditsScene);
	}

	public void StartMainMenuScene(){
		SceneManager.LoadScene(this.mainMenuScene);
	}
}
