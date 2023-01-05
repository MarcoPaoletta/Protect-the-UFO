using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ReviveButton : MonoBehaviour
{
    [SerializeField] GameObject loadingAdCanvas;

    ScoreText scoreTextScript;
    AdsManager adsManagerScript;
    int lastScore;

    void Awake()
    {
        scoreTextScript = GameObject.FindObjectOfType<ScoreText>();
        adsManagerScript = GameObject.FindObjectOfType<AdsManager>();
        lastScore = PlayerPrefs.GetInt("LastScore");
    }

    public IEnumerator CheckInternetConnection()
    {
        string googleUrl = "http://google.com";
        UnityWebRequest webRequest = new UnityWebRequest(googleUrl);
        yield return webRequest.SendWebRequest();

        if(webRequest.error != null)
        {
            gameObject.SetActive(false);
        }

        if(webRequest.error == null)
        {
            gameObject.SetActive(true);
        }
    }

    public void CheckReviveButtonDisponibility()
    {
        if(adsManagerScript.reviveAdsWatched >= 1)
        {
            adsManagerScript.reviveAdsWatched = 0;
            PlayerPrefs.SetInt("ReviveAdsWatched", adsManagerScript.reviveAdsWatched);
            gameObject.SetActive(false);
            return;
        }

        if(adsManagerScript.reviveAdsWatched < 1)
        {
            gameObject.SetActive(true);
        }
    }

    public void ClaimRewardOfReviving()
    {
        lastScore = scoreTextScript.score;
        PlayerPrefs.SetInt("LastScore", lastScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore()
    {
        scoreTextScript.score = lastScore;
    }

    public void ResetLastScore()
    {
        lastScore = 0;
        PlayerPrefs.SetFloat("LastScore", lastScore);
    }

    public void OnReviveButtonClicked()
    {
        adsManagerScript.rewardType = "Revive";
        Instantiate(loadingAdCanvas, transform.position, Quaternion.identity);
    }
}
