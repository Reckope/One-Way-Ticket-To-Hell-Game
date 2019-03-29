/* Author: Joe Davis
 * Project: Hell and Back
 * Date modified: 27/03/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaForceAttack : MonoBehaviour
{

    // Scripts & Components
    Vector2 initialSize = new Vector2(0.2f, 0.2f);
    Collider2D collider;

    // GameObjects
    public Slider cooldownBar;

    // Global variables
    public static float cooldownValue;
    private float maxSize;
    private float areaSize;
    private float circleOpacity;
    private bool fadeOut;

    // Use this for initialization
    void Start(){
        collider = GetComponent<Collider2D>();
        transform.localScale = initialSize;
        cooldownValue = 0f;
        cooldownBar.value = 0f;
        maxSize = 25f;
        areaSize = 5f;
        circleOpacity = 0.3f;
        fadeOut = false;
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update(){
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, circleOpacity);
        cooldownBar.value = cooldownValue;

        // If the player uses the force attack...
        if (PlayerInputControl.areaForceAttack) {
            collider.enabled = true;
			ExpandCircle ();
		}
        // Reset the force attack.
        if (fadeOut){
            circleOpacity -= Time.deltaTime * 1.2f;
            collider.enabled = false;
        }
        //ForceAttackCoodownValue();
    }

    // Expand the force attack...
    public void ExpandCircle()
    {
        if (transform.localScale.x <= maxSize){
            areaSize += Time.deltaTime * 550f;
            transform.localScale = initialSize * areaSize;
        }
        else{
            PlayerInputControl.areaForceAttack = false;
            StartCoroutine(ResetForceAttack());
        }
    }

    // Resets the force attack circle
    private IEnumerator ResetForceAttack(){
        circleOpacity = 1f;
        fadeOut = true;
        yield return new WaitForSeconds(1.6f);
        collider.enabled = false;
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
    // Not using this, but could be useful if i want to apply a cooldown.
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