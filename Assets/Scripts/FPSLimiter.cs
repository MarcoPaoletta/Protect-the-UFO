using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    int wishedFPS = 60;

    void Start()
    {
        Application.targetFrameRate = wishedFPS;
    }
}
