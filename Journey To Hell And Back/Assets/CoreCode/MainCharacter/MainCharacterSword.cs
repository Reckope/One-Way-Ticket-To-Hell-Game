using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterSword : MonoBehaviour {

	public MainCharacterInputControl mainCharacter;
	public GameObject swordLeft;
	public GameObject swordRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	/*public IEnumerator SwingSword(){

		if (mainCharacter.goingLeft && mainCharacter.swingSword) {
			swordRight.SetActive (false);
			swordLeft.SetActive (true);
			yield return new WaitForSeconds (1);
			swordLeft.SetActive (false);
		} else if (mainCharacter.goingRight && mainCharacter.swingSword) {
			swordLeft.SetActive (false);
			swordRight.SetActive (true);
			yield return new WaitForSeconds (1);
			swordRight.SetActive (false);
		}

	}*/
}
