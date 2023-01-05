using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererManager : MonoBehaviour
{
    TrailRenderer trailRenderer;
    Player playerScript;
    ShopCanvas shopCanvasScript;

    string htmlStartColor0 = "#46CDEB";
    string htmlEndColor0 = "#30B5D9";
    Color startColor0;
    Color endColor0;

    string htmlStartColor1 = "#DE4142";
    string htmlEndColor1 = "#98393D";
    Color startColor1;
    Color endColor1;

    string htmlStartColor2 = "#2CFB67";
    string htmlEndColor2 = "#1EDD5F";
    Color startColor2;
    Color endColor2;

    void Start()
    {
        AssignVariables();
    }

    void AssignVariables()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        playerScript = GameObject.FindObjectOfType<Player>();
        shopCanvasScript = GameObject.FindObjectOfType<ShopCanvas>();
        ColorUtility.TryParseHtmlString(htmlStartColor0, out startColor0);
        ColorUtility.TryParseHtmlString(htmlStartColor1, out startColor1);
        ColorUtility.TryParseHtmlString(htmlStartColor2, out startColor2);
        ColorUtility.TryParseHtmlString(htmlEndColor0, out endColor0);
        ColorUtility.TryParseHtmlString(htmlEndColor1, out endColor1);
        ColorUtility.TryParseHtmlString(htmlEndColor2, out endColor2);
    }

    public void SetTrailColor(int selectedSprite)
    {
        if(selectedSprite == 0)
        {
            trailRenderer.startColor = startColor0;
            trailRenderer.endColor = endColor0;
        }

        if(selectedSprite == 1)
        {
            trailRenderer.startColor = startColor1;
            trailRenderer.endColor = endColor1;
        }

        if(selectedSprite == 2)
        {
            trailRenderer.startColor = startColor2;
            trailRenderer.endColor = endColor2;
        }
    }
}
