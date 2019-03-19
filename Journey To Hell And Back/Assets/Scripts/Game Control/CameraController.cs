/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 19/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	GameObject mainCamera;

    // Use this for initialization
    void Start () {
		mainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (NextLevelTrigger.nextLevelTriggered){
			CameraTransitionBetweenLevels();
		}
	}

	// Smoothly move the camera downwards. 
	public void MoveCamera(){
		float direction = -1f;
        float speed = 10f;
        float moveYPosition = direction * speed * Time.deltaTime * 1;

		transform.Translate (0, moveYPosition, 0);
	}

	// Transition the camera between each level
	private void CameraTransitionBetweenLevels(){
		if(LevelController.currentLevel == 1){
			if(transform.position.y > -110){
				MoveCamera();
				if(transform.position.y <= -110){
					mainCamera.transform.position = new Vector3(0, -110f, -10);
				}
			}
		}
		else if(LevelController.currentLevel == 2){
			if(transform.position.y > -220){
				MoveCamera();
				if(transform.position.y <= -220){
					mainCamera.transform.position = new Vector3(0, -220f, -10);
				}
			}
		}
	}
}
