using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    GamesPlayedSetter gamesPlayedSetterScript;
    AdsManager adsManagerScript;

    void Start()
    {
        gamesPlayedSetterScript = GameObject.FindObjectOfType<GamesPlayedSetter>();
        adsManagerScript = GameObject.FindObjectOfType<AdsManager>();
    }

    public void OnReplayButtonClicked()
    {
        if(adsManagerScript.reviveAdsWatched != 1)
        {
            gamesPlayedSetterScript.SetGamesPlayed();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
