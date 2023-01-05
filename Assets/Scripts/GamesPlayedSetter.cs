using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesPlayedSetter : MonoBehaviour
{
    [HideInInspector] public string isRevived;
    [HideInInspector] public int gamesPlayed = 0;

    void Awake()
    {
        gamesPlayed = PlayerPrefs.GetInt("GamesPlayed");
    }

    public void SetGamesPlayed()
    {
        gamesPlayed += 1;
        PlayerPrefs.SetInt("GamesPlayed", gamesPlayed);
    }
}
