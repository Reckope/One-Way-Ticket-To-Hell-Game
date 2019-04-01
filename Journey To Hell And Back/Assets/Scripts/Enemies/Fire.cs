using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public LevelController LevelController;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2(5.5f, -442.544f);
	}
	
	// Update is called once per frame
	void Update () {
		if(LevelController.currentLevel == 5 && !GameController.instance.GameOver() && !LevelController.CompletedLevel5() && gameObject != null){
			if(transform.position.x > -12f){
				transform.Translate(-3.5f * Time.deltaTime, 0, 0);
			}
			else 
			transform.position = new Vector2(4f, -442.544f);
		}
		else if(LevelController.CompletedLevel5()){
			Destroy(gameObject);
		}
		
	}

	// If the fire touches the Player...
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == ("Player")) {
			GameController.instance.SelectDeathReason(4);
			PlayerSystems.playerIsDead = true;
		}
	}
}
