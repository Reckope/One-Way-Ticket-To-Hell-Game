using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour {

	string gameScene = "Game";
	string rulesScene = "Rules";
	string creditsScene = "Credits";
	string mainMenuScene = "Main Menu";

	// Use this for initialization
	void Start () {
		 
		
	}
	
	public void startGameScene(){
		SceneManager.LoadScene(this.gameScene);
	}

	public void startRulesScene(){
		SceneManager.LoadScene(this.rulesScene);
	}

	public void startCreditsScene(){
		SceneManager.LoadScene(this.creditsScene);
	}

	public void startMainMenuScene(){
		SceneManager.LoadScene(this.mainMenuScene);
	}

}
