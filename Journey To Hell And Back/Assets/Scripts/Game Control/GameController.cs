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
    
    public GameObject hole;         

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
        }       }

    // This is temporary. Planning to have a much more complex way of determining when to progress onto the next level.
    void UnlockNextLevel(){
        if(score == 2) {
            MoveToNextLevel();
        }
        if (score == 5) {
            MoveToNextLevel();
        }
    }

    public void MoveToNextLevel(){
        StartCoroutine(MoveHole());
    }

    // Moves the hole to allow the player to jump to the next level. 
    public IEnumerator MoveHole() {
        float direction = -1f;
        float speed = 4f;
        float moveYPosition = direction * speed * Time.deltaTime * 1;

        hole = GameObject.Find("Hole");
        if (hole.transform != null){
            hole.transform.Translate(0, moveYPosition, 0);
        }
        yield return new WaitForSeconds(1);
        hole.transform.position = new Vector2(-15f, 5f);
    }
}
