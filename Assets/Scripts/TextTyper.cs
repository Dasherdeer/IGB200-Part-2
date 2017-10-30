using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTyper : MonoBehaviour {

    public float letterPause = 0.01f;
    string message;
    Text textComp;

	// Use this for initialization
	void Start () {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TypeText() {
        foreach (char letter in message.ToCharArray()) {
            textComp.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
