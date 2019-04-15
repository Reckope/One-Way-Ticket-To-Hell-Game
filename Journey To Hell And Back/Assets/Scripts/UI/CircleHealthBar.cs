/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * *** This script isn't being used ***
 * But the health bar looks awesome so keeping this in case I want to add Player Health.
 * Code QA Sweep: DONE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleHealthBar : MonoBehaviour {

	// Components & GameObjects
	public Image bar;
	public RectTransform button;

	// Global Variables
	public float _healthValue;
	
	// Update is called once per frame
	void Update () {
		_healthValue = PlayerHealth.currentHealth;
		HealthChange (_healthValue);
	}

	// Display the players' health
	void HealthChange(float healthValue){
		float amount = (healthValue / 100.0f) * 180.0f / 360;
		float buttonAngle = amount * 360;

		bar.fillAmount = amount;
		button.localEulerAngles = new Vector3 (0, 0, -buttonAngle);
	}
}
