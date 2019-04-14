/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is used to control the rules section within the Rules scene.
 * Code QA Sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesController : MonoBehaviour {

	// GameObjects
	public GameObject controlsUI;
	public GameObject generalUI;
	public GameObject environmentUI;
	public GameObject objectivesUI;

	// Use this for initialization
	void Start () {
		generalUI.SetActive(true);
		objectivesUI.SetActive(false);
		environmentUI.SetActive(false);
		controlsUI.SetActive(false);
	}

	// Display the controls UI
	public void DisplayControls(){
		generalUI.SetActive(false);
		objectivesUI.SetActive(false);
		environmentUI.SetActive(false);
		controlsUI.SetActive(true);
	}

	// Display the general overview UI
	public void DisplayGeneral(){
		generalUI.SetActive(true);
		objectivesUI.SetActive(false);
		environmentUI.SetActive(false);
		controlsUI.SetActive(false);
	}

	// Display the environment overview UI
	public void DisplayEnvironment(){
		generalUI.SetActive(false);
		objectivesUI.SetActive(false);
		environmentUI.SetActive(true);
		controlsUI.SetActive(false);
	}

	// Display the objectives overview UI
	public void DisplayObjectives(){
		generalUI.SetActive(false);
		objectivesUI.SetActive(true);
		environmentUI.SetActive(false);
		controlsUI.SetActive(false);
	}
}
