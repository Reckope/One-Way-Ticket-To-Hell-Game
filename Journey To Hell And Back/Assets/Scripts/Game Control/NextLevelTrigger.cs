/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 22/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour {

    public LevelController levelController;
    public UIController uiController;

    public static bool nextLevelTriggered;

    private bool inTrigger;

    void Start(){
        nextLevelTriggered = false;
    }

    void Update(){
        //Debug.Log("inTrgger = " + inTrigger);
        Debug.Log("next trigger = " + nextLevelTriggered);
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
        }
    }

    // If the player exits the trigger...
	void OnTriggerExit2D(Collider2D collide){
         if (collide.gameObject.tag == ("Player")){
             inTrigger = false;
         }
     }
}
