using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [HideInInspector] public int score;

    TextMeshPro scoreText;
    SpikesPositioning spikesPositioning;
    ReviveButton reviveButtonScript;

    void Awake()
    {
        AssignVariables();
        reviveButtonScript.UpdateScore();
        UpdateScoreText();
    }

    void AssignVariables()
    {
        scoreText = GetComponent<TextMeshPro>();
        spikesPositioning = FindObjectOfType<SpikesPositioning>();
        reviveButtonScript = GameObject.FindObjectOfType<ReviveButton>();
    }

    void UpdateScoreText()
    {
        if(score >= 10)
        {
            scoreText.text = score.ToString();
        }
        
        if(score < 10)
        {
            scoreText.text = "0" + score.ToString();
        }
    }

    public void Scored()
    {
        score += 1;

        if(score >= 10)
        {
            scoreText.text = score.ToString();
        }
        
        if(score < 10)
        {
            scoreText.text = "0" + score.ToString();
        }
    }
}
