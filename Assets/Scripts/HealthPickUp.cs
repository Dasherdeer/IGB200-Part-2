using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    public int healthToAdd = 30;
    public GameObject healthEffect;
    private GameObject effect;

    // Use this for initialization
    void Start() {
        effect = Instantiate(healthEffect, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player>() == null) {
            return;
        }
        HealthManager.AddHealth(healthToAdd);
        Destroy(effect);
        Destroy(gameObject);
    }
}
