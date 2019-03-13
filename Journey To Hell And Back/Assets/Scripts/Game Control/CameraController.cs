/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 13/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// This is designed for the transition between Level 1 and 2.
		if (NextLevelTrigger.nextLevelTriggered && transform.position.y > -110){
			MoveCamera();
		}
	}

	// Smoothly move the camera downwards. 
	public void MoveCamera(){
		float direction = -1f;
        float speed = 10f;
        float moveYPosition = direction * speed * Time.deltaTime * 1;

		transform.Translate (0, moveYPosition, 0);
	}
}
