using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookText : MonoBehaviour {

    public static string message;
    Text text;
    public static int textNumber;
    public RawImage img;
    public static bool bookEnabled;

    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
        textNumber = 0;
        message = "";
        bookEnabled = false;

    }

    // Update is called once per frame
    void Update() {
        text.text = message;
        if (bookEnabled) {
            img.enabled = true;
        } else {
            img.enabled = false;
            text.text = "";
        }

    }

    public static void ClearText() {
        bookEnabled = false;
    }

    public static void NextText() {
        bookEnabled = true;
        if (textNumber == 1) {
            message = "On June 16th, 2048, on a cold winter night, a young mother makes the hard decision to leave her baby girl at the doorsteps of an orphanage with nothing but a single piece of paper containing a name. The young girl that name belonged to" +
                " would grow up to do remarkable things. That name will be remembered in history. That name is Skylar.";
        } else if (textNumber == 2) {
            message = "Skylars childhood consisted of her being transferred from foster home to foster home to foster home. She would be in one place for a couple of weeks before being sent back. Their reasoning, “She’s a problem child" +
                " How was she a problem child exactly? Well Skylar was considered a genius amongst the other children, however along with her geniusness came a dark side. Because of her ‘mischievous’ ways, skylar landed herself in juvenile detention on multiple occasions. ";
        } else if (textNumber == 3) {
            message = "At 18 Skylar was finally an adult and out of the foster system, free to live her life as she pleased, no one telling her how to act or what to do. For many years her special skill set and intelligence were desirable by many people," +
                "hiring her to do multiple jobs ranging from theft, threats and eventually assassinations.";
        } else if (textNumber == 4) {
            message = "By the time Skylar reached 24 she had made a name for herself and became a well-known rogue, someone that went against the corrupt and abusive government. She was no longer hired for theft or threats, but just assassinations, she was exceptionally" +
                " good at what she did and everyone wanted her.";
        } else if (textNumber == 5) {
            message = "On day, while Skylar was out on a job she was approached by a group of rogues that called themselves the Revolutionists. This group had finally decided it was time to take major action against the government and the mafia controlling." +
                "But in order to do so they needed someone with a specific skill set, someone that would go to extremes to complete the mission. They were looking for Skylar and would pay her a hefty price.";
        } else if (textNumber == 6) {
            message = "As a rogue herself, Skylar had personally suffered at the hands of the government. She had a bone to pick with them. She didn’t like what they stood for she was eager to join the Revolutionists and put a stop to it all. " +
                "That was her first mission in taking action against the government. Now Skylar fills her days by completing assassinations for multiple rogue groups, usually targeting very important government or mafia leaders. " +
                "Everyone knows who she is, the rogue groups want her and the Government wants her dead.";
        }


    }


}
