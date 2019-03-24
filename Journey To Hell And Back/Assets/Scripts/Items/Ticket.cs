using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D (Collider2D collide){
		if (collide.gameObject.tag == ("Player")) {
			// Play sound?
			GameController.score += 1;
			DecrementTicketFromLevel();
			Destroy(this.gameObject);
		}
	}

	private void DecrementTicketFromLevel(){
		switch (LevelController.currentLevel){
			case 5:
				LevelFive.lvl5TicketQuantity--;
			break;
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
