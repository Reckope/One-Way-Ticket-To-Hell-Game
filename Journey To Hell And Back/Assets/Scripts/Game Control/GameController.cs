/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 22/03/19
 * [x] = Reference
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //Static instance of GameController which allows it to be accessed by any other script.
    public static GameController instance;

    public LevelController levelController;
    public CameraController cameraController;
    public UIController uiController;

    GameObject player;
    GameObject holeLvl1;
    GameObject holeLvl2;
    GameObject holeLvl3;
    GameObject holeLvl4;
    GameObject mainCamera;
    GameObject centerLvl1;
    GameObject centerLvl2;
    GameObject centerLvl3;
    GameObject centerLvl4;
    GameObject centerLvl5;
    public GameObject smallerBoundsLvl1;
    public GameObject smallerBoundsLvl2;
    public GameObject smallerBoundsLvl3;
    public GameObject smallerBoundsLvl4;

    public Text scoreText;

    public static int score;
    public static bool preventLoop = false;

    // Use this for initialization
    void Awake () {
        Application.targetFrameRate = 600;

        // Singleton Pattern: There can only ever be one instance of a GameController.
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }

        score = 0;
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();

        if(GameOver()){
            // Do Game Over Stuff...
	        Debug.Log ("GAME_OVER");
        }

        // Flow...
        GameFlow();
    }

    // The entire flow of the game...
	public void GameFlow(){
        if(levelController.CompletedLevel1()) {
			if(!NextLevelTrigger.nextLevelTriggered){
				levelController.moveToNextLevel = true;
			}
            StartCoroutine(MoveHole());
            if(preventLoop){
                return;
            }
            preventLoop = true;
            StartCoroutine(uiController.DisplayNextLevelHelpText());
        }
        else if (levelController.CompletedLevel2()) {
			if(!NextLevelTrigger.nextLevelTriggered){
				levelController.moveToNextLevel = true;
			}
            StartCoroutine(MoveHole());
            if(preventLoop){
                return;
            }
            preventLoop = true;
            StartCoroutine(uiController.DisplayNextLevelHelpText());
        }
        else if (levelController.CompletedLevel3()) {
			if(!NextLevelTrigger.nextLevelTriggered){
				levelController.moveToNextLevel = true;
			}
            StartCoroutine(MoveHole());
            if(preventLoop){
                return;
            }
            preventLoop = true;
            StartCoroutine(uiController.DisplayNextLevelHelpText());
        }
        else if (levelController.CompletedLevel4()) {
			if(!NextLevelTrigger.nextLevelTriggered){
				levelController.moveToNextLevel = true;
			}
            StartCoroutine(MoveHole());
            if(preventLoop){
                return;
            }
            preventLoop = true;
            StartCoroutine(uiController.DisplayNextLevelHelpText());
        }
        else if (levelController.CompletedLevel5()) {
            // FLY UP AND END THE GAME
        }
    }

    // Check if the game is over!
    bool GameOver(){
        if (PlayerHealth.currentHealth <= 0) {
            return true;
        } 
        else {
            return false;
        }       
    }

    // Moves the hole to allow the player to jump to the next level. 
    public IEnumerator MoveHole() {
        // Local Variables
        float direction = -1f;
        float speed = 4f;
        float moveYPosition = direction * speed * Time.deltaTime * 1;

        // Control the holes in each level
        holeLvl1 = GameObject.Find("HoleLevel1");
        holeLvl2 = GameObject.Find("HoleLevel2");
        holeLvl3 = GameObject.Find("HoleLevel3");
        holeLvl4 = GameObject.Find("HoleLevel4");

        if (LevelController.currentLevel == 1 && holeLvl1 != null){
            holeLvl1.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            Destroy(holeLvl1);
        }
        else if(LevelController.currentLevel == 2 && holeLvl2 != null){
            holeLvl2.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            Destroy(holeLvl2);
        }
        else if(LevelController.currentLevel == 3 && holeLvl3 != null){
            holeLvl3.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            Destroy(holeLvl3);
        }
        else if(LevelController.currentLevel == 4 && holeLvl4 != null){
            holeLvl4.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            Destroy(holeLvl4);
        }
        else{
            Debug.Log("ERROR: Couldn't move hole.");
        }
    }

    //Activate the smaller bounds once the player has moved near the center and completed level objectives.
    public void ActivateSmallerBounds(){
        switch(LevelController.currentLevel){
			case 4:
            if(levelController.CompletedLevel4()){
				smallerBoundsLvl4.SetActive(true);
            }
			break;
			case 3:
			if(levelController.CompletedLevel3()){
				smallerBoundsLvl3.SetActive(true);
            }
			break;
			case 2:
			if(levelController.CompletedLevel2()){
				smallerBoundsLvl2.SetActive(true);
            }
			break;
			case 1:
			if(levelController.CompletedLevel1()){
				smallerBoundsLvl1.SetActive(true);
            }
			break;
			default:
				smallerBoundsLvl1.SetActive(false);
                smallerBoundsLvl2.SetActive(false);
                smallerBoundsLvl3.SetActive(false);
                smallerBoundsLvl4.SetActive(false);
			break;
		}
    }

    // Calculate the distance between the player, and the center of the current level.
    public float CalculateDistanceBetweenPlayerAndCenter(){ // [2]
        player = GameObject.Find("Player");
        centerLvl1 = GameObject.Find("Level 1 Center");
        centerLvl2 = GameObject.Find("Level 2 Center");
        centerLvl3 = GameObject.Find("Level 3 Center");
        centerLvl4 = GameObject.Find("Level 4 Center");
        centerLvl5 = GameObject.Find("Level 5 Center");

        float distance;

        switch(LevelController.currentLevel){
			case 5:
			    //distance = Vector2.Distance(player.transform.position, centerLvl5.transform.position);
                distance = 0f;
			break;
			case 4:
				distance = Vector2.Distance(player.transform.position, centerLvl4.transform.position);
			break;
			case 3:
				distance = Vector2.Distance(player.transform.position, centerLvl3.transform.position);
			break;
			case 2:
				distance = Vector2.Distance(player.transform.position, centerLvl2.transform.position);
			break;
			case 1:
				distance = Vector2.Distance(player.transform.position, centerLvl1.transform.position);
			break;
			default:
				distance = Vector2.Distance(player.transform.position, centerLvl1.transform.position);
			break;
		}
        return distance;
    }

}
