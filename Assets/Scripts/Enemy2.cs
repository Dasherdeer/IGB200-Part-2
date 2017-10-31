using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    public bool moveRight = true;
    public bool lookRight = true;
    public float moveSpeed = 3f;
    Rigidbody2D rb;
    public GameObject target;
    public Transform firePoint;
    public GameObject projectile;
    public GameObject thisEnemyVision;
    private GameObject player;
    public float fireRate = 0.3f;
    private float fireTime;
    public bool playerInRange = false;
    private int direction = 1;
    public StunIndicator si;
    public SpriteRenderer sr;
    private bool stunned;
    private int damageToGive = 1;
    private float damageToPlayerRate = 1f;
    private float damageToPlayerTime;
    public Collider thisCollider;

    public int EnemyNumber; //for debugging


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        si = GetComponentInChildren<StunIndicator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (!stunned) {
            if (thisEnemyVision.GetComponent<EnemyVision>().playerSeen && GameMaster.particleWorld && !player.GetComponent<Player>().isHidden())
            {
                if (player.transform.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    lookRight = true;
                }
                else if (player.transform.position.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    lookRight = false;
                }
                rb.velocity = new Vector2(0, 0);
                Invoke("Shoot", 0.3f);
            }
            else {
                if (moveRight)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                }
                else
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                }
            }

            if (si.stunEnemy && !si.stunFailed) {
                sr.color = Color.red;
                rb.velocity = new Vector2(0, 0);
                stunned = true;
            } else if (!si.stunEnemy && si.stunFailed && Time.time > damageToPlayerTime) {
                HealthManager.DamagePlayer(damageToGive);
                damageToPlayerTime = Time.time + damageToPlayerRate;
            }
        }


        //for debugging
        if (si == null)
        {
            Debug.Log("Enemy number " + EnemyNumber + " is fucking it up for everyone");
        }
    }

    void Shoot() {
        if (Time.time > fireTime) {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            fireTime = Time.time + fireRate;
        }
    }

     
}



