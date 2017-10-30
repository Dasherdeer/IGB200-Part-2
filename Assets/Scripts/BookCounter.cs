using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookCounter : MonoBehaviour {

    Text text;
    public static int books = 0;

    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        if (books < 0) {
            books = 0;
        }

        text.text = "" + books;
    }

    public static void AddBook() {
        books += 1;
    }

    public static void ResetScore() {
        books = 0;
    }
}
