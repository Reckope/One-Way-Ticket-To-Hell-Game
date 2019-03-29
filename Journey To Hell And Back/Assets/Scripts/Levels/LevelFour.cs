using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFour : MonoBehaviour {

	// Other Scripts
	public LevelController levelController;

	// Level objects arrays
	private Vector2[] spawnTickets = new Vector2[3];
	private Vector2[] spawnDemons = new Vector2[4];
	private Vector2[] spawnReapers = new Vector2[3];

	// Prefabs
	public GameObject ticketPrefab;
	public GameObject demonPrefab;
	public GameObject reaperPrefab;

	// Game Objects
	private GameObject demon;
	private GameObject blackReaper;
	private GameObject ticket;

	// Global Variables
	public static int lvl4TicketQuantity;

	// Use this for initialization
	void Start () {
		lvl4TicketQuantity = 0;
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
		spawnDemons [0] = new Vector2(-11f, -330.9f);
		spawnDemons [1] = new Vector2(-14.8f, -329.3f);
		spawnDemons [2] = new Vector2(5.7f, -328.5f);
		spawnDemons [3] = new Vector2(21.3f, -330.2f);

		for(int x = 0; x < 4; x++){
			demon = (GameObject)Instantiate (demonPrefab, spawnDemons[x], Quaternion.identity);
		}
	}

	private void SpawnReapers(){
		// Spawn points
		spawnReapers [0] = new Vector2(-17.7f, -327.3f);
		spawnReapers [1] = new Vector2(-7f, -332.2f);
		spawnReapers [2] = new Vector2(7f, -222.27f);

		for(int x = 0; x < 3; x++){
			blackReaper = (GameObject)Instantiate (reaperPrefab, spawnReapers[x], Quaternion.identity);
		}
	}

	// Spawns the tickets in at the start (ONLY CALL IN THE START METHOD).
	private void SpawnTickets(){
		// Spawn Tickets
		spawnTickets [0] = new Vector2(8.08f, -326.54f);
		spawnTickets [1] = new Vector2(21.5f, -332.6f);
		spawnTickets [2] = new Vector2(-19.72f, -327.79f);

		for (int x = 0; x < 3; x++) {
			ticket = (GameObject)Instantiate (ticketPrefab, spawnTickets[x], Quaternion.identity);
			lvl4TicketQuantity++;
		}
	}

	public bool LevelFourCompleted(){
		if(lvl4TicketQuantity == 0) {
			return true;
		}
		else{
			return false;
		}
	}
}
