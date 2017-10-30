using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth = 3;
    public GameObject deathEffect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
            Instantiate(deathEffect, transform.position, transform.rotation);
            LevelLoader.enemiesKilled += 1;
            Destroy(transform.parent.gameObject);
        }
	}

    public void GiveDamage(int damageToGive) {
        enemyHealth -= damageToGive;
    }
}
