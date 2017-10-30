using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunIndicatorPlayer : MonoBehaviour {

    public Color lerpedColor = Color.red;
    private RawImage img;
    // Use this for initialization
    void Start() {
        img = gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update() {
        lerpedColor = Color.Lerp(Color.red, Color.green, Mathf.PingPong(Time.time*0.7f, 1));
        img.color = lerpedColor;
    }
}
