using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public float moveSpeed = 2;
    public bool moveRight;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;
    private bool grounded;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (!grounded) {
            moveRight = !moveRight;
        }

        if (moveRight) {
            transform.localScale = new Vector3(-2f, 2f, 2f);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        } else {
            transform.localScale = new Vector3(2f, 2f, 2f);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
		
	}
}
