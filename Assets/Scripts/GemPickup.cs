using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour {

    public int pointsToAdd = 10;
    public GameObject pickUpEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player>() == null) {
            return;
        }

        Instantiate(pickUpEffect, transform.position, transform.rotation);
        ScoreManager.AddPoints(pointsToAdd);  
        Destroy(gameObject);
    }
}
