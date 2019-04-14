/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 17/03/19
 * ***** This script is not currently being used ***** 
 * Decided to spawn enemies in each levels' script, due to the amount of spawn points there are. This
 * script can be ignored, but keeping it here in case I need it in the future. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesController : MonoBehaviour {

	//Other Scripts:
	Enemy enemyScript;
	LevelController levelControl;

	public GameObject enemyPrefab;

	private GameObject enemySpawn;
	private Vector2[] spawnPositionsLevelOne = new Vector2[5];
	private Vector2[] spawnPositionsLevelTwo = new Vector2[4];

	void Start () {
		GameObject gameController = GameObject.Find("Game Controller");
		levelControl = gameController.GetComponent<LevelController>();
		// Spawn the enemies at the start of the game.
		InstantiateEnemies();
	}

	void Update () {
		
		/*if(LevelController.currentLevel > LevelController.previousLevel){
			LevelController.previousLevel = LevelController.currentLevel;
			if(!Enemy.enemyIsDead){
				enemyScript = FindObjectOfType(typeof(Enemy)) as Enemy;
				enemyScript.EnemyDie();
				RespawnEnemyWhichLevel();
			}
			else{
				RespawnEnemyWhichLevel();
			}
		}*/

		//if(!LevelController.isPlayerInLevel){
		//	Destroy(enemyPrefab);
		//}
	}

	// Temporary.. Spawn the enemy/enemies at the start of the game.
	void InstantiateEnemies(){
		spawnPositionsLevelOne [0] = new Vector2 (0f, 10f);
		spawnPositionsLevelOne [1] = new Vector2 (-12f, 2f);
		spawnPositionsLevelOne [2] = new Vector2 (12f, 2f);
        spawnPositionsLevelOne [3] = new Vector2(-12f, 6f);
        spawnPositionsLevelOne [4] = new Vector2(12f, 6f);
		
        for (int x = 0; x < 1; x++) {
			enemySpawn = (GameObject)Instantiate (enemyPrefab, spawnPositionsLevelOne [0], Quaternion.identity);
		}
	}

	public void RespawnEnemyWhichLevel(){
		if(LevelController.currentLevel == 1){
			RespawnEnemyLevel1();
		}
		else if(LevelController.currentLevel == 2){
			RespawnEnemyLevel2();
		}
	}

	void RespawnEnemyLevel1(){
		int spawnPoint;

		// Spawn points...
		spawnPositionsLevelOne [0] = new Vector2 (-5f, 10f);
		spawnPositionsLevelOne [1] = new Vector2 (-12f, 2f);
		spawnPositionsLevelOne [2] = new Vector2 (12f, 2f);
		spawnPositionsLevelOne [3] = new Vector2(-12f, 6f);
		spawnPositionsLevelOne [4] = new Vector2(12f, 6f);

		spawnPoint = 0;
		spawnPoint = Random.Range (0, 4);
		Instantiate (enemyPrefab, spawnPositionsLevelOne[spawnPoint], Quaternion.identity);
	}

	void RespawnEnemyLevel2(){
		int spawnPoint;

		// Spawn points...
		spawnPositionsLevelTwo [0] = new Vector2 (-12f, -110f);
		spawnPositionsLevelTwo [1] = new Vector2 (12f, -110f);
		spawnPositionsLevelTwo [2] = new Vector2 (-1f, -103f);
		spawnPositionsLevelTwo [3] = new Vector2(1f, -103f);
		//spawnPositionsLevelTwo [4] = new Vector2(12f, 6f);

		spawnPoint = 0;
		spawnPoint = Random.Range (0, 3);
		Instantiate (enemyPrefab, spawnPositionsLevelTwo[spawnPoint], Quaternion.identity);
	}

	void RespawnEnemyLevel3(){}
}
