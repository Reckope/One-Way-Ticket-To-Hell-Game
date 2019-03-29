using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFive : MonoBehaviour {

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
	public static int lvl5TicketQuantity;

	// Use this for initialization
	void Start () {
		lvl5TicketQuantity = 0;
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
		spawnTickets [0] = new Vector2(-5.45f, -440.6f);
		spawnTickets [1] = new Vector2(5.45f, -440.6f);
		spawnTickets [2] = new Vector2(-2.6f, -440f);

		for (int x = 0; x < 3; x++) {
			ticket = (GameObject)Instantiate (ticketPrefab, spawnTickets[x], Quaternion.identity);
			lvl5TicketQuantity++;
		}
	}

	public bool LevelFiveCompleted(){
		if(lvl5TicketQuantity == 0) {
			return true;
		}
		else{
			return false;
		}
	}
}
