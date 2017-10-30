using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour {

    public int ammoToAdd = 20;
    public GameObject ammoEffect;
    private GameObject effect;

    // Use this for initialization
    void Start() {
        effect = Instantiate(ammoEffect, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player>() == null) {
            return;
        }
        AmmoManager.AddAmmo(ammoToAdd);
        Destroy(effect);
        Destroy(gameObject);
    }
}
