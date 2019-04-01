/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 30/03/19
 * Code QA sweep: DONE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	// Scripts
	public LevelController levelControl;
	public CinematicBars cinematicBars;

	// GameObjects & Components.
	public static Vector2 cameraCurrentPosition;
	GameObject mainCamera;

	// Global Variables
	public const int CAMERA_Z_COORDINATE = -10;
	private bool cameraLeft;
	private bool cameraRight;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("Main Camera");
		cameraLeft = false;
		cameraRight = false;
	}

	// Update is called once per frame
	void Update (){
		// While the game is active.
		if(!GameController.instance.GameOver()){
			// If the player completes the game.
			if(GameController.instance.finishGame){
				CameraFinishGame();
			}
			else if(!GameController.instance.finishGame){
				cameraCurrentPosition = transform.position;
				// If the player triggers the next level.
				if(NextLevelTrigger.nextLevelTriggered){
					CameraTransitionBetweenLevels();
				}
				// Create camera bounds. 
				SetCameraBounds();
				// If the camera is within bounds, move with player. 
				if(transform.position.x >= -14.1f && transform.position.x <= 14.1f && LevelController.currentLevel != 5){
					if(cameraLeft == true){
						MoveCameraLeft();
					}
					else if(cameraRight == true){
						MoveCameraRight();
					}
				}
				// Move the camera to the center when the level has been completed. 
				if(levelControl.moveToNextLevel && GameController.instance.CalculateDistanceBetweenPlayerAndCenter() < 10f){
					MoveCameraToCenter();
					GameController.instance.ActivateSmallerBounds();
				}
			}
		}
	}

	// Makes sure the camera doesn't go too far left or right.
	void SetCameraBounds(){
		float cameraYPosition;

		// Match the Y coordinate of the camera to the current level. 
		switch(LevelController.currentLevel){
			case 5:
				cameraYPosition = LevelController.LEVEL_5_Y_POSITION;
			break;
			case 4:
				cameraYPosition = LevelController.LEVEL_4_Y_POSITION;
			break;
			case 3:
				cameraYPosition = LevelController.LEVEL_3_Y_POSITION;
			break;
			case 2:
				cameraYPosition = LevelController.LEVEL_2_Y_POSITION;
			break;
			case 1:
				cameraYPosition = LevelController.LEVEL_1_Y_POSITION;
			break;
			default:
				cameraYPosition = LevelController.LEVEL_1_Y_POSITION;
			break;
		}

		// Stop the camera once it reaches the edge of the level. 
		if(transform.position.x < -14.1f){
			mainCamera.transform.position = new Vector3(-14.1f, cameraYPosition, CAMERA_Z_COORDINATE);
		}
		if(transform.position.x > 14.1f){
			mainCamera.transform.position = new Vector3(14.1f, cameraYPosition, CAMERA_Z_COORDINATE);
		}
	}

	// Transition the camera between each level.
	private void CameraTransitionBetweenLevels(){
		// Detect the current level.
		if(LevelController.currentLevel == 1){
			// Detect if the cameras position is not at the next level, then move it there. 
			if(transform.position.y > LevelController.LEVEL_2_Y_POSITION){
				MoveCameraDown();
				// Stop the camera at the next level. 
				if(transform.position.y <= LevelController.LEVEL_2_Y_POSITION){
					mainCamera.transform.position = new Vector3(0, LevelController.LEVEL_2_Y_POSITION, CameraController.CAMERA_Z_COORDINATE);
				}
			}
		}
		else if(LevelController.currentLevel == 2){
			if(transform.position.y > LevelController.LEVEL_3_Y_POSITION){
				MoveCameraDown();
				if(transform.position.y <= LevelController.LEVEL_3_Y_POSITION){
					mainCamera.transform.position = new Vector3(0, LevelController.LEVEL_3_Y_POSITION, CameraController.CAMERA_Z_COORDINATE);
				}
			}
		}
		else if(LevelController.currentLevel == 3){
			if(transform.position.y > LevelController.LEVEL_4_Y_POSITION){
				MoveCameraDown();
				if(transform.position.y <= LevelController.LEVEL_4_Y_POSITION){
					mainCamera.transform.position = new Vector3(0, LevelController.LEVEL_4_Y_POSITION, CameraController.CAMERA_Z_COORDINATE);
				}
			}
		}
		else if(LevelController.currentLevel == 4){
			if(transform.position.y > LevelController.LEVEL_5_Y_POSITION){
				MoveCameraDown();
				if(transform.position.y <= LevelController.LEVEL_5_Y_POSITION){
					mainCamera.transform.position = new Vector3(0, LevelController.LEVEL_5_Y_POSITION, CameraController.CAMERA_Z_COORDINATE);
				}
			}
		}
		else if(LevelController.currentLevel == 5){
			mainCamera.transform.position = new Vector3(0, LevelController.LEVEL_5_Y_POSITION, CameraController.CAMERA_Z_COORDINATE);
		}
	}

	// Smoothly move the camera downwards during cutscene. 
	public void MoveCameraDown(){
		float direction = -1f;
		float speed = 3.5f;
		float moveYPosition = direction * speed * Time.deltaTime * 1;

		mainCamera.transform.Translate (0, moveYPosition, 0);
	}

	// Move the camera left when the player goes left.
	// Speed of the camera is based off the speed of the player (prevents jitter, and it's cool).
	void MoveCameraLeft(){
		float direction = -1f;
		float speed;
		float moveXPosition;

		// If the player is moving left...
		if(PlayerInputControl.playerSpeedValue < 0){
			speed = PlayerInputControl.playerSpeedValue * -7f;
		}
		else{
			speed = 0;
		}
		moveXPosition = direction * speed * Time.deltaTime * 1;
		mainCamera.transform.Translate (moveXPosition, 0, 0);
	}

	// Move the camera right when the player goes right.
	// Speed of the camera is based off the speed of the player (prevents jitter).
	void MoveCameraRight(){
		float direction = 1f;
		float speed;
		float moveXPosition;

		// If the player is moving right...
		if(PlayerInputControl.playerSpeedValue > 0){
			speed = PlayerInputControl.playerSpeedValue * 7f;
		}
		else{
			speed = 0;
		}
		moveXPosition = direction * speed * Time.deltaTime * 1f;
		//float moveXPosition = Mathf.SmoothDamp(transform.position.x, 14.1f, ref xVelocity, 0.3f, 6f);
		mainCamera.transform.Translate (moveXPosition, 0, 0);
	}

	// Moves the camera to the center before transitioning to next level.
	public void MoveCameraToCenter(){
		float cameraSpeed = 3f;
		float position = cameraCurrentPosition.x;

		// Determine which side of the hole (at the center of level) the camera currently is.
		if(position < 0f){
			position += cameraSpeed * Time.deltaTime * 1;
		}
		if (position > 0f){
			position -= cameraSpeed * Time.deltaTime * 1;
		}
		else if(position == 0){
			position = 0;
		}

		// Then move the camera based on which level has just been completed.
		if(levelControl.CompletedLevelOne()){
			mainCamera.transform.position = new Vector3(position, LevelController.LEVEL_1_Y_POSITION, CAMERA_Z_COORDINATE);
		}
		else if(levelControl.CompletedLevel2()){
			mainCamera.transform.position = new Vector3(position, LevelController.LEVEL_2_Y_POSITION, CAMERA_Z_COORDINATE);
		}
		else if(levelControl.CompletedLevel3()){
			mainCamera.transform.position = new Vector3(position, LevelController.LEVEL_3_Y_POSITION, CAMERA_Z_COORDINATE);
		}
		else if(levelControl.CompletedLevel4()){
			mainCamera.transform.position = new Vector3(position, LevelController.LEVEL_4_Y_POSITION, CAMERA_Z_COORDINATE);
		}
		else if(levelControl.CompletedLevel5()){
			mainCamera.transform.position = new Vector3(position, LevelController.LEVEL_5_Y_POSITION, CAMERA_Z_COORDINATE);
		}
		else{
			//Debug.Log("Not completed any levels.");
		}
	}

	// Camera moves up and watches the player fly away! 
	public void CameraFinishGame(){
		float direction = 1f;
		float speed = 6f;
		float moveYPosition = direction * speed * Time.deltaTime * 1;

		// Fly up until the camera reaches level 1's position.
		if(transform.position.y < LevelController.LEVEL_1_Y_POSITION){
			mainCamera.transform.Translate (0, moveYPosition, 0);
		}
	}

	// ******* TRIGGERS *******
	// Detect when the player hits the left or right trigger...
	void OnTriggerEnter2D(Collider2D collide){
		if (collide.gameObject.tag == ("Player") && gameObject.name == "CameraLeftTrigger"){
			cameraLeft = true;
			cameraRight = false;
		}
		else if(collide.gameObject.tag == ("Player") && gameObject.name == "CameraRightTrigger"){
			cameraLeft = false;
			cameraRight = true;
		}
	}

	// Detect when the player stays in the left or right triger...
	void OnTriggerStay2D(Collider2D collide){
		if (collide.gameObject.tag == ("Player") && gameObject.name == "CameraLeftTrigger"){
			cameraLeft = true;
			cameraRight = false;
		}
		else if(collide.gameObject.tag == ("Player") && gameObject.name == "CameraRightTrigger"){
			cameraLeft = false;
			cameraRight = true;
		}
	}

	// Detect when the player exits the trigger..
	void OnTriggerExit2D(Collider2D collide){
		cameraLeft = false;
		cameraRight = false;
	}
	// ******* END OF TRIGGERS *******
}
