using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPoint : MonoBehaviour {

    public Tutorial tutorial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Runs next line of tutorial code when the player triggers it, then disables itself
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            tutorial.ClearText();
            gameObject.SetActive(false);
        }
    }
}
