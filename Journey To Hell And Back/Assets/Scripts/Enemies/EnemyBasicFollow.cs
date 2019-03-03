using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicFollow : MonoBehaviour {

	public GameObject player;
	public float moveSpeed = 2f;
	private Rigidbody2D rb2d;

	void Start () {

		rb2d = GetComponent<Rigidbody2D>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		
	}

	void Update () {

		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
		
	}
}
