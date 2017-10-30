using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public static bool particleWorld = true;
    GameObject[] boxes;
    GameObject[] enemies;
    GameObject[] ammos;
    GameObject[] healths;
    GameObject[] stunIndicators;
    public GameObject[] pinkClouds;
    GameObject energyBar;
    GameObject stunIndicatorPlayer;
    public RawImage img;
    public GameObject EnergyManager;
    public AudioClip SwitchWorlds;

    // Use this for initialization
    void Start() {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        ammos = GameObject.FindGameObjectsWithTag("Ammo");
        healths = GameObject.FindGameObjectsWithTag("Health");
        energyBar = GameObject.FindGameObjectWithTag("EnergyBar");
        stunIndicators = GameObject.FindGameObjectsWithTag("StunIndicator");
        stunIndicatorPlayer = GameObject.FindGameObjectWithTag("PlayerStunIndicator");
        pinkClouds = GameObject.FindGameObjectsWithTag("PinkPlat");
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.C)||Input.GetKey(KeyCode.Period)) {
            AudioSource.PlayClipAtPoint(SwitchWorlds, GameObject.FindGameObjectWithTag("Player").transform.position);
            particleWorld = !particleWorld;
            foreach (GameObject pink in pinkClouds)
            {
                if (pink)
                {
                    pink.GetComponent<SpriteRenderer>().enabled = !pink.GetComponent<SpriteRenderer>().enabled;

                    pink.GetComponent<PolygonCollider2D>().enabled = !pink.GetComponent<PolygonCollider2D>().enabled;
                }
            }
        }

        if (EnergyManager.GetComponent<EnergyManager>().getEnergy() <= 0f)
        {
            AudioSource.PlayClipAtPoint(SwitchWorlds, GameObject.FindGameObjectWithTag("Player").transform.position);
            foreach (GameObject pink in pinkClouds)
            {
                if (pink)
                {
                    SpriteRenderer pinkRend = pink.GetComponent<SpriteRenderer>();
                    pinkRend.enabled = !pinkRend.enabled;

                    PolygonCollider2D pinkPoly = pink.GetComponent<PolygonCollider2D>();
                    pinkPoly.enabled = !pinkPoly.enabled;
                }
            }
        }

        if (particleWorld) {
            foreach (GameObject ammo in ammos) {
                if (ammo) {
                    ammo.SetActive(false);
                }
            }
            foreach (GameObject health in healths) {
                if (health) {
                    health.SetActive(false);
                }
            }
            foreach (GameObject si in stunIndicators) {
                if (si) {
                    si.SetActive(false);
                }
            }
                
            
            stunIndicatorPlayer.SetActive(false); 
            img.enabled = false;

        } else {
            foreach (GameObject ammo in ammos) {
                if (ammo) {
                    ammo.SetActive(true);
                }
            }
            foreach (GameObject health in healths) {
                if (health) {
                    health.SetActive(true);
                }
            }
            foreach (GameObject si in stunIndicators) {
                if (si) {
                    si.SetActive(true);
                }
            }


            stunIndicatorPlayer.SetActive(true);
            img.enabled = true;
        }
    }

}
