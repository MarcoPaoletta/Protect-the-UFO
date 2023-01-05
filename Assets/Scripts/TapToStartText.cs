using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartText : MonoBehaviour
{
    Text tapToStartText;
    Animator animator;

    void Start()
    {
        AssignVariables();
        ChangeTextColor();
    }

    void AssignVariables()
    {
        tapToStartText = GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    void ChangeTextColor()
    {
        GameObject border = GameObject.FindGameObjectWithTag("Border");
        tapToStartText.color = border.GetComponent<SpriteRenderer>().color;
    }

    public void OnMoveLeftAnimationFinished()
    {
        animator.SetBool("CanBlink", true);
    }
}
