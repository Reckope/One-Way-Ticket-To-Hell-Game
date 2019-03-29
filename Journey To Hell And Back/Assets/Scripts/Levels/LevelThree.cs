using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThree : MonoBehaviour {

	// Other Scripts
	public LevelController levelController;

	// Level objects arrays
	private Vector2[] spawnTickets = new Vector2[3];
	private Vector2[] spawnEnemies;

	// Prefabs
	public GameObject ticketPrefab;
	public GameObject enemyPrefab;

	// Game Objects
	private GameObject demon;
	private GameObject ticket;

	// Global Variables
	public static int lvl3TicketQuantity;

	// Use this for initialization
	void Start () {
		//SpawnEnemies();
		SpawnTickets();
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Spawns the enemies in at the start.
	private void SpawnEnemies(){
		// Spawn points
		spawnEnemies [0] = new Vector2();
		spawnEnemies [1] = new Vector2();
		spawnEnemies [2] = new Vector2();
		spawnEnemies [3] = new Vector2();
	}

	// Spawns the tickets in at the start (ONLY CALL IN THE START METHOD).
	private void SpawnTickets(){
		// Spawn Tickets
		spawnTickets [0] = new Vector2(14.67f, -222.62f);
		spawnTickets [1] = new Vector2(16.1f, -220.5f);
		spawnTickets [2] = new Vector2(-17.53f, -215.91f);

		for (int x = 0; x < 3; x++) {
			ticket = (GameObject)Instantiate (ticketPrefab, spawnTickets[x], Quaternion.identity);
			lvl3TicketQuantity++;
		}
	}

	public bool LevelThreeCompleted(){
		if(lvl3TicketQuantity == 0) {
			return true;
		}
		else{
			return false;
		}
	}
}
