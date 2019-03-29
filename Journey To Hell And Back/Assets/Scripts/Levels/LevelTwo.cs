using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwo : MonoBehaviour {

	// Other Scripts
	public LevelController levelController;

	// Level objects arrays
	private Vector2[] spawnTickets = new Vector2[3];
	private Vector2[] spawnDemons = new Vector2[4];
	private Vector2[] spawnReapers = new Vector2[2];

	// Prefabs
	public GameObject ticketPrefab;
	public GameObject demonPrefab;
	public GameObject reaperPrefab;

	// Game Objects
	private GameObject demon;
	private GameObject blackReaper;
	private GameObject ticket;

	// Global Variables
	public static int lvl2TicketQuantity;

	// Use this for initialization
	void Start () {
		lvl2TicketQuantity = 0;
		SpawnDemons();
		SpawnReapers();
		SpawnTickets();
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Spawns the enemies in at the start.
	private void SpawnDemons(){
		// Spawn points
		spawnDemons [0] = new Vector2(-18.21f, -110.16f);
		spawnDemons [1] = new Vector2(-12.57f, -110.16f);
		spawnDemons [2] = new Vector2(12.9f, -110.16f);
		spawnDemons [3] = new Vector2(18.39f, -110.16f);

		for(int x = 0; x < 4; x++){
			demon = (GameObject)Instantiate (demonPrefab, spawnDemons[x], Quaternion.identity);
		}
	}

	private void SpawnReapers(){
		// Spawn points
		spawnReapers [0] = new Vector2(-20.53f, -112.5f);
		spawnReapers [1] = new Vector2(10f, -112.5f);

		for(int x = 0; x < 2; x++){
			blackReaper = (GameObject)Instantiate (reaperPrefab, spawnReapers[x], Quaternion.identity);
		}
	}

	// Spawns the tickets in at the start (ONLY CALL IN THE START METHOD).
	private void SpawnTickets(){
		// Spawn Tickets
		spawnTickets [0] = new Vector2(-15.31f, -110.4f);
		spawnTickets [1] = new Vector2(13.78f, -112.58f);
		spawnTickets [2] = new Vector2(17.7f, -112.58f);

		for (int x = 0; x < 3; x++) {
			ticket = (GameObject)Instantiate (ticketPrefab, spawnTickets[x], Quaternion.identity);
			lvl2TicketQuantity++;
		}
	}

	public bool LevelTwoCompleted(){
		if(lvl2TicketQuantity == 0) {
			return true;
		}
		else{
			return false;
		}
	}
}
