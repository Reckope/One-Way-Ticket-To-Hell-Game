using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            GameController.instance.TriggerNextLevel();
        }
    }
}
