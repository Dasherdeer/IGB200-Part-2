using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour {

    public Text interact;
    public Transform boxLocation;
    Camera cam;
    Vector2 screenPos;
    public static bool boxInRange;

    // Use this for initialization
    void Start() {
        cam = Camera.main;
        boxLocation = transform;
        interact = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            screenPos = cam.WorldToScreenPoint(boxLocation.position);
            boxInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player") {
            boxInRange = false;
        }
        
    }

    private void OnGUI() {

    }


}
