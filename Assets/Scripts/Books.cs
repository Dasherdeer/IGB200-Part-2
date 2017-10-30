using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Books : MonoBehaviour {


    // Use this for initialization
    void Start() {

    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            BookText.textNumber += 1;
            BookText.NextText();
            BookCounter.AddBook();

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            BookText.ClearText();
            Destroy(gameObject);
        }
    }
}
