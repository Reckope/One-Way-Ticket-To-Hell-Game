using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFive : MonoBehaviour {

	// Other Scripts
	public LevelController levelController;

	// Level objects arrays
	private Vector2 spawnSatan;

	// Prefabs
	public GameObject satanPrefab;

	// Game Objects
	private GameObject satan;

	// Use this for initialization
	void Start () {
		Destroy(satan);
		spawnSatan = new Vector2(8.5f, -440.14f);
		satan = (GameObject)Instantiate (satanPrefab, spawnSatan, Quaternion.identity);
	}

	public bool LevelFiveCompleted(){
		if(satan == null) {
			return true;
		}
		else{
			return false;
		}
	}
}
