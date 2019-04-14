/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 23/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : MonoBehaviour {

	public LevelController levelController;
	public CinematicBars cinematicBars;
	public PlayerInputControl playerInputControl;
	public UIController UIController;

	static Rigidbody2D rb2d;
	Collider2D collider;

	public static bool playerIsDead;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
		playerIsDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerIsDead){
			//PlayerDie();
		}
		if(NextLevelTrigger.nextLevelTriggered){
			PlayerTransitionBetweenLevels();
		}
		else if(GameController.instance.finishGame){
			PlayerFinishGame();
		}
	}

	// When the player dies...
	private void PlayerDie(){
		GameController.instance.gameOverAudio.Play();
		PlayerSystems.playerIsDead = true;
		collider.enabled = false;
		rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
		rb2d.velocity = (new Vector2 (0, 11f));
	}

	// When the player has triggered the next level... (player is transitioning)
	public void PlayerTransitionBetweenLevels(){
		float transitionDirection = -1f;
		float transitionSpeed = 8.5f;

		rb2d.bodyType = RigidbodyType2D.Static;
		transform.Translate(0, transitionDirection * transitionSpeed * Time.deltaTime * 1, 0);

		// This is me cheating, since I'm having problems getting OnTriggerExit2D to trigger while
		// the player gameObject has a static RigidBody2D type.
		// When the player has reached the next level area...
		// Level 1 - 2...
		if (transform.position.y > -110 && transform.position.y < -100){
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			NextLevelTrigger.nextLevelTriggered = false;
			playerInputControl.controlSlider.value = 0;
			playerInputControl.shootSlider.value = 0;
			GameController.instance.level1and2Audio.Play();
			GameController.instance.drumsAudio.Stop();
		}
		// Level 2 - 3...
		else if (transform.position.y > -220 && transform.position.y < -210){
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			NextLevelTrigger.nextLevelTriggered = false;
			playerInputControl.controlSlider.value = 0;
			playerInputControl.shootSlider.value = 0;
			GameController.instance.level3and4Audio.Play();
			GameController.instance.drumsAudio.Stop();
		}
		// Level 3 - 4...
		else if (transform.position.y > -330 && transform.position.y < -320){
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			NextLevelTrigger.nextLevelTriggered = false;
			playerInputControl.controlSlider.value = 0;
			playerInputControl.shootSlider.value = 0;
			GameController.instance.level3and4Audio.Play();
			GameController.instance.drumsAudio.Stop();
		}
		// Level 4 - 5...
		else if (transform.position.y > -440 && transform.position.y < -430){
			rb2d.bodyType = RigidbodyType2D.Dynamic;
			NextLevelTrigger.nextLevelTriggered = false;
			playerInputControl.controlSlider.value = 0;
			playerInputControl.shootSlider.value = 0;
			GameController.instance.level5Audio.Play();
			GameController.instance.drumsAudio.Stop();
		}
		else{
			//Debug.Log("TRANSITIONING");
		}
	}

	public void PlayerFinishGame(){
		float transitionDirection = 1f;
		float transitionSpeed = 18f;

		if(transform.position.y < 1.2){
			rb2d.bodyType = RigidbodyType2D.Static;
			transform.Translate(0, transitionDirection * transitionSpeed * Time.deltaTime * 1, 0);
		}
		if(transform.position.y >= 1.2){
			transform.position = new Vector2(transform.position.x, 1.2f);
		}
	}

	// If the player touches the Enemy... (This is for selecting a death reason)
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == ("Demon")) {
			UIController.SelectDeathReason("Killed_By_Demon");
			PlayerDie();
		}
		else if (collision.gameObject.tag == ("Reaper")) {
			UIController.SelectDeathReason("Killed_By_Reaper");
			PlayerDie();
		}
		else if (collision.gameObject.tag == ("Satan")) {
			UIController.SelectDeathReason("Killed_By_Satan");
			PlayerDie();
		}
		else if (collision.gameObject.tag == ("Fire")) {
			UIController.SelectDeathReason("Killed_By_Fire");
			PlayerDie();
		}
	}
}
