using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    [HideInInspector] public Vector3 startPosition;
    [HideInInspector] public Vector3 finalPosition;
    [HideInInspector] public float lerpDuration = 0.12f;

    GameManager gameManagerScript;
    Player playerScript;
    GameObject leftBorder;
    GameObject rightBorder;
    SpikesDestroyer spikesDestroyerScript;

    void Start()
    {
        AssignVariables();
        StartCoroutine(LerpPosition(startPosition, finalPosition, lerpDuration));
    }

    void AssignVariables()
    {
        gameManagerScript = GameObject.FindObjectOfType<GameManager>();
        playerScript = GameObject.FindObjectOfType<Player>();
        leftBorder = GameObject.Find("Borders").transform.Find("LeftBorder").gameObject;
        rightBorder = GameObject.Find("Borders").transform.Find("RightBorder").gameObject;
        spikesDestroyerScript = GameObject.FindObjectOfType<SpikesDestroyer>();
        finalPosition = transform.position;

        if(playerScript.isPlayerMovingLeft())
        {
            startPosition = new Vector3(leftBorder.transform.position.x, transform.position.y, transform.position.z);
        }

        if(playerScript.isPlayerMovingRight())
        {
            startPosition = new Vector3(rightBorder.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    IEnumerator LerpPosition(Vector3 startPosition, Vector3 finalPosition, float lerpDuration)
    {
        float timeElapsed = 0f;

        while(timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, finalPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = finalPosition;
    }

    public void ReverseLerpPosition()
    {
        StartCoroutine(LerpPosition(transform.position, startPosition, lerpDuration));
        Invoke("DestroySpikes", lerpDuration);
    }

    void DestroySpikes()
    {
        Destroy(gameObject);
    }
}
