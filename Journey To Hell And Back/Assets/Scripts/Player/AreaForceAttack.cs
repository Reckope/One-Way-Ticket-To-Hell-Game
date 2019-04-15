/* Author: Joe Davis
 * Project: One Way Ticket to Hell
 * Date modified: 14/04/19
 * This is attached to the force attack object, being controlled by the input controller. 
 * Code QA sweep: DONE
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaForceAttack : MonoBehaviour{

    // Scripts & Components
    public PlayerInputControl PlayerInputControl;
    Vector2 initialSize = new Vector2(0.2f, 0.2f);
    Collider2D collide;

    // GameObjects
    public Slider cooldownBar;
    public AudioSource forceAttackAudio;

    // Global variables
    public static float cooldownValue;
    private float maxSize;
    private float areaSize;
    private float circleOpacity;
    private bool fadeOut;

    // Use this for initialization
    void Start(){
        collide = GetComponent<Collider2D>();
        transform.localScale = initialSize;
        cooldownValue = 0f;
        cooldownBar.value = 0f;
        maxSize = 25f;
        areaSize = 5f;
        circleOpacity = 0.3f;
        fadeOut = false;
        collide.enabled = false;
    }

    // Update is called once per frame
    void Update(){
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, circleOpacity);
        cooldownBar.value = cooldownValue;

        // If the player uses the force attack...
        if (PlayerInputControl.areaForceAttack) {
            forceAttackAudio.Play();
            collide.enabled = true;
            ExpandCircle ();
        }
        // Fade the circle out as it resets.
        if (fadeOut){
            circleOpacity -= Time.deltaTime * 1.2f;
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
        collide.enabled = false;
        circleOpacity = 1f;
        fadeOut = true;
        yield return new WaitForSeconds(1.6f);
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