using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public GameObject tutorial;
    public float letterPause = 0.007f;
    string message;
    Text textComp;
    private bool tutorialStepComplete = false;
    int textNumber;
    int letterNumber;
    int finalNumber;

    // Use this for initialization
    void Start() {
        textComp = GetComponent<Text>();
        textNumber = -1;
        textComp.text = "";

    }

    // Update is called once per frame
    void Update() {
        if (letterNumber < finalNumber)
        {
            textComp.text += message[letterNumber];
            letterNumber++;
        }
    }

    public void ClearText() {
        textComp.text = "";
        textNumber += 1;
        NextText(textNumber);
        finalNumber = message.Length;
        letterNumber = 0;
    }

    void NextText(int textNumber) {
        if (textNumber == 0) {
            message = "Hello Skylar. Yes, I know who you are. Think of me as a friend. I have a mission for you. But first, let's go over the basics. Use W, A and D to move around.";
        } else if (textNumber == 1) {
            message = "Coins can be found lying around throughout the level, and I want them. If you collect them all for me, I will give you a bonus.";
        } else if (textNumber == 2) {
            message = "Looks like something is there. You haven't forgotten about your gift have you? Are you going to walk around in Particle form all day or do you think maybe you should see what hidden objects exist in your Wave form? Press C to change worlds.";
        } else if (textNumber == 3) {
            message = "You found some health and ammunition, these can save you so make sure to keep an eye out.";
        } else if (textNumber == 4) {
            message = "Be careful to watch your energy meter, you can't stay in that world for too long";
        } else if (textNumber == 5) {
            message = "Looks like you have spotted an enemy. There are many ways you can deal with this. Why don't you try hiding in that barrel by pressing X? ";
		} else if (textNumber == 6) {
			message = "The walls ahead will kill you if you try to pass through them in the wrong form. Think fast.";
		} else if (textNumber == 7) {
			message = "If you don’t want to hide, you can always kill them. You are an assassin anyway, I wouldn't expect any better. Try killing that enemy by pressing Z to shoot your gun.";
		} else if (textNumber == 8) {
			message = "As well as seeing hidden objects, in your Wave form you can jump further, be completely hidden from enemies, and stun them for 3 seconds by matching your wave colour with theirs. Oh... and don't forget about the clouds.";
		} else if (textNumber == 9) {
			message = "I guess that is all you need to know. Meet me at the laboratory, we have much to discuss.";
		} else
        {
            tutorial.SetActive(false);
        }
    }

}

