using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpacityLerpManager : MonoBehaviour
{
    Text mainTitleText;

    void Start()
    {
        mainTitleText = GameObject.FindGameObjectWithTag("MainTitleText").GetComponent<Text>();
    }

    public void LerpObjectsOpacity()
    {
        Color mainTitleTextColor = mainTitleText.color;
        mainTitleTextColor.a = 0.5f;
    }    
}
