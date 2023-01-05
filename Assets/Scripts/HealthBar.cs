using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [HideInInspector] public float currentFuel;

    Player playerScript;
    GameManager gameManagerScript;
    Image healthBar;

    void Update()
    { 
        if(playerScript.started)
        {
            healthBar.fillAmount = currentFuel;
            DecreaseHealth();

            if(healthBar.fillAmount <= .2f)
            {
                healthBar.color = Color.red;
            }
        }
    }

    void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
        gameManagerScript = GameObject.FindObjectOfType<GameManager>();
        healthBar = GetComponent<Image>();
        currentFuel = 1f;
    }

    void DecreaseHealth()
    {
        if(!isDied())
        {
            currentFuel -= 0.0005f;
        }
        
        if(isDied())
        {
            gameManagerScript.GameOver();
        }
    } 

    bool isDied()
    {
        if(currentFuel <= 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void CheckMaximumFuel()
    {
        if(currentFuel > 1)
        {
            currentFuel = 1;
        }
    }
}
