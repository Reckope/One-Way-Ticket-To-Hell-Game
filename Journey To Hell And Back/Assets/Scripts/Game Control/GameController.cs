/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 08/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;

	public static int score;

	// Use this for initialization
	void Awake () {
		Application.targetFrameRate = 600;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();

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
