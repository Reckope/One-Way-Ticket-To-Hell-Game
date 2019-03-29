using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThree : MonoBehaviour {

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
	public static int lvl3TicketQuantity;

	// Use this for initialization
	void Start () {
		lvl3TicketQuantity = 0;
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
		spawnDemons [0] = new Vector2(-22.08f, -217.57f);
		spawnDemons [1] = new Vector2(-17.73f, -219.92f);
		spawnDemons [2] = new Vector2(9.3f, -220.27f);
		spawnDemons [3] = new Vector2(15.26f, -220.27f);

		for(int x = 0; x < 4; x++){
			demon = (GameObject)Instantiate (demonPrefab, spawnDemons[x], Quaternion.identity);
		}
	}

	private void SpawnReapers(){
		// Spawn points
		spawnReapers [0] = new Vector2(-18.55f, -222.27f);
		spawnReapers [1] = new Vector2(-9.13f, -222.27f);
		spawnReapers [2] = new Vector2(16.97f, -222.27f);

		for(int x = 0; x < 3; x++){
			blackReaper = (GameObject)Instantiate (reaperPrefab, spawnReapers[x], Quaternion.identity);
		}
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
