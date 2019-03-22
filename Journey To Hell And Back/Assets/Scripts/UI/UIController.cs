using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

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
		DisableUIDuringTransition();
	}

	public void DisableUIDuringTransition(){
		if(NextLevelTrigger.nextLevelTriggered){
			playerStatsUI.SetActive(false);
            gameUpdatesUI.SetActive(false);
		}
		else if(!NextLevelTrigger.nextLevelTriggered){
			playerStatsUI.SetActive(true);
			gameUpdatesUI.SetActive(true);
		}
	}

	public IEnumerator DisplayNextLevelHelpText(){
		helpTextContainer.SetActive(true);
		helpText.text = "Level complete! Jump down the hole to progress onto the next level.";
		yield return new WaitForSeconds(5);
		helpTextContainer.SetActive(false);
	}
}
