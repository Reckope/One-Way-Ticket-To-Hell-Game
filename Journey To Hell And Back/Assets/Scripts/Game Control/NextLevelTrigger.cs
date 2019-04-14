/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 23/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour {

    public static bool nextLevelTriggered;

    private bool inTrigger;

    void Start(){
        nextLevelTriggered = false;
    }

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
