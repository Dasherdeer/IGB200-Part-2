using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour {

    private bool playerInZone;

    public string levelToLoad;

    public RawImage img;
    public Text levelCompleteTitle;
    public Text levelList;
    public Text listResults;
    public Text finalScore;
    public int finalScoreInt;
    public static int enemiesKilled;
    public static int enemiesStunned;

	// Use this for initialization
	void Start () {
        playerInZone = false;
        img.enabled = false;
        levelCompleteTitle.enabled = false;
        levelList.enabled = false;
        listResults.enabled = false;
        finalScore.enabled = false;
	}

    // Update is called once per frame
    void Update() {
        if (playerInZone) {
            img.enabled = true;
            levelCompleteTitle.enabled = true;
            levelList.enabled = true;
            listResults.enabled = true;
            finalScore.enabled = true;
            listResults.text = "" + ScoreManager.gems + "\n" + enemiesKilled + "\n" + enemiesStunned + "\n" + BookCounter.books + "\n" + GemManager.bigGems + "\n";
            finalScoreInt = ScoreManager.gems * 10 + enemiesKilled * 20 + enemiesStunned * 30 + BookCounter.books * 30 + GemManager.bigGems * 50;
            finalScore.text = "TOTAL SCORE         " + finalScoreInt;
            Invoke("LoadNextLevel", 5);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            playerInZone = true;

        }
    }

    private void LoadNextLevel() {
        SceneManager.LoadScene("Labs");
    }


}
