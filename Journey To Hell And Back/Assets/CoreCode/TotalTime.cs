using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalTime : MonoBehaviour{
	public Text totalTimeText;
	public static float totalTime;

	void Start(){

	}

	void Update(){
		StartTimer ();
		DisplayTime ();
	}

	void StartTimer(){
		totalTime += Time.deltaTime;
	}

	void DisplayTime(){
		int minutes = Mathf.FloorToInt(totalTime / 60F);
		int seconds = Mathf.FloorToInt(totalTime - minutes * 60);
		string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

		totalTimeText.text = niceTime;
	}

	void DisplayFinalTime(){
		
	}
}
