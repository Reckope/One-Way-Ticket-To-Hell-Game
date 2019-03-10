/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 08/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : MonoBehaviour {

	static Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void TakeDamage(){
		rb2d.velocity = (new Vector2 (0, 10f));
	}
		
}
