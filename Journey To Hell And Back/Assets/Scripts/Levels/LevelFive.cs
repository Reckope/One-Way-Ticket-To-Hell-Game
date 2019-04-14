/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is used for level 5. I have given each level it's own script for spawn points,
 * objectives (easier to expand on in the future) and to return when it's completed. 
 * Code QA Sweep: DONE
 */

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

	// When the level has been completed.
	public bool LevelFiveCompleted(){
		if(satan == null) {
			return true;
		}
		else{
			return false;
		}
	}
}
