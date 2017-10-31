using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private GameObject player;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    private float gravityStore;
    public int pointPenaltyOnDeath = 5;
    public float respawnDelay = 1.0f;
    public HealthManager healthManager;
    public static int playerRespawnCount;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); //changed player from type Player to GameObject
        healthManager = FindObjectOfType<HealthManager>();
        playerRespawnCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer() {
        StartCoroutine("RespawnPlayerCo");
    }

    //edited this a little so that its not reloading the scene
    public IEnumerator RespawnPlayerCo() {

        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.SetActive(false);
        /*player.GetComponent<Renderer>().enabled = false;
        gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;*/
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        playerRespawnCount += 1;
        GetComponent<AudioSource>().Play();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameMaster.particleWorld = true;
        //ScoreManager.ResetScore();
        //AmmoManager.ResetAmmo();
        //player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        //player.enabled = true;
        //player.transform.localScale = new Vector3(1f, 1f, 1f);
        //player.GetComponent<Renderer>().enabled = true;
        healthManager.RevivePlayer();
        //healthManager.isDead = false;
        player.transform.position = currentCheckpoint.transform.position;
        player.SetActive(true);
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }

}
