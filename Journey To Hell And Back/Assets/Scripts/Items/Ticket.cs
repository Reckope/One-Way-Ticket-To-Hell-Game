/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is used for the tickets within each level.
 * Code QA Sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour {

	// When the player collects on of the tickets...
	private void OnTriggerEnter2D (Collider2D collide){
		if (collide.gameObject.tag == ("Player")) {
			DecrementTicketFromLevel();
			Destroy(this.gameObject);
		}
	}

	// Decrement ticket from whichever level the player is currently in.
	private void DecrementTicketFromLevel(){
		switch (LevelController.currentLevel){
			case 4:
				LevelFour.lvl4TicketQuantity--;
			break;
			case 3:
				LevelThree.lvl3TicketQuantity--;
			break;
			case 2:
				LevelTwo.lvl2TicketQuantity--;
			break;
			case 1:
				LevelOne.lvl1TicketQuantity--;
			break;
		}
	}
}
