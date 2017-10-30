using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsMenuScript : MonoBehaviour {

	public Canvas instructionMenu;
	public Button returnText;

	// Use this for initialization
	void Start () {

		instructionMenu = instructionMenu.GetComponent<Canvas> ();
		returnText = returnText.GetComponent<Button> ();
	}



	public void StartLevel () {

		Application.LoadLevel (0);
	}
		

}