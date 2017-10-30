using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static float playerHealth;
    private LevelManager levelManager;
    public bool isDead;
    public BarScript bar;
    private float maxPlayerHealth = 5;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            isDead = true;
        }
        bar.fillAmount = playerHealth / maxPlayerHealth;
    }

    public static void AddHealth(int healthToAdd)
    {
        playerHealth += healthToAdd;
    }

    public static void DamagePlayer(float damageToGive)
    {
		playerHealth -= damageToGive;

    }

    public void RevivePlayer()
    {
        playerHealth = maxPlayerHealth;
        isDead = false;
    }

}
