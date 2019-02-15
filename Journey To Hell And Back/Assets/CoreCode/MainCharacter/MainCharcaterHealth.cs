using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharcaterHealth : MonoBehaviour {

	public static float currentHealth;
	public float decreaseHealth = 1.7f;
	public float increaseHealth = 2.7f;

	private const float maxHealth = 100f;
	private const float minHealth = 0f;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth -= decreaseHealth * Time.deltaTime;
		if (currentHealth <= minHealth) {
			currentHealth = minHealth;
		}
	}
}
