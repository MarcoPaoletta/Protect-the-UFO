using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    Player playerScript;

    void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
    }

    void Update()
    {
        if(playerScript.started)
        {
            gameObject.SetActive(false);
        }
    }
}
