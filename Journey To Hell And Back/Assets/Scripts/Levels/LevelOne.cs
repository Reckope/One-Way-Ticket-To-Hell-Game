using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour {

	// Other Scripts
	public LevelController levelController;

	// Level object arrays
	private Vector2[] spawnTickets = new Vector2[3];
	private Vector2[] spawnDemons = new Vector2[1];

	// Prefabs
	public GameObject ticketPrefab;
	public GameObject demonPrefab;

	// Game Objects
	private GameObject demon;
	private GameObject ticket;

	// Global Variables
	public static int lvl1TicketQuantity;

	// Use this for initialization
	void Start () {
		SpawnTickets();
		SpawnEnemies();
	}

	// Spawns the enemies in at the start.
	private void SpawnEnemies(){
		// Spawn points
		spawnDemons [0] = new Vector2(-4.15f, -2.90f);
		//spawnEnemies [1] = new Vector2();
		//spawnEnemies [2] = new Vector2();
		//spawnEnemies [3] = new Vector2();
		demon = (GameObject)Instantiate (demonPrefab, spawnDemons[0], Quaternion.identity);
	}

	// Spawns the tickets in at the start (ONLY CALL IN THE START METHOD).
	private void SpawnTickets(){
		// Spawn Tickets
		spawnTickets [0] = new Vector2(-16.8f, -2.55f);
		spawnTickets [1] = new Vector2(0f, 2.52f);
		spawnTickets [2] = new Vector2(21.85f, -2.75f);

		for (int x = 0; x < 3; x++) {
			ticket = (GameObject)Instantiate (ticketPrefab, spawnTickets[x], Quaternion.identity);
			lvl1TicketQuantity++;
		}
	}

	public bool LevelOneCompleted(){
		if(lvl1TicketQuantity == 0) {
			return true;
		}
		else{
			return false;
		}
	}
}
