using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour {
    Text text;
    public static int ammo = 0;

    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        if (ammo < 0) {
            ammo = 0;
        }

        text.text = "" + ammo;
    }

    public static void AddAmmo(int ammoToAdd) {
        ammo += ammoToAdd;
    }

    public static void ResetAmmo() {
        ammo = 0;
    }

}
