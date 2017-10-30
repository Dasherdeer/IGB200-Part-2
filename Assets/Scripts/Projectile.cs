using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 8;
    Rigidbody2D rb;
    public Player player;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    public int pointsForKill = 20;
    public float rotationSpeed = 50;
    public int damageToGive = 1;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();

        if (player.transform.localScale.x < 0) {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        rb.angularVelocity = rotationSpeed;
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {

            other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        } else if (other.tag == "Ground"){
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }
}
