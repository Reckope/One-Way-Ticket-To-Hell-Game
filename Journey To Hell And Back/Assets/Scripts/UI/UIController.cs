/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 23/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	GameObject mainCamera;

	// UI Scripts
	public CinematicBars cinematicBars;

	// Canvas's
	public GameObject playerStatsUI;
	public GameObject gameUpdatesUI;

	// UI Objects
	public GameObject helpTextContainer;

	// UI Text
	public Text helpText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		mainCamera = GameObject.Find("Main Camera");
		//Debug.Log("Camera Pos: " + mainCamera.transform.position.y);
		if(!GameController.instance.GameOver()){
			if(GameController.instance.finishGame){
				TransitionUI();
				if(mainCamera.transform.position.y > -2){
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
	}

	// Disables the UI during transition
	public void TransitionUI(){
		cinematicBars.ShowCinematicBars();
		playerStatsUI.SetActive(false);
    	gameUpdatesUI.SetActive(false);
	}

	// Enables the UI after transition
	public void PlayingUI(){
		cinematicBars.HideCinematicBars();
		if(cinematicBars.topBar.sizeDelta.y <= 15f){
			playerStatsUI.SetActive(true);
			gameUpdatesUI.SetActive(true);
		}
	}

	//UI for when the game is finished
	public void FinishGameUI(){
		cinematicBars.HideCinematicBars();
		playerStatsUI.SetActive(false);
    	gameUpdatesUI.SetActive(false);
	}

	// Display Help text
	public IEnumerator DisplayHelpText(){
		helpTextContainer.SetActive(true);
		helpText.text = "Level complete! Jump down the hole to progress onto the next level.";
		yield return new WaitForSeconds(5);
		helpTextContainer.SetActive(false);
	}
}
