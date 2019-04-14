/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * Reference: [5]
 * This is only used for 1 enemy in level 2, as the framerate drops while an enemy follows a path.
 * Can't understand why it's doing it right now. Thought it would be cool to implement some sort
 * of basic pathfinding logic though for learning purposes. 
 * Code QA sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveOnPath : MonoBehaviour {

	// Scripts and components
	public EditorPathScript pathToFollow;
	public Enemy enemy;

	// GameObjects
	Vector2 lastPosition;
	Vector2 currentPosition;
	
	// Global Variables
	private int currentWaypointID;
	private int speed;
	private float reachDistance;

	// Use this for initialization
	void Start () {
		lastPosition = transform.position;
		currentWaypointID = 0;
		speed = 2;
		reachDistance = 1f;
	}

	// Update is called once per frame
	void Update () {
		// If the enemy isn't dead...
		if(!enemy.enemyIsDead){
			if(LevelController.currentLevel == 2 && gameObject != null){
				// Move the enemy to the path starting point.
				float distance = Vector2.Distance(pathToFollow.pathObjs[currentWaypointID].position, transform.position);
				transform.position = Vector3.MoveTowards(transform.position, pathToFollow.pathObjs[currentWaypointID].position, speed * Time.deltaTime);
				// Move along each waypoint. 
				if(distance <= reachDistance){
					currentWaypointID++;
				}
				// If we reach the end of the path, loop. 
				if(currentWaypointID >= pathToFollow.pathObjs.Count){
					currentWaypointID = 0;
				}
			}
		}
	}
}