using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    Text text;
    public static int gems = 0;

    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        if (gems < 0) {
            gems = 0;
        }

        text.text = "" + gems;
    }

    public static void AddPoints(int pointsToAdd) {
        gems += pointsToAdd;
    }

    public static void ResetScore() {
        gems = 0;
    }

}
