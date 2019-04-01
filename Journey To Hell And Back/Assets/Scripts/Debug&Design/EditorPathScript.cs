/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 30/03/19
 * Reference: [5]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPathScript : MonoBehaviour {

	public Color rayColor = Color.white;
	public List<Transform> pathObjs = new List<Transform>();
	Transform[] objectChildren;

	// To draw something in the editor.
	void OnDrawGizmos(){
		Gizmos.color = rayColor;
		objectChildren = GetComponentsInChildren<Transform>(); // Store all the path objects in the array
		pathObjs.Clear();

		// Update for when i'm not using any children objects.
		foreach(Transform pathObj in objectChildren){
			if(pathObj != this.transform){
				pathObjs.Add (pathObj);
			}
		}

		for(int x = 0; x < pathObjs.Count; x++){
			Vector2 position = pathObjs[x].position;
			if(x > 0){
				Vector2 previous = pathObjs[x-1].position;
				Gizmos.DrawLine(previous, position);
				Gizmos.DrawWireSphere(position, 0.2f);
			}
		}

	}
}
