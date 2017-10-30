using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public float damageToGive;


	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
    }


    void OnTriggerEnter2D(Collider2D other) {
            if (other.name == "Player") {
            HealthManager.DamagePlayer(damageToGive);
            other.GetComponent<AudioSource>().Play();

            var player = other.GetComponent<Player>();

            if (this.tag == "Enemy") {
                player.knockbackCount = player.knockbackLength;

                if (other.transform.position.x < transform.position.x) {
                    player.knockFromRight = true;
                } else {
                    player.knockFromRight = false;
                }
            }
        }
    }
}
