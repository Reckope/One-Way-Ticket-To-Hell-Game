/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 14/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour {
    public static bool nextLevelTriggered = false;

    private bool inTrigger;

    void Update(){
        Debug.Log("inTrgger = " + inTrigger);
        Debug.Log("next trigger = " + nextLevelTriggered);
        if(inTrigger){
            if(gameObject.name == "NextLevelTriggered"){
                nextLevelTriggered = true;
            }
            
            else if(gameObject.name == "NextLevelUnTriggered"){
                nextLevelTriggered = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.layer == LayerMask.NameToLayer("player")){
			inTrigger = true;
        }
    }

	void OnTriggerExit2D(Collider2D collide)
     {
         if (collide.gameObject.layer == LayerMask.NameToLayer("player")){
             inTrigger = false;
         }
     }
}
