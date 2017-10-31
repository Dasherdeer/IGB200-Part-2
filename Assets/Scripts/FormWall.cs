using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormWall : MonoBehaviour {

    public bool waveWall = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && ((waveWall && !GameMaster.particleWorld) || (!waveWall && GameMaster.particleWorld)))
        {
            HealthManager.DamagePlayer(50f);
        }
    }
}
