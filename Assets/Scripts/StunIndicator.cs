using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunIndicator : MonoBehaviour {

    public Color enemyColour;
    private SpriteRenderer sr;
    private GameObject sIP;
    public bool stunEnemy;
    public bool stunFailed;
    private float redMax;
    private float redMin;
    private float greenMax;
    private float greenMin;
    private Color sIPLerpedColor;
    float redAspect;
    float greenAspect;

	// Use this for initialization
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>(); 
        sIP = GameObject.FindGameObjectWithTag("PlayerStunIndicator");
        stunEnemy = false;
        stunFailed = false;
        redAspect = Random.Range(0.0f, 1.0f);
        greenAspect = Random.Range(0.0f, 1.0f);
        enemyColour = new Color(redAspect, greenAspect, 0, 1);
        sr.color = enemyColour;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PlayerStunCollider") { 
            redMax = enemyColour.r + 0.20f;
            Debug.Log("redmax " + redMax);
            redMin = enemyColour.r - 0.20f;
            Debug.Log("redmin " + redMin);
            greenMax = enemyColour.g + 0.20f;
            Debug.Log("greenmax " + greenMax);
            greenMin = enemyColour.g - 0.20f;
            Debug.Log("greenmin " + greenMin);

            if (redMax >= 1) {
                redMax = 1;
            }

            if (redMin <= 0) {
                redMin = 0;
            }

            if (greenMax >= 1) {
                greenMax = 1;
            }

            if (greenMin <= 0) {
                greenMin = 0;
            }

            sIPLerpedColor = sIP.GetComponent<StunIndicatorPlayer>().lerpedColor; 
            if (sIPLerpedColor.r <= redMax && sIPLerpedColor.r >= redMin && sIPLerpedColor.g <= greenMax && sIPLerpedColor.g >= greenMin) {
                stunEnemy = true;
                stunFailed = false;
                LevelLoader.enemiesStunned += 1;
               } else {
                stunEnemy = false;
                stunFailed = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "PlayerStunCollider") {
            stunEnemy = false;
            stunFailed = false;
        }
    }
}
