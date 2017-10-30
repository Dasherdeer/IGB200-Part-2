using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button instructionText;
	public Button exitText;

	// Use this for initialization
	void Start () {

		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		instructionText = instructionText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
	}

	public void ExitPress() {

		quitMenu.enabled = true;
		startText.enabled = false;
		instructionText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress() {

		quitMenu.enabled = false;
		startText.enabled = true;
		instructionText.enabled = true;
		exitText.enabled = true;
	}

	public void StartLevel () {

		Application.LoadLevel (1);
	}

	public void InstructionMenu () {

		Application.LoadLevel (2);
	}

	public void ExitGame() {

		Application.Quit ();
	}
}