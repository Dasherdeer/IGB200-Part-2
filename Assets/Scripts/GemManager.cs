using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemManager : MonoBehaviour {

    Text text;
    public static int bigGems = 0;

    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        if (bigGems < 0) {
            bigGems = 0;
        }

        text.text = "" + bigGems;
    }

    public static void AddPoints(int pointsToAdd) {
        bigGems += pointsToAdd;
    }

    public static void ResetScore() {
        bigGems = 0;
    }

}
