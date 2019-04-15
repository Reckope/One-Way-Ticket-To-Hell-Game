/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is used for displaying the Time. 
 * Code QA Sweep: DONE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalTime : MonoBehaviour{
	// Components & GameObjects
	public Text totalTimeText;

	// Global Variables
	public static float totalTime;
	public static string niceTime;

	// Use this for initialization
	void Start(){
		totalTime = 0;
	}

	// Update is called once per frame
	void Update(){
		StartTimer ();
		DisplayTime ();
	}

	// Start the timer
	void StartTimer(){
		if(!GameController.instance.GameOver() || GameController.instance.finishGame){
			totalTime += Time.deltaTime;
		}
	}

	// Display the timer
	void DisplayTime(){
		int minutes = Mathf.FloorToInt(totalTime / 60F);
		int seconds = Mathf.FloorToInt(totalTime - minutes * 60);
		niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

		totalTimeText.text = niceTime;
	}
}
