using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    Text gameOverScoreText;
    Text bestScoreText;
    ScoreText scoreTextScript;
    BestScoreSetter bestScoreSetterScript;
    BestScoreText bestScoreTextScript;
    ReviveButton reviveButtonScript;

    void Start()
    {
        gameOverScoreText = GameObject.FindGameObjectWithTag("GameOverScore").GetComponent<Text>();
        scoreTextScript = GameObject.FindObjectOfType<ScoreText>();
        bestScoreSetterScript = GameObject.FindObjectOfType<BestScoreSetter>();
        bestScoreTextScript = GameObject.FindObjectOfType<BestScoreText>();
        gameObject.SetActive(false);
    }

    public void GameOverCanvasReactivated()
    {
        SetGameOverScoreText();
        ResetLastScore();
        reviveButtonScript.StartCoroutine(reviveButtonScript.CheckInternetConnection());
        reviveButtonScript.CheckReviveButtonDisponibility();
    }

    void SetGameOverScoreText()
    {
        if(scoreTextScript.score >= 10)
        {
            gameOverScoreText.text = scoreTextScript.score.ToString();
        }
        
        if(scoreTextScript.score < 10)
        {
            gameOverScoreText.text = "0" + scoreTextScript.score.ToString();
        }
    }

    void ResetLastScore()
    {
        reviveButtonScript = GameObject.FindObjectOfType<ReviveButton>();
        reviveButtonScript.ResetLastScore();
    }
}
