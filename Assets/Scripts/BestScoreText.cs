using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreText : MonoBehaviour
{
    Text bestScoreText;
    BestScoreSetter bestScoreSetterScript;

    void Start()
    {
        AssignVariables();
    }

    void Update()
    {
        SetBestScoreText();
    }

    void AssignVariables()
    {
        bestScoreText = GetComponent<Text>();
        bestScoreSetterScript = GameObject.FindObjectOfType<BestScoreSetter>();
    }

    void SetBestScoreText()
    {
        if(bestScoreSetterScript.bestScore >= 10)
        {
           bestScoreText.text = "BEST SCORE: " + bestScoreSetterScript.bestScore.ToString();
        }
        
        if(bestScoreSetterScript.bestScore < 10)
        {
           bestScoreText.text = "BEST SCORE: " + "0" + bestScoreSetterScript.bestScore.ToString();
        }
    }
}
