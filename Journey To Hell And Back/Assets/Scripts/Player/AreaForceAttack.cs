/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 10/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaForceAttack : MonoBehaviour
{

    Vector2 initialSize = new Vector2(0.2f, 0.2f);
    Collider2D _collider;

    public Slider cooldownBar;

    public static float cooldownValue = 100f;
    float maxSize = 20f;
    float areaSize = 5f;
    float circleOpacity = 0.3f;

    bool fadeOut = false;

    // Use this for initialization
    void Start(){
        _collider = GetComponent<Collider2D>();
        transform.localScale = initialSize;
        cooldownBar.value = 100f;
    }

    // Update is called once per frame
    void Update(){
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, circleOpacity);
        cooldownBar.value = cooldownValue;

        // If the player uses the force attack...
        if (PlayerInputControl.areaForceAttack) {
			ExpandCircle ();
		}

        // Reset the force attack.
        if (fadeOut){
            circleOpacity -= Time.deltaTime * 1.4f;
            _collider.enabled = false;
        }

        ForceAttackCoodownValue();
    }

    // Expand the force attack...
    public void ExpandCircle()
    {
        if (transform.localScale.x <= maxSize){
            areaSize += Time.deltaTime * 300f;
            transform.localScale = initialSize * areaSize;
        }
        else{
            PlayerInputControl.areaForceAttack = false;
            StartCoroutine(ResetForceAttack());
        }
    }

    // Resets the force attack circle
    public IEnumerator ResetForceAttack(){
        circleOpacity = 1f;
        fadeOut = true;
        yield return new WaitForSeconds(0.6f);
        _collider.enabled = true;
        fadeOut = false;
        circleOpacity = .4f;
        areaSize = 5f;
        transform.localScale = initialSize;
    }

    // Is the cooldown active or not?
    public static bool ForceAttackCooldownActive(){
        if (cooldownValue < 100f){
            return true;
        }
        else{
            return false;
        }
    }

    // Change the cooldown value based on player input.
    public void ForceAttackCoodownValue(){
        float cooldownRate = 60f;

        if (PlayerInputControl._areaForceAttack && !AreaForceAttack.ForceAttackCooldownActive()){
            cooldownValue = 0f;
        }
        else if (!PlayerInputControl._areaForceAttack && cooldownValue < 100f){
            cooldownValue += Time.deltaTime * cooldownRate;
        }
    }

}