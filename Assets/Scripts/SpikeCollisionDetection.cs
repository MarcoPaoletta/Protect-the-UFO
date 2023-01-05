using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollisionDetection : MonoBehaviour
{
    GameManager gameManagerScript;
    Player playerScript;

    void Start()
    {
        gameManagerScript = GameObject.FindObjectOfType<GameManager>();
        playerScript = GameObject.FindObjectOfType<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameManagerScript.GameOver();
            playerScript.DestroyPlayer();
        }
    }
}
