/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 10/03/19
 * Notes:
 * Need to experiment with different object pooling techniques. This is a mess just now.
 * Going to find out how to give each prefab a unique ID / Variable so they spawn in spcific areas.
 * .. or I could do some some of threading so they 2 enemies dont spawn in 1 location.. (nope).
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesLevelOne : MonoBehaviour {

	public GameObject enemyPrefab;

	private GameObject enemySpawn;
	private readonly Vector2[] spawnPositionsLevelOne = new Vector2[5];

	/*
	Vector2 enemyTopSpawnPosition = new Vector2(0, 10f);
	Vector2 enemyLeftSpawnPosition = new Vector2(-12f, 2f);
	Vector2 enemyRightSpawnPosition = new Vector2(12f, 2f);
	*/
	int spawnPoint;


	void Start () {
		spawnPositionsLevelOne [0] = new Vector2 (0, 10f);
		spawnPositionsLevelOne [1] = new Vector2 (-12f, 2f);
		spawnPositionsLevelOne [2] = new Vector2 (12f, 2f);
        spawnPositionsLevelOne [3] = new Vector2(-12f, 6f);
        spawnPositionsLevelOne [4] = new Vector2(12f, 6f);

        for (int x = 0; x < 3; x++) {
			enemySpawn = (GameObject)Instantiate (enemyPrefab, spawnPositionsLevelOne [x], Quaternion.identity);
		}
		//enemySpawn = (GameObject)Instantiate (enemyPrefab, spawnPositionsLevelOne [1], Quaternion.identity);
		//enemySpawn = (GameObject)Instantiate (enemyPrefab, spawnPositionsLevelOne [2], Quaternion.identity);
	}

	void Update () {

	}

	public void RespawnEnemy(){
		spawnPoint = 0;
		spawnPoint = Random.Range (0, 4);
		Instantiate (enemyPrefab, spawnPositionsLevelOne[spawnPoint], Quaternion.identity);
	}
}
