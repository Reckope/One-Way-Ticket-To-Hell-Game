/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * *** This is currently not being used ***
 * But keeping this in case I want to add player health. 
 * Code QA sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public static float currentHealth;

	private const float maxHealth = 100f;
	private const float minHealth = 0f;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		AddHealthBoundaries ();
	}

	// Min health is 0. Max health is 100.
	void AddHealthBoundaries(){
		if (currentHealth <= minHealth) {
			currentHealth = minHealth;
		}
		if (currentHealth >= maxHealth) {
			currentHealth = maxHealth;
		}
	}
}
