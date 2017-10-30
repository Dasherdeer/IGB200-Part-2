using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour {
    public static float energy;
    private LevelManager levelManager;
    public BarScript bar;
    public static int maxEnergy = 7;

    private void Awake() {
    }

    // Use this for initialization
    void Start() {
        energy = maxEnergy;
    }

    // Update is called once per frame
    void Update() {
        if (energy <= 0) {
            energy = 0;
            GameMaster.particleWorld = true;
        } else if (energy >= maxEnergy) {
            energy = maxEnergy;
        }
        if (!GameMaster.particleWorld) {
            energy -= Time.deltaTime;
        } else {
            energy += 2 * Time.deltaTime;
        }
        
        bar.fillAmount = energy / maxEnergy;
    }

    public float getEnergy()
    {
        return energy;
    }


}
