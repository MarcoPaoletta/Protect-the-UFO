using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreSetter : MonoBehaviour
{
    ScoreText scoreTextScript;
    public int bestScore = 0;

    void Awake()
    {
        scoreTextScript = GameObject.FindObjectOfType<ScoreText>();
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    void Update()
    {
        GetBestScore();
    }

    public void GetBestScore()
    {
        if(scoreTextScript.score >= bestScore)
        {
            bestScore = scoreTextScript.score;
        }

        PlayerPrefs.SetInt("BestScore", bestScore);
    }
}
