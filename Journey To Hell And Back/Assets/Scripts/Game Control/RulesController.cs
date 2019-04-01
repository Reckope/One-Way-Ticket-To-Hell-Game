using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesController : MonoBehaviour {

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

	public void DisplayControls(){
		generalUI.SetActive(false);
		objectivesUI.SetActive(false);
		environmentUI.SetActive(false);
		controlsUI.SetActive(true);
	}

	public void DisplayGeneral(){
		generalUI.SetActive(true);
		objectivesUI.SetActive(false);
		environmentUI.SetActive(false);
		controlsUI.SetActive(false);
	}

	public void DisplayEnvironment(){
		generalUI.SetActive(false);
		objectivesUI.SetActive(false);
		environmentUI.SetActive(true);
		controlsUI.SetActive(false);
	}

	public void DisplayObjectives(){
		generalUI.SetActive(false);
		objectivesUI.SetActive(true);
		environmentUI.SetActive(false);
		controlsUI.SetActive(false);
	}
}
