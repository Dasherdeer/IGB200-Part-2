using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol1 : MonoBehaviour {

    public Enemy2 associatedEnemy; //the enemy the patrol collider is attached to

    //collision variables
    private float collisionRate = 0.3f;
    private float collisionTime;

    public bool mov;//check which direction enemy is moving in

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //sets mov to which diresction enemy is moving in
        mov = associatedEnemy.moveRight;
	}
    
    //moves enemy based on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyCheckpoint" && Time.time > collisionTime)
        {
            associatedEnemy.moveRight = !associatedEnemy.moveRight;
            collisionTime = Time.time + collisionRate;
        }
    }
}
