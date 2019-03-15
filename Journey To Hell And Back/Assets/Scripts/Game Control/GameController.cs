/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 14/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //Static instance of GameController which allows it to be accessed by any other script.
    public static GameController instance;

    // Using Other Scripts:
    CameraController cameraControl;
    
    public GameObject holeLvl1;
    public GameObject holeLvl2;         

    public Text scoreText;

    public static int score;

	// Use this for initialization
    void Awake () {
	    Application.targetFrameRate = 600;

        cameraControl = FindObjectOfType(typeof(CameraController)) as CameraController;

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
        UnlockNextLevel();
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

    // This is temporary. Planning to have a much more complex way of determining when to progress onto the next level.
    void UnlockNextLevel(){
        if(score == 2 && LevelController.currentLevel == 1) {
            MoveToNextLevel();
        }
        else if (score == 5 && LevelController.currentLevel == 2) {
            MoveToNextLevel();
        }
    }

    // Disable UI and do other stuff while moving to next level...
    public void MoveToNextLevel(){
        StartCoroutine(MoveHole());
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
        if (holeLvl1.transform != null && LevelController.currentLevel == 1){
            holeLvl1.transform.Translate(0, moveYPosition, 0);
        }
        else if(holeLvl2.transform != null && LevelController.currentLevel == 2){
            holeLvl2.transform.Translate(0, moveYPosition, 0);
        }

        // Move the hole
        yield return new WaitForSeconds(1);
        holeLvl1.transform.position = new Vector2(-15f, 5f);
    }
}
