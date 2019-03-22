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

    GameObject player;
    GameObject holeLvl1;
    GameObject holeLvl2;
    GameObject holeLvl3;
    GameObject holeLvl4;
    GameObject mainCamera;
    GameObject centerLvl1;

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
        levelController.UnlockNextLevel();
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

        if (LevelController.currentLevel == 1){
            holeLvl1.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            holeLvl1.transform.position = new Vector2(-35f, 5f);
        }
        else if(LevelController.currentLevel == 2){
            holeLvl2.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            holeLvl2.transform.position = new Vector2(-35f, -105f);
        }
        else if(LevelController.currentLevel == 3){
            holeLvl3.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            holeLvl3.transform.position = new Vector2(-35f, -205f);
        }
        else if(LevelController.currentLevel == 4){
            holeLvl4.transform.Translate(0, moveYPosition, 0);
            yield return new WaitForSeconds(1);
            holeLvl4.transform.position = new Vector2(-35f, -305f);
        }
        else{
            Debug.Log("ERROR: Couldn't determine current level to move hole.");
        }
    }

    // Calculate the distance between the player, and the center of the current level.
    public float CalculateDistanceBetweenPlayerAndCenter(){ // [2]
        player = GameObject.Find("Player");
        centerLvl1 = GameObject.Find("Level 1 Center");
        holeLvl2 = GameObject.Find("HoleLevel2");
        holeLvl3 = GameObject.Find("HoleLevel3");
        holeLvl4 = GameObject.Find("HoleLevel4");

        float distance;

        switch(LevelController.currentLevel){
			case 5:
			    //distance = Vector2.Distance(player.transform.position, holeLvl1.transform.position);
                distance = 0f;
			break;
			case 4:
				distance = Vector2.Distance(player.transform.position, holeLvl4.transform.position);
			break;
			case 3:
				distance = Vector2.Distance(player.transform.position, holeLvl3.transform.position);
			break;
			case 2:
				distance = Vector2.Distance(player.transform.position, holeLvl2.transform.position);
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
