using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarScript : MonoBehaviour {

    public float fillAmount;
    [SerializeField] private Image fill;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateBar();
	}

    private void UpdateBar() {
        if (fillAmount != fill.fillAmount) {
            fill.fillAmount = fillAmount;
        }
            
    }

}
