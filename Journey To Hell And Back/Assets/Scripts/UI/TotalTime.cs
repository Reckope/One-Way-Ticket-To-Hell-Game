using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalTime : MonoBehaviour{
	public Text totalTimeText;
	public static float totalTime;
	public static string niceTime;

	void Start(){
		totalTime = 0;
	}

	void Update(){
		StartTimer ();
		DisplayTime ();
	}

	void StartTimer(){
		if(!GameController.instance.GameOver() || GameController.instance.finishGame){
			totalTime += Time.deltaTime;
		}
	}

	void DisplayTime(){
		int minutes = Mathf.FloorToInt(totalTime / 60F);
		int seconds = Mathf.FloorToInt(totalTime - minutes * 60);
		niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

		totalTimeText.text = niceTime;
	}
}
