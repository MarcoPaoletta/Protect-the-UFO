using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImage : MonoBehaviour
{
    TapToStartText tapToStartTextScript;

    void Start()
    {
        tapToStartTextScript = GameObject.FindObjectOfType<TapToStartText>();
    }

    public void OnFadeAnimationFinished()
    {
        // tapToStartTextScript.TurnTapToStartTextAnimatorOn();
        Destroy(transform.parent.gameObject);
    }
}
