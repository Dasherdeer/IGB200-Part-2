using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public float speed = 8;
    Rigidbody2D rb;
    //public GameObject impactEffect;
    public float rotationSpeed = 50;
    public int damageToGive = 1;
    public GameObject thisEnemy;
    public float timeUntilDeath;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        thisEnemy = FindClosestEnemy();
        if (thisEnemy.GetComponent<Enemy2>().transform.localScale.x < 0) {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
        Invoke("Destory(gameObject)", timeUntilDeath);
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        rb.angularVelocity = rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {

            HealthManager.DamagePlayer(damageToGive);

            //Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public GameObject FindClosestEnemy() {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies) {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }
}
