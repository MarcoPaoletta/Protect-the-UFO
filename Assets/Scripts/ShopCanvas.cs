using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ShopCanvas : MonoBehaviour
{
    [HideInInspector] public int selectedSprite;
    [HideInInspector] public int selectedButtonIndex;

    [SerializeField] GameObject loadingAdScreen;

    Button[] buttonsArray;
    List<Button> buttons = new List<Button>();
    GameObject buttonsContainer;
    Player playerScript;
    AdsManager adsManagerScript;
    TrailRendererManager trailRendererManagerScript;
    string htmlDefaultButtonColor = "#D4D4D4";
    Color defaultButtonColor;
    string htmlSelectedButtonColor = "#797677";
    Color selectedButtonColor;
    GameObject button1AdIcon;
    GameObject button2AdIcon;
    string ufo2Achieved;
    string ufo3Achieved;

    void Start()
    {
        AssignVariables();
        // ResetShop();
        SetInitialSelectedButtonColor();
        SetAchievedItems();    
        SetInitialPlayerSpriteRenderer();
        SetInitialTrailRendererColor();
    }

    void ResetShop()
    {
        ufo2Achieved = "No";
        PlayerPrefs.SetString("UFO2Achieved", ufo2Achieved);
        ufo3Achieved = "No";
        PlayerPrefs.SetString("UFO3Achieved", ufo3Achieved);
    }

    void AssignVariables()
    {
        buttonsContainer = GameObject.Find("ButtonsContainer");
        buttonsArray = GameObject.Find("ButtonsContainer").transform.GetComponentsInChildren<Button>();
        ColorUtility.TryParseHtmlString(htmlDefaultButtonColor, out defaultButtonColor);
        ColorUtility.TryParseHtmlString(htmlSelectedButtonColor, out selectedButtonColor);
        playerScript = GameObject.FindObjectOfType<Player>();
        trailRendererManagerScript = GameObject.FindObjectOfType<TrailRendererManager>();
        button1AdIcon = buttonsContainer.transform.Find("UFO1Button").transform.Find("AdIcon").gameObject;
        button2AdIcon = buttonsContainer.transform.Find("UFO2Button").transform.Find("AdIcon").gameObject;
        selectedButtonIndex = PlayerPrefs.GetInt("SelectedButtonIndex");
        adsManagerScript = GameObject.FindObjectOfType<AdsManager>();
        ufo2Achieved = PlayerPrefs.GetString("UFO2Achieved");
        ufo3Achieved = PlayerPrefs.GetString("UFO3Achieved");

        foreach(var button in buttonsArray)
        {
            buttons.Add(button);
        }  
    }

    public void SetInitialSelectedButtonColor()
    {
       GameObject selectedButton = buttonsContainer.transform.Find("UFO" + selectedButtonIndex.ToString() + "Button").gameObject;
       selectedButton.GetComponent<Image>().color = selectedButtonColor;
    }

    void SetAchievedItems()
    {
        if(ufo2Achieved == "Yes")
        {
            Destroy(button1AdIcon);
        }

        if(ufo3Achieved == "Yes")
        {
            Destroy(button2AdIcon);
        }
    }

    void SetInitialPlayerSpriteRenderer()
    {
        playerScript.spriteRenderer.sprite = playerScript.ufosSprites[selectedButtonIndex];
    }

    void SetInitialTrailRendererColor()
    {
        trailRendererManagerScript.SetTrailColor(selectedButtonIndex);
    }

    public void OnUFO1ButtonClicked()
    {
        ButtonClicked("0");
    }

    public void OnUFO2ButtonClicked()
    {
        ButtonClicked("1");
        CheckRewardedAdVisibility("1", "2");
    }

    public void OnUFO3ButtonClicked()
    {
        ButtonClicked("2");
        CheckRewardedAdVisibility("2", "3");
    }

    void ButtonClicked(string buttonIndex)
    {
        RestartButtonColors();
        SetSelectedButtonColor(buttonIndex);

        if(PlayerPrefs.GetString("UFO" + (int.Parse(buttonIndex) + 1).ToString() + "Achieved") == "Yes" || buttonIndex == "0")
        {
            selectedSprite = int.Parse(buttonIndex);
            playerScript.SetSpriteRenderer(selectedSprite);
        }
    }

    public void RestartButtonColors()
    {
        foreach(var button in buttons)
        {
            button.GetComponent<Image>().color = defaultButtonColor;
        }
    }

    void SetSelectedButtonColor(string buttonIndex)
    {
        buttonsContainer.transform.Find("UFO" + buttonIndex + "Button").GetComponent<Image>().color = selectedButtonColor;
        selectedButtonIndex = int.Parse(buttonIndex);
        PlayerPrefs.SetInt("SelectedButtonIndex", selectedButtonIndex);
    }

    void CheckRewardedAdVisibility(string buttonIndex, string UFOIndex)
    {
        if(buttonsContainer.transform.Find("UFO" + buttonIndex + "Button").transform.Find("AdIcon").gameObject != null)
        {
            adsManagerScript.rewardType = "UFO" + UFOIndex;
            Instantiate(loadingAdScreen, transform.position, Quaternion.identity);
        }
    }

    public void UFO2Achieved()
    {
        Destroy(GameObject.FindGameObjectWithTag("LoadingAdCanvas"));
        selectedSprite = 1;
        playerScript.SetSpriteRenderer(selectedSprite);
        Destroy(button1AdIcon);
        ufo2Achieved = "Yes";
        PlayerPrefs.SetString("UFO2Achieved", ufo2Achieved);
    }

    public void UFO3Achieved()
    {
        Destroy(GameObject.FindGameObjectWithTag("LoadingAdCanvas"));
        selectedSprite = 2;
        playerScript.SetSpriteRenderer(selectedSprite);
        Destroy(button2AdIcon);
        ufo3Achieved = "Yes";
        PlayerPrefs.SetString("UFO3Achieved", ufo3Achieved);
    }
}
