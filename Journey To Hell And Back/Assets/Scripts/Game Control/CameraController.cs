/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 23/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	// GameObjects & Scripts
	public LevelController levelControl;
	public CinematicBars cinematicBars;

	public static Vector2 cameraCurrentPosition;
	GameObject mainCamera;

	// Global Variables
	public const int CAMERA_Z_COORDINATE = -10;

	bool cameraLeft;
	bool cameraRight;
	bool cameraMovedToCenter;

    // Use this for initialization
    void Start () {
		mainCamera = GameObject.Find("Main Camera");
		cameraLeft = false;
		cameraRight = false;
		cameraMovedToCenter = false;
	}

	// Update is called once per frame
	void Update (){
		if(!GameController.instance.GameOver()){
			if(GameController.instance.finishGame){
				CameraFinishGame();
			}
			else if(!GameController.instance.finishGame){
				cameraCurrentPosition = transform.position;
				if(NextLevelTrigger.nextLevelTriggered){
					CameraTransitionBetweenLevels();
				}

				SetCameraBounds();

				if(transform.position.x >= -14.1f && transform.position.x <= 14.1f && LevelController.currentLevel != 5){
					if(cameraLeft == true){
						MoveCameraLeft();
					}
					else if(cameraRight == true){
						MoveCameraRight();
					}
				}
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

		if(transform.position.x < -14.1f){
			mainCamera.transform.position = new Vector3(-14.1f, cameraYPosition, -10);
		}
		if(transform.position.x > 14.1f){
			mainCamera.transform.position = new Vector3(14.1f, cameraYPosition, -10);
		}
	}

	// Transition the camera between each level.
	private void CameraTransitionBetweenLevels(){
		if(LevelController.currentLevel == 1){
			if(transform.position.y > LevelController.LEVEL_2_Y_POSITION){
				MoveCameraDown();
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
			// FLY UP AND END GAME
		}
	}

		// Smoothly move the camera downwards. 
	public void MoveCameraDown(){
		float direction = -1f;
        float speed = 3.5f;
        float moveYPosition = direction * speed * Time.deltaTime * 1;

		mainCamera.transform.Translate (0, moveYPosition, 0);
	}

	// Move the camera left when the player goes left.
	// Speed of the camera is based off the speed of the player (prevents jitter).
	void MoveCameraLeft(){
		float direction = -1f;
		float speed;
		if(PlayerInputControl.playerSpeedValue < 0){
			speed = PlayerInputControl.playerSpeedValue * -7f;
		}
		else{
			speed = 0;
		}
        float moveXPosition = direction * speed * Time.deltaTime * 1;

		mainCamera.transform.Translate (moveXPosition, 0, 0);
	}

	// Move the camera right when the player goes right.
	// Speed of the camera is based off the speed of the player (prevents jitter).
	void MoveCameraRight(){
		float direction = 1f;
		float speed;
		if(PlayerInputControl.playerSpeedValue > 0){
        	speed = PlayerInputControl.playerSpeedValue * 7f;
		}
		else{
			speed = 0;
		}
        float moveXPosition = direction * speed * Time.deltaTime * 1f;
		//float moveXPosition = Mathf.SmoothDamp(transform.position.x, 14.1f, ref xVelocity, 0.3f, 6f);

		mainCamera.transform.Translate (moveXPosition, 0, 0);
	}

	// Moves the camera to the center before transitioning to next level.
	public void MoveCameraToCenter(){
		// Local Variables
		float cameraSpeed = 3f;
		float position = cameraCurrentPosition.x;

		// Determine which side of the hole the camera currently is.
		if(position < 0f){
			position += cameraSpeed * Time.deltaTime * 1;
		}
		if (position > 0f){
			position -= cameraSpeed * Time.deltaTime * 1;
		}
		else if(position == 0){
			position = 0;
			cameraMovedToCenter = true;
		}
		// Move the camera based on which hole it detects.
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
			// NOT COMPLETED ANY LEVELS
		}
	}

	// Camera moves up and watches the player fly away! 
	public void CameraFinishGame(){
		float direction = 1f;
		float speed = 6f;
		float moveYPosition = direction * speed * Time.deltaTime * 1;
		if(transform.position.y < 0){
			mainCamera.transform.Translate (0, moveYPosition, 0);
		}
	}

	// ******* TRIGGERS *******
	// If the player hits the trigger...
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

	// If the player stays in the triger...
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

	// If the player exits the trigger..
	void OnTriggerExit2D(Collider2D collide){
		cameraLeft = false;
		cameraRight = false;
    }
	// ******* END OF TRIGGERS *******
}
