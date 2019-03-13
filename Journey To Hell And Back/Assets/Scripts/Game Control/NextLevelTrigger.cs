/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 13/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour {
    public static bool nextLevelTriggered = false;

    // If the Next Level Trigger gets hit by the player... 
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            nextLevelTriggered = true;
            GameController.instance.TriggerNextLevel();
        }
    }
}
