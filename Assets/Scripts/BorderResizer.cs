using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderResizer : MonoBehaviour
{
    GameObject fitToScreen;
    GameObject[] horizontalBordersArray;
    GameObject[] verticalBordersArray;
    List<GameObject> horizontalBorders = new List<GameObject>();
    List<GameObject> verticalBorders = new List<GameObject>();

    void Start()
    {
        AssignVariables();
        SetBorders();
        // SetHorizontalBordersSize();
        SetVerticalBordersSize();
    }

    void AssignVariables()
    {
        fitToScreen = GameObject.Find("FitToScreen");
        horizontalBordersArray = GameObject.FindGameObjectsWithTag("HorizontalBorder");   
        verticalBordersArray = GameObject.FindGameObjectsWithTag("Border");
    }

    void SetBorders()
    {
        foreach(var horizontalBorder in horizontalBordersArray)
        {
            horizontalBorders.Add(horizontalBorder);
        }
        foreach(var verticalBorder in verticalBordersArray)
        {
            verticalBorders.Add(verticalBorder);
        }
    }

    void SetHorizontalBordersSize()
    {
        foreach(var horizontalBorder in horizontalBorders)
        {
            horizontalBorder.transform.localScale = new Vector2(fitToScreen.transform.localScale.x, horizontalBorder.GetComponent<SpriteRenderer>().size.y);
        }
    }

    void SetVerticalBordersSize()
    {
        foreach(var verticalBorder in verticalBorders)
        {
            verticalBorder.transform.localScale = new Vector2(verticalBorder.GetComponent<SpriteRenderer>().size.x, fitToScreen.transform.localScale.y);
        }
    }
}
