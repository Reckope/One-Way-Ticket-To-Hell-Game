/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * [x] = Reference
 * This is an intermediary script.
 * Instead of everything flowing entirely through the game controller, each script performs 
 * relevent actions after detecting them themselves, instead of the Game controller telling 
 * everyone what to do. (This the most efficient / future proof way?) 
 * Code QA Sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour {

    //Static instance of GameController which allows it to be accessed by any other script.
    public static GameController instance;

    // Other scripts.
    public LevelController levelController;
    public CameraController cameraController;
    public UIController uiController;

    // Game Objects (Could this be reduced / managed easier?)
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
    public GameObject finishGameTrigger;
    public GameObject smallerBoundsLvl1;
    public GameObject smallerBoundsLvl2;
    public GameObject smallerBoundsLvl3;
    public GameObject smallerBoundsLvl4;

    // Components.
    public Text scoreText;
    public AudioSource level1and2Audio;
    public AudioSource level3and4Audio;
    public AudioSource level5Audio;
    public AudioSource drumsAudio;
    public AudioSource victoryAudio;
    public AudioSource gameOverAudio;

    // Global variables.
    public static int score;
    public static bool preventLoop;
    public static string helpTextMessage;
    public bool finishGame;

    // Use this for initialization
    void Awake () {
        // Target frame rate is 60 fps
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 600;
        // Singleton Pattern: There can only ever be one instance of a GameController.
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
        score = 0;
        preventLoop = false;
        level1and2Audio.Play();
    }

    // Update is called once per frame
    void Update () {
        if(!GameOver()){
            GameFlow();
        }
    }

    // The flow of the game...
    public void GameFlow(){
        // Once a level has been completed. 
        if(levelController.CompletedLevelOne()) {
            // If the next level has been triggered. 
            if(!NextLevelTrigger.nextLevelTriggered){
                levelController.moveToNextLevel = true;
            }
            // Move the hole and grant access to the next level.
            StartCoroutine(MoveHole());
            // Prevent the help text firing every frame (better way to solve this issue?).
            if(preventLoop){
                return;
            }
            preventLoop = true;
            StartCoroutine(uiController.DisplayHelpText("Jump_Down_Hole"));
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
            StartCoroutine(uiController.DisplayHelpText("Jump_Down_Hole"));
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
            StartCoroutine(uiController.DisplayHelpText("Jump_Down_Hole"));
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
            StartCoroutine(uiController.DisplayHelpText("Jump_Down_Hole"));
        }
        else if (levelController.CompletedLevel5()) {
            if(preventLoop){
                return;
            }
            preventLoop = true;
            StartCoroutine(uiController.DisplayHelpText("Killed_Satan"));
            finishGameTrigger.SetActive(true);
            level5Audio.Stop();
        }
    }

    // Check if the game is over!
    public bool GameOver(){
        if (PlayerSystems.playerIsDead) {
            level1and2Audio.Stop();
            level3and4Audio.Stop();
            level5Audio.Stop();
            drumsAudio.Stop();
            return true;
        } 
        else {
            return false;
        }
    }

    // Moves the hole to allow the player to jump to the next level. 
    public IEnumerator MoveHole() {
        float direction = -1f;
        float speed = 4f;
        float moveYPosition = direction * speed * Time.deltaTime * 1;

        // Control the holes in each level
        holeLvl1 = GameObject.Find("HoleLevel1");
        holeLvl2 = GameObject.Find("HoleLevel2");
        holeLvl3 = GameObject.Find("HoleLevel3");
        holeLvl4 = GameObject.Find("HoleLevel4");

        // Move the hole based on the current level, then destroy it.
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
            //Debug.Log("ERROR: Couldn't move hole.");
        }
    }

    // Activate the smaller bounds once the player has moved near the center and completed level objectives.
    public void ActivateSmallerBounds(){
        // Detect what the current level is.
        switch(LevelController.currentLevel){
            case 4:
            // If it's completed...
            if(levelController.CompletedLevel4()){
                // Activate the smaller bounds.
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
            if(levelController.CompletedLevelOne()){
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

    // Calculate the distance between the player and the center of the current level.
    public float DistanceBetweenPlayerAndCenter(){
        float distance;

        // Find the center of each level.
        player = GameObject.Find("Player");
        centerLvl1 = GameObject.Find("Level 1 Center");
        centerLvl2 = GameObject.Find("Level 2 Center");
        centerLvl3 = GameObject.Find("Level 3 Center");
        centerLvl4 = GameObject.Find("Level 4 Center");
        centerLvl5 = GameObject.Find("Level 5 Center");

        // Detect the current level.
        switch(LevelController.currentLevel){
            case 5:
                distance = 0f;
            break;
            case 4:
                // Calculate the distance between the player and the center of the current level. 
                distance = Vector2.Distance(player.transform.position, centerLvl4.transform.position); // [2]
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
