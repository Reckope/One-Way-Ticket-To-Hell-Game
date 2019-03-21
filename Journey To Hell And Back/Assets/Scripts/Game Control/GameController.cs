/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 19/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //Static instance of GameController which allows it to be accessed by any other script.
    public static GameController instance;
    
    GameObject holeLvl1;
    GameObject holeLvl2;
    GameObject holeLvl3;
    GameObject holeLvl4;

    public Text scoreText;

    public static int score;

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
        else if (score == 8 && LevelController.currentLevel == 3) {
            MoveToNextLevel();
        }
        else if (score == 12 && LevelController.currentLevel == 4) {
            MoveToNextLevel();
        }
        else if (score == 16 && LevelController.currentLevel == 5) {
            // FLY UP AND END THE GAME
        }
    }

    // Disable UI and do other stuff while moving to next level...
    public void MoveToNextLevel(){
        StartCoroutine(MoveHole());
    }

    // Moves the hole to allow the player to jump to the next level. 
    private IEnumerator MoveHole() {
        // Local Variables
        float direction = -1f;
        float speed = 4f;
        float moveYPosition = direction * speed * Time.deltaTime * 1;

        // Control the holes in each level
        holeLvl1 = GameObject.Find("HoleLevel1");
        holeLvl2 = GameObject.Find("HoleLevel2");
        holeLvl3 = GameObject.Find("HoleLevel3");
        holeLvl4 = GameObject.Find("HoleLevel4");

        if (LevelController.currentLevel == 1){
            holeLvl1.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            holeLvl1.transform.position = new Vector2(-15f, 5f);
        }
        else if(LevelController.currentLevel == 2){
            holeLvl2.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            holeLvl2.transform.position = new Vector2(-15f, -105f);
        }
        else if(LevelController.currentLevel == 3){
            holeLvl3.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            holeLvl3.transform.position = new Vector2(-15f, -205f);
        }
        else if(LevelController.currentLevel == 4){
            holeLvl4.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            holeLvl4.transform.position = new Vector2(-15f, -305f);
        }
        else{
            Debug.Log("ERROR: Couldn't determine current level to move hole.");
        }
    }
}
