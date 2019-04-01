using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour {

	// Other Scripts
	public LevelController levelController;

	// Level object arrays
	private Vector2[] spawnTickets = new Vector2[3];
	private Vector2[] spawnDemons = new Vector2[5];
	private Transform[] levelOneWaypoints;

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
		if(demon != null){
			Destroy(demon);
		}
		if(ticket != null){
			Destroy(ticket);
		}
		lvl1TicketQuantity = 0;
		SpawnTickets();
		SpawnDemons();
	}

	// Spawns the enemies in at the start.
	private void SpawnDemons(){
		// Spawn points
		spawnDemons [0] = new Vector2(-22.21f, -2.70f);
		spawnDemons [1] = new Vector2(-20f, -2.70f);
		spawnDemons [2] = new Vector2(-11.80f, -2.70f);
		spawnDemons [3] = new Vector2(11.80f, -2.70f);
		spawnDemons [4] = new Vector2(19.71f, -0.23f);

		for(int x = 0; x < 5; x++){
			demon = (GameObject)Instantiate (demonPrefab, spawnDemons[x], Quaternion.identity);
		}
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
