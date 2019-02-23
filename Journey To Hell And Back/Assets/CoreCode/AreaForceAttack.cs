using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaForceAttack : MonoBehaviour {

	Vector2 initialSize = new Vector2 (0.4f, 0.4f);
	private float maxSize = 7f;
	private float increaseSize = 1f;

	public float circleOpacity;

	// Use this for initialization
	void Start () {
		transform.localScale = initialSize;
		circleOpacity = .5f;
		GetComponent <SpriteRenderer> ().color = new Color (1f, 1f, 1f, circleOpacity);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent <SpriteRenderer> ().color = new Color (1f, 1f, 1f, circleOpacity);
	}

	public void ExpandCircle(){
		if (transform.localScale.x <= maxSize) {
			circleOpacity -= Time.deltaTime * 0.8f;
			increaseSize += Time.deltaTime * 50;
			transform.localScale = initialSize * increaseSize;
		} else {
			MainCharacterInputControl.areaForceAttack = false;
			ResetForceAttack ();
		}
	}

	public void ResetForceAttack(){
		circleOpacity = .5f;
		increaseSize = 1f;
		transform.localScale = initialSize;
	}
}
