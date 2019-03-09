/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 08/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Application.targetFrameRate = 600;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameOver()){
			Debug.Log ("GAMEOVERTEST");
		}
	}

	bool GameOver(){
		if (PlayerHealth.currentHealth <= 0) {
			return true;
		} 
		else {
			return false;
		}
	}
}
