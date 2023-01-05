using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{
    [HideInInspector] public string rewardType;
    [HideInInspector] public int reviveAdsWatched;
    [HideInInspector] public bool showingRewardedAd;

    string appId = "5100914";
    bool testMode = false;
    Player playerScript;
    ReviveButton reviveButtonScript;
    ShopCanvas shopCanvasScript;
    GamesPlayedSetter gamesPlayedSetterScript;

    void Start()
    {
        Advertisement.Initialize(appId, testMode, this);
        AssignVariables();
    }

    void AssignVariables()
    {
        reviveAdsWatched = PlayerPrefs.GetInt("ReviveAdsWatched");
        playerScript = GameObject.FindObjectOfType<Player>();
        reviveButtonScript = GameObject.FindObjectOfType<ReviveButton>();
        shopCanvasScript = GameObject.FindObjectOfType<ShopCanvas>();
        gamesPlayedSetterScript = GameObject.FindObjectOfType<GamesPlayedSetter>();
    }

    public void ShowRewardedAd()
    {
        Advertisement.Load("Rewarded_Android");
        Advertisement.Show("Rewarded_Android", this);
        showingRewardedAd = true;
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print("Failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("Start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        print("Click");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if(placementId == "Rewarded_Android" && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            playerScript.loadingAdCanvasShowing = false;
            showingRewardedAd = false;

            if(rewardType == "Revive")
            {
                reviveAdsWatched += 1;
                PlayerPrefs.SetInt("ReviveAdsWatched", reviveAdsWatched);
                reviveButtonScript.ClaimRewardOfReviving();
            }

            if(rewardType == "UFO2")
            {
                shopCanvasScript.UFO2Achieved();
            }

            if(rewardType == "UFO3")
            {
                shopCanvasScript.UFO3Achieved();
            }
        }

        Destroy(GameObject.FindGameObjectWithTag("LoadingAdCanvas"));
    }

    public void OnInitializationComplete()
    {
        print("Initialization completed");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print("Initialization failed");
    }
}
