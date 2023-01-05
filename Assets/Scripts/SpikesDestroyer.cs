using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDestroyer : MonoBehaviour
{
    Spike spikeScript;

    void Start()
    {
        spikeScript = GameObject.FindObjectOfType<Spike>();
    }

    public void DestroySpikes()
    {
        foreach(var spike in GetSpikes())
        {
            Destroy(spike);
        }
    }

    GameObject[] GetSpikes()
    {
        return GameObject.FindGameObjectsWithTag("Spike");
    }
}
