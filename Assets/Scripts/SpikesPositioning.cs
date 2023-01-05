using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesPositioning : MonoBehaviour
{
    [SerializeField] GameObject spikePrefab;
    [SerializeField] LayerMask spikeLayer;

    float spikePositionY;
    Player playerScript;
    Vector2 spikeSize;
    GameObject leftBorder;
    GameObject rightBorder;
    Vector3 spawnPosition;
    Vector3 spikeRotation;
    ThemeChanger themeChangerScript;
    ScoreText scoreTextScript;
    SpikesQuantity spikesQuantityScript;

    void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
        spikeSize = spikePrefab.gameObject.transform.localScale;
        leftBorder = GameObject.Find("Borders").transform.Find("LeftBorder").gameObject;
        rightBorder = GameObject.Find("Borders").transform.Find("RightBorder").gameObject;
        themeChangerScript = GameObject.FindObjectOfType<ThemeChanger>();
        scoreTextScript = GameObject.FindObjectOfType<ScoreText>();
        spikesQuantityScript = GameObject.FindObjectOfType<SpikesQuantity>();
    }

    public void SpawnSpikes()
    {
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Spike");
        List<Spike> spikeScripts = new List<Spike>();

        foreach(var spike in spikes)
        {
            spikeScripts.Add(spike.GetComponent<Spike>());
        }

        foreach(var spikeScript in spikeScripts)
        {
            spikeScript.ReverseLerpPosition();
        }

        for (int i = 0; i < spikesQuantityScript.spikesQuantity; i++)
        {
            SetSpikesPositionY();
            SetSpikePositionAndRotation();

            if(isThereRoomForSpike())
            {
                Instantiate(spikePrefab, spawnPosition, Quaternion.Euler(spikeRotation));
            }

            else
            {
                i -= 1;
            }       
        }

        themeChangerScript.SetSpikesTheme();
    }

    void SetSpikesPositionY()
    {
        float minimumSpikesPositionY = -6.5f;
        float maximumSpikesPositionY = 6.5f;
        spikePositionY = Random.Range(minimumSpikesPositionY, maximumSpikesPositionY);
    }

    void SetSpikePositionAndRotation()
    {
        if(playerScript.isPlayerMovingLeft())
        {
            spawnPosition = new Vector3(leftBorder.transform.position.x + spikeSize.x / 3, spikePositionY, 10);
            spikeRotation = new Vector3(0, 0, -90);
        }

        if(playerScript.isPlayerMovingRight())
        {
            spawnPosition = new Vector3(rightBorder.transform.position.x - spikeSize.x / 3, spikePositionY, 10);
            spikeRotation = new Vector3(0, 0, 90);
        }
    }

    bool isThereRoomForSpike()
    {
        return !Physics2D.BoxCast(spawnPosition, spikeSize, 0, Vector2.down, .1f, spikeLayer);
    }
}
