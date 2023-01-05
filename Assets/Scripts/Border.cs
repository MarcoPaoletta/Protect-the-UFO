using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    Player playerScript;
    ScoreText scoreTextScript;
    SpikesPositioning spikesPositioningScript;
    ThemeChanger themeChangerScript;
    SpikesQuantity spikesQuantityScript;
    FuelSpawner fuelSpawnerScript;
    BorderParticlesSpawner borderParticlesSpawnerScript;
    AudioSource borderSound;

    void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
        scoreTextScript = GameObject.FindObjectOfType<ScoreText>();
        spikesPositioningScript = GameObject.FindObjectOfType<SpikesPositioning>();
        themeChangerScript = GameObject.FindObjectOfType<ThemeChanger>();
        spikesQuantityScript = GameObject.FindObjectOfType<SpikesQuantity>();
        fuelSpawnerScript = GameObject.FindObjectOfType<FuelSpawner>();
        borderParticlesSpawnerScript = GameObject.FindObjectOfType<BorderParticlesSpawner>();
        borderSound = GameObject.FindGameObjectWithTag("BorderSound").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            scoreTextScript.Scored();
            playerScript.movementForce *= -1;
            CheckThemChanging();
            spikesQuantityScript.SetSpikesQuantity();
            spikesPositioningScript.SpawnSpikes();
            fuelSpawnerScript.SpawnFuel();
            borderParticlesSpawnerScript.SpawnBorderParticles();
            borderSound.Play();
        }
    }

    void CheckThemChanging()
    {
        if(scoreTextScript.score % 5 == 0)
        {
            themeChangerScript.ChangeTheme();
        }
    }
}
