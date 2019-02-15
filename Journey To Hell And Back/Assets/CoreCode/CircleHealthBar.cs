using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleHealthBar : MonoBehaviour {

	public Image bar;
	public RectTransform button;

	public float _healthValue;

	void Start(){

	}
	
	// Update is called once per frame
	void Update () {
		_healthValue = MainCharcaterHealth.currentHealth;
		HealthChange (_healthValue);
	}

	void HealthChange(float healthValue){
		float amount = (healthValue / 100.0f) * 180.0f / 360;
		float buttonAngle = amount * 360;
		bar.fillAmount = amount;
		button.localEulerAngles = new Vector3 (0, 0, -buttonAngle);
	}
}
