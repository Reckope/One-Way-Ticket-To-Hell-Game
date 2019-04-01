/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 30/03/19
 * Reference: [5]
 * Notes:
 * This is only used for 1 enemy in level 2, as the framerate drops while an enemy follows a path.
 * Can't understand why it's doing it right now.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveOnPath : MonoBehaviour {

	public EditorPathScript pathToFollow;
	
	private int currentWaypointID;
	private int speed;
	private float reachDistance;
	public string pathName;

	Vector2 lastPosition;
	Vector2 currentPosition;

	// Use this for initialization
	void Start () {
		currentWaypointID = 0;
		speed = 2;
		reachDistance = 1f;
		//pathToFollow = GameObject.Find(pathName).GetComponent<EditorPathScript>();
		lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if((LevelController.currentLevel == 2 || LevelController.currentLevel == 3) && gameObject != null){
			// Move the enemy to the path starting point.
			float distance = Vector2.Distance(pathToFollow.pathObjs[currentWaypointID].position, transform.position);
			transform.position = Vector3.MoveTowards(transform.position, pathToFollow.pathObjs[currentWaypointID].position, speed * Time.deltaTime);
			// Move along each waypoint. 
			if(distance <= reachDistance){
				currentWaypointID++;
			}

			// If we reach the end of the path.
			if(currentWaypointID >= pathToFollow.pathObjs.Count){
				currentWaypointID = 0;
			}
		}
	}
}
