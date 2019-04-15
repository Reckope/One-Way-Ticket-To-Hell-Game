/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is an intermediary script used to control the UI within the game.
 * UI objects should flow through here. 
 * Code QA Sweep: DONE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	GameObject mainCamera;
	GameObject player;

	// Other Scripts
	public CinematicBars cinematicBars;
	public LevelController LevelController;

	// Canvas's
	public GameObject playerStatsUI;
	public GameObject gameUpdatesUI;
	public GameObject playerControls;
	public GameObject finishGame;
	public GameObject gameOver;

	// UI Objects
	public GameObject helpTextContainer;
	public Text finalScore;
	public Text finalTime;
	public Text finalScoreGameOver;
	public Text finalTimeGameOver;
	public Text deathReason;
	public Text currentLevel;
	public Text ticketsRemaining;

	// UI Text
	public Text helpText;

	// Global Variables
	public static string deathReasonString;

	// Use this for initialization
	void Start () {
		playerStatsUI.SetActive(true);
		gameUpdatesUI.SetActive(true);
		playerControls.SetActive(true);
		finishGame.SetActive(false);
		gameOver.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("game Over " + GameController.instance.finishGame);
		mainCamera = GameObject.Find("Main Camera");
		player = GameObject.Find("Player");
		GameController.instance.scoreText.text = GameController.score.ToString();
		if(!GameController.instance.GameOver()){
			currentLevel.text = "Current Level: " + LevelController.currentLevel;
			ticketsRemaining.text = "Tickets Remaining: " + LevelController.CurrentLevelTicketQuantity();
			if(GameController.instance.finishGame){
				TransitionUI();
				if(player.transform.position.y > 1){
					FinishGameUI();
				}
			}
			else

			if(NextLevelTrigger.nextLevelTriggered){
				TransitionUI();
			}
			else if(!NextLevelTrigger.nextLevelTriggered){
				PlayingUI();
			}
		}
		else
		GameOverUI();
	}

	// Disables the UI during transition
	public void TransitionUI(){
		cinematicBars.ShowCinematicBars();
		playerStatsUI.SetActive(false);
    	gameUpdatesUI.SetActive(false);
		playerControls.SetActive(false);
	}

	// Enables the UI after transition
	public void PlayingUI(){
		cinematicBars.HideCinematicBars();
		if(cinematicBars.topBar.sizeDelta.y <= 15f){
			playerStatsUI.SetActive(true);
			gameUpdatesUI.SetActive(true);
			playerControls.SetActive(true);
		}
	}

	//UI for when the game is finished
	public void FinishGameUI(){
		cinematicBars.HideCinematicBars();
		playerStatsUI.SetActive(false);
		playerControls.SetActive(false);
		gameUpdatesUI.SetActive(false);
		finishGame.SetActive(true);
		finalScore.text = "<color=blue>" + "Score: " + "</color>" + GameController.score;
		finalTime.text = "<color=red>" + "Time: " + "</color>" + TotalTime.niceTime;
	}

	// Displays the Game Over UI.
	public void GameOverUI(){
		gameOver.SetActive(true);
		deathReason.text = deathReasonString;
		finalScoreGameOver.text = "<color=cyan>" + "Score: " + "</color>" + GameController.score;
		finalTimeGameOver.text = "<color=red>" + "Time: " + "</color>" + TotalTime.niceTime;
		playerStatsUI.SetActive(false);
		playerControls.SetActive(false);
		gameUpdatesUI.SetActive(false);
		finishGame.SetActive(false);
	}

	// Displays Help text
	public IEnumerator DisplayHelpText(string helpTextChoice){
		switch(helpTextChoice){
			case "Jump_Down_Hole":
				GameController.helpTextMessage = "Level complete! Jump down the hole to progress onto the next level.";
			break;
			case "Killed_Satan":
				GameController.helpTextMessage = "Satan is defeated! Collect the wings to fly out of hell.";
			break;
			default:
				GameController.helpTextMessage = "HELP_TEXT_MISSING";
			break;
		}
		helpTextContainer.SetActive(true);
		helpText.text = GameController.helpTextMessage;
		yield return new WaitForSeconds(5);
		helpTextContainer.SetActive(false);
	}

	// Sets the Death Reason String based on how the player died. 
	public void SelectDeathReason(string deathReason){
		switch(deathReason){
			case "Killed_By_Fire":
				deathReasonString = "You were burnt by satans fire!";
			break;
			case "Killed_By_Satan":
				deathReasonString = "You were slayed by Satan himself!";
			break;
			case "Killed_By_Reaper":
				deathReasonString = "You were sliced by a Reaper!";
			break;
			case "Killed_By_Demon":
				deathReasonString = "You were stabbed by a Demon!";
			break;
			default:
				deathReasonString = "You died!";
			break;
		}
	}
}
