using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public GameObject thisEnemy;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            thisEnemy.GetComponent<Enemy2>().target = collision.gameObject;
            thisEnemy.GetComponent<Enemy2>().playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            thisEnemy.GetComponent<Enemy2>().target = null;
            thisEnemy.GetComponent<Enemy2>().playerInRange = false;
        }
    }
}
