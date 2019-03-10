/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 09/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaForceAttack : MonoBehaviour {

	Vector2 initialSize = new Vector2 (0.2f, 0.2f);
	public Slider cooldownBar;

	public static float cooldownValue = 100f;
	float maxSize = 20f;
	float areaSize = 4f;
	float circleOpacity = 0.3f;

	bool fadeOut = false;

	// Use this for initialization
	void Start () {
		transform.localScale = initialSize;
		cooldownBar.value = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent <SpriteRenderer> ().color = new Color (1f, 1f, 1f, circleOpacity);
		cooldownBar.value = cooldownValue;

		// if the force attack has been executed, fade the cirlce out.
		if (fadeOut) {
			circleOpacity -= Time.deltaTime * 1.4f;
		}

		CalculateCoodownValue ();
	}

	// Expand the force attack...
	public void ExpandCircle(){
		if (transform.localScale.x <= maxSize) {
			areaSize += Time.deltaTime * 300f;
			transform.localScale = initialSize * areaSize;
		} else {
			PlayerInputControl.areaForceAttack = false;
			StartCoroutine (ResetForceAttack ());
		}
	}

	void HurtEnemy(){
		Enemy.EnemyDie ();
	}

	// Resets the force attack circle
	public IEnumerator ResetForceAttack(){
		circleOpacity = 1f;
		fadeOut = true;
		yield return new WaitForSeconds (0.6f);
		fadeOut = false;
		circleOpacity = .4f;
		areaSize = 4f;
		transform.localScale = initialSize;
	}

	// If the force attack area hits an enemy...
	void OnTriggerEnter2D (Collider2D collide){
		if (collide.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			HurtEnemy ();
		}
	}

	// Is the cooldown active or not...
	public static bool ForceAttackCooldownActive(){
		if (cooldownValue < 100f) {
			return true;
		} 
		else {
			return false;
		}
	}

	// Change the cooldown value based on player input.
	void CalculateCoodownValue(){
		float cooldownRate = 60f;

		if (PlayerInputControl._areaForceAttack == true && !AreaForceAttack.ForceAttackCooldownActive()) {
			cooldownValue = 0f;
		} 
		else if (PlayerInputControl._areaForceAttack == false && cooldownValue < 100f){
			cooldownValue += Time.deltaTime * cooldownRate;
		}
	}
		
}
