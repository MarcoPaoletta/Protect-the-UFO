using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamesPlayedText : MonoBehaviour
{
    Text gamesPlayedText;
    GamesPlayedSetter gamesPlayedSetterScript;

    void Start()
    {
        AssignVariables();
        SetGamesPlayedText();
    }

    void AssignVariables()
    {
        gamesPlayedText = GetComponent<Text>();
        gamesPlayedSetterScript = GameObject.FindObjectOfType<GamesPlayedSetter>();
    }

    void SetGamesPlayedText()
    {
        gamesPlayedText.text = "GAMES PLAYED: " + gamesPlayedSetterScript.gamesPlayed.ToString();
    }
}
