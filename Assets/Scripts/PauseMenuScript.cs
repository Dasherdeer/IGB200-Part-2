using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour {

	public Canvas pauseMenu;
	public Button resumeText;
	public Button quitText;


	// Use this for initialization
	void Start () {

		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		resumeText = resumeText.GetComponent<Button> ();
		quitText = quitText.GetComponent<Button> ();
		pauseMenu.enabled = false;
	}


	//if Esc is pressed pause menu appear and game stops.
	public void PausePress() {


		pauseMenu.enabled = true;
		resumeText.enabled = true;
		quitText.enabled = true;
	}



	// if resume is clicked game resumes.
	//if quit to menu is clicked then sent to menu

	public void QuitLevel () {

		Application.LoadLevel (0);
	}

}
