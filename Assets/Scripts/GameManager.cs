using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isDead;

    GameObject gameOverCanvas;
    GameObject fuelCanvas;
    GameObject scoreGUI;
    GameObject player;
    SpikesDestroyer spikesDestroyerScript;
    GamesPlayedSetter gamesPlayedSetterScript;
    BestScoreSetter bestScoreSetterScript;
    AudioSource deathSound;

    void Awake()
    {
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
        fuelCanvas = GameObject.FindGameObjectWithTag("FuelCanvas");
        scoreGUI = GameObject.FindGameObjectWithTag("ScoreGUI");
        player = GameObject.FindGameObjectWithTag("Player");
        spikesDestroyerScript = GameObject.FindObjectOfType<SpikesDestroyer>();
        gamesPlayedSetterScript = GameObject.FindObjectOfType<GamesPlayedSetter>();
        bestScoreSetterScript = GameObject.FindObjectOfType<BestScoreSetter>();
        deathSound = GameObject.FindGameObjectWithTag("DeathSound").GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        deathSound.Play();
        gameOverCanvas.SetActive(true);
        gameOverCanvas.GetComponent<GameOverCanvas>().GameOverCanvasReactivated();
        spikesDestroyerScript.DestroySpikes();
        Destroy(fuelCanvas.gameObject);
        Destroy(scoreGUI.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("Fuel"));
        isDead = true;
    }
}
