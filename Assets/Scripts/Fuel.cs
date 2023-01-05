using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    HealthBar healthBar;
    FuelParticlesSpawner fuelParticlesSpawnerScript;
    AudioSource fuelGrabbedSound;

    void Start()
    {
        healthBar = GameObject.FindObjectOfType<HealthBar>();
        fuelParticlesSpawnerScript = GameObject.FindObjectOfType<FuelParticlesSpawner>();
        fuelGrabbedSound = GameObject.FindGameObjectWithTag("FuelGrabbedSound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            fuelGrabbedSound.Play();
            healthBar.currentFuel += 0.15f;
            healthBar.CheckMaximumFuel();
            fuelParticlesSpawnerScript.SpawnFuelParticles();
            Destroy(gameObject);
        }
    }
}
