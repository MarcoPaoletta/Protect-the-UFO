using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingAdCanvas : MonoBehaviour
{
    GameObject shopCanvas;
    Text loadingAdCounter;
    int timeElapsed;
    GameObject cancelAdButton;
    Player playerScript;
    AdsManager adsManagerScript;
    ShopCanvas shopCanvasScript;

    void Start()
    {
        AssignVariables();
        PauseGame();
        CheckCancelAdVisibility();
        SetParent();
        InvokeRepeating("SetLoadingAdCounterText", 1, 1);
    }

    void AssignVariables()
    {
        shopCanvas = GameObject.FindGameObjectWithTag("ShopCanvas");
        loadingAdCounter = GameObject.Find("LoadingAdCounterText").GetComponent<Text>();
        cancelAdButton = GameObject.Find("CancelAdButton");
        playerScript = GameObject.FindObjectOfType<Player>();
        adsManagerScript = GameObject.FindObjectOfType<AdsManager>();
        shopCanvasScript = GameObject.FindObjectOfType<ShopCanvas>();
    }

    void PauseGame()
    {
        if(playerScript != null)
        {
            playerScript.loadingAdCanvasShowing = true;
        }
    }

    void SetParent()
    {
        if(playerScript != null)
        {
            transform.SetParent(shopCanvas.transform);
        }
    }

    void SetLoadingAdCounterText()
    {
        timeElapsed += 1;
        loadingAdCounter.text = timeElapsed.ToString();
        CheckCancelAdVisibility();
        adsManagerScript.ShowRewardedAd();
    }

    void CheckCancelAdVisibility()
    {
        if(timeElapsed >= 10)
        {
            cancelAdButton.SetActive(true);
        }
        
        if(timeElapsed < 10)
        {
            cancelAdButton.SetActive(false);
        }
    }

    public void OnCancelAdButtonClicked()
    {
        if(playerScript != null)
        {
            playerScript.loadingAdCanvasShowing = false;
        }

        shopCanvasScript.selectedButtonIndex = 0;
        PlayerPrefs.SetInt("SelectedButtonIndex", shopCanvasScript.selectedButtonIndex);
        shopCanvasScript.RestartButtonColors();
        shopCanvasScript.SetInitialSelectedButtonColor();
        playerScript.spriteRenderer.sprite = playerScript.ufosSprites[0];
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
