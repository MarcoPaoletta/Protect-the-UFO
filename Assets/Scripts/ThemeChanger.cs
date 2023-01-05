using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeChanger : MonoBehaviour
{
    [SerializeField] Color32[] darkThemes;
    [SerializeField] Color32[] brightThemes;

    SpriteRenderer fitToScreenSpriteRenderer;
    Image healthBar;
    Image healthBarBackground;
    GameObject[] spikes;
    GameObject[] topSpikes;
    GameObject[] horizontalBorders;
    GameObject[] verticalBorders;
    List<GameObject> toBeColoredGameObjects = new List<GameObject>();
    int randomNumber = 4;
    int randomNumberChosen;
    Color currentBrightColor;
    Color currentDarkColor;
    float lerpTime = 0.05f;
    GameManager gameManagerScript;

    void Update()
    {
        if(gameManagerScript.isDead == false)
        {
            ChangeToBrightThemeColorGameObjects();
            ChangeToDarkThemeColorGameObjects();
        }
    }

    void ChangeToBrightThemeColorGameObjects()
    {
        fitToScreenSpriteRenderer.color = Color.Lerp(fitToScreenSpriteRenderer.color, currentBrightColor, lerpTime);
        healthBarBackground.color = Color.Lerp(healthBarBackground.color, currentBrightColor, lerpTime);
    }

    void ChangeToDarkThemeColorGameObjects()
    {
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, currentDarkColor, lerpTime);
        healthBar.color = Color.Lerp(healthBar.color, currentDarkColor, lerpTime);

        foreach(var toBeColoredGameObject in toBeColoredGameObjects)
        {
            toBeColoredGameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(toBeColoredGameObject.GetComponent<SpriteRenderer>().color, currentDarkColor, lerpTime);
        }     
    }

    void Awake()
    {   
        // SetRandomNumber();
        GetToBeColoredGameObjects();
        AddToBeColoredGameObjects();
        SetDarkThemeColor();
        SetBrightThemeColor();
        ChangeToBrightThemeColorGameObjectsNoLerp();
        ChangeToDarkThemeColorGameObjectsNoLerp();
    }

    void Start()
    {
        gameManagerScript = GameObject.FindObjectOfType<GameManager>();
    }

    void SetRandomNumber()
    {
        randomNumberChosen = randomNumber;
        randomNumber = Random.Range(0, darkThemes.Length);

        if(randomNumberChosen == randomNumber)
        {
            SetRandomNumber();
        }
    }

    void GetToBeColoredGameObjects()
    {
        spikes = GameObject.FindGameObjectsWithTag("Spike");
        topSpikes = GameObject.FindGameObjectsWithTag("TopSpike");
        horizontalBorders = GameObject.FindGameObjectsWithTag("HorizontalBorder");
        verticalBorders = GameObject.FindGameObjectsWithTag("Border");
        fitToScreenSpriteRenderer = GameObject.Find("FitToScreen").GetComponent<SpriteRenderer>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();
        healthBarBackground = GameObject.FindGameObjectWithTag("HealthBarBackground").GetComponent<Image>();
    }

    void AddToBeColoredGameObjects()
    {
        AddToBeColoredGameObject(spikes);
        AddToBeColoredGameObject(topSpikes);
        AddToBeColoredGameObject(horizontalBorders);
        AddToBeColoredGameObject(verticalBorders);
    }

    void AddToBeColoredGameObject(GameObject[] collection)
    {
        foreach(var item in collection)
        {
            toBeColoredGameObjects.Add(item);
        }
    }

    void SetDarkThemeColor()
    {
        currentDarkColor = darkThemes[randomNumber];
    }

    void SetBrightThemeColor()
    {
        currentBrightColor = brightThemes[randomNumber];
    }

    void ChangeToBrightThemeColorGameObjectsNoLerp()
    {
        fitToScreenSpriteRenderer.color = currentBrightColor;      
        healthBar.color = currentBrightColor;
        healthBarBackground.color = currentBrightColor; 
    }

    void ChangeToDarkThemeColorGameObjectsNoLerp()
    {
        Camera.main.backgroundColor = currentDarkColor;
        healthBar.color = currentDarkColor;

        foreach(var toBeColoredGameObject in toBeColoredGameObjects)
        {
            toBeColoredGameObject.GetComponent<SpriteRenderer>().color = currentDarkColor;
        }      
    }

    public void ChangeTheme()
    {
        SetRandomNumber();
        SetDarkThemeColor();
        SetBrightThemeColor();
    }

    public void SetSpikesTheme()
    {
        spikes = GameObject.FindGameObjectsWithTag("Spike");

        foreach(var spike in spikes)
        {
            spike.GetComponent<SpriteRenderer>().color = darkThemes[randomNumber];
        }
    }
}
