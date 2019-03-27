using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	GameObject player;

	private float direction;
    private float speed;
    private float moveXPosition;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		speed = 17f;
	}
	
	// Update is called once per frame
	private void Update () {
		if(PlayerInputControl.shootingLeft && gameObject.transform.position.x <= player.transform.position.x){
			direction = -1;
		}
		if (PlayerInputControl.shootingRight && gameObject.transform.position.x >= player.transform.position.x){
			direction = 1;
		}
		moveXPosition = direction * speed * Time.deltaTime * 1;
		transform.Translate(moveXPosition, 0, 0);
		if(transform.position.x < -25 || transform.position.x > 25){
			gameObject.SetActive(false);
		}
	}
/* 
	void OnTriggerExit2D(Collider2D other) {
	  if (other.gameObject.tag == "Bounds") {
	  	Destroy(gameObject);
	  }
  	}
	  */
}
