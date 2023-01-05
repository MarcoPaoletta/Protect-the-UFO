using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesQuantity : MonoBehaviour
{
    [HideInInspector] public int spikesQuantity;

    ScoreText scoreTextScript;

    void Start()
    {
        scoreTextScript = GameObject.FindObjectOfType<ScoreText>();
    }

    public void SetSpikesQuantity()
    {
        if(scoreTextScript.score >= 15)
        {
            spikesQuantity = 5;
        }
        
        else if(scoreTextScript.score >= 10)
        {
            spikesQuantity = 4;
        }
        
        else if(scoreTextScript.score >= 5)
        {
            spikesQuantity = 3;
        }

        else if(scoreTextScript.score < 5)
        {
            spikesQuantity = 2;
        }
    }
}
