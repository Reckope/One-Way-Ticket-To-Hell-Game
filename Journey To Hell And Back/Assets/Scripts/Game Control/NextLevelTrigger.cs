/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is used to detect when the player has triggered the next level. 
 * Code QA Sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour {

    // Global Variables
    public static bool nextLevelTriggered;
    private bool inTrigger;

    // Use this for initialization
    void Start(){
        nextLevelTriggered = false;
    }

    // Update is called once per frame
    void Update(){
        //Debug.Log("inTrgger = " + inTrigger);
        //Debug.Log("next trigger = " + nextLevelTriggered);
        if(inTrigger){
            if(gameObject.name == "NextLevelTriggered"){
                nextLevelTriggered = true;
            }
        }
    }

    // If the player hits the trigger...
    void OnTriggerEnter2D(Collider2D collide){
        if (collide.gameObject.tag == ("Player")){
            inTrigger = true;
            if(gameObject.name == "FinishGameTrigger"){
                GameController.instance.finishGame = true;
                GameController.instance.level5Audio.Stop();
                GameController.instance.drumsAudio.Stop();
                GameController.instance.victoryAudio.Play();
            }
            else if(!GameController.instance.finishGame){
                GameController.instance.level1and2Audio.Stop();
                GameController.instance.level3and4Audio.Stop();
                GameController.instance.drumsAudio.Play();
            }
        }
    }

    // If the player exits the trigger...
    void OnTriggerExit2D(Collider2D collide){
        if (collide.gameObject.tag == ("Player")){
            inTrigger = false;
        }
        if(GameController.instance.finishGame){
            GameController.instance.finishGame = true;
        }
    }
}
