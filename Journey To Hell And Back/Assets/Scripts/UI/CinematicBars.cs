/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * Reference: [3]
 * Black bars are created via this script instead of using game objects. This
 * can be useful for future projects :) All you need to do is call ShowCinematicBars or HideCinematicBars (High Cohesion!).
 * Code QA Sweep: DONE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicBars : MonoBehaviour {

	public RectTransform topBar, bottomBar;
	private float changeSizeAmount;
	private float targetSize;
	private float barSpeed;
	public bool isActive;

	// Use this for initialization
	void Start () {
		CreateBars();
		barSpeed = 0.3f;
	}
	
	// Update is called once per frame
	private void Update () {
		if(isActive && !GameController.instance.GameOver()){
			Vector2 sizeDelta = topBar.sizeDelta;
			sizeDelta.y += changeSizeAmount * Time.deltaTime;
			if(changeSizeAmount > 0){
				if(sizeDelta.y >= targetSize){
					sizeDelta.y = targetSize;
					isActive = false;
				}
			}
			else{
				if(sizeDelta.y <= targetSize){
					sizeDelta.y = targetSize;
					isActive = false;
				}
			}
			topBar.sizeDelta = sizeDelta;
			bottomBar.sizeDelta = sizeDelta;
		}
	}

	// Display the cinematic bars
	public void ShowCinematicBars(){
		float targetSize = 300f;
		this.targetSize = targetSize;
		changeSizeAmount = (targetSize - topBar.sizeDelta.y) / barSpeed;
		isActive = true;
	}

	// Hide the cinematic bars
	public void HideCinematicBars(){
		targetSize = 0f;
		changeSizeAmount = (targetSize - topBar.sizeDelta.y) / barSpeed;
		isActive = true;
	}


	// Create the bars of the cinematic cam
	private void CreateBars(){
		GameObject barsObject = new GameObject("topBar", typeof(Image));
		barsObject.transform.SetParent(transform, false); // Scales the parent size in order to maintain this objects size.
		barsObject.GetComponent<Image>().color = Color.black;
		topBar = barsObject.GetComponent<RectTransform>();
		topBar.anchorMin = new Vector2(0,1);
		topBar.anchorMax = new Vector2(1,1);
		topBar.sizeDelta = new Vector2(0,0);

		barsObject = new GameObject("bottomBar", typeof(Image));
		barsObject.transform.SetParent(transform, false);
		barsObject.GetComponent<Image>().color = Color.black;
		bottomBar = barsObject.GetComponent<RectTransform>();
		bottomBar.anchorMin = new Vector2(0,0);
		bottomBar.anchorMax = new Vector2(1,0);
		bottomBar.sizeDelta = new Vector2(0,0);
	}
}
