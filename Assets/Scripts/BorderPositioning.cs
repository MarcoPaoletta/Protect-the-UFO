using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderPositioning : MonoBehaviour
{
    [SerializeField] GameObject spikePrefab;

    GameObject fitToScreen;
    float spikesOffset = 0.9f;
    int beginningTopSpikesInstancesQuantity = 5;
    GameObject leftBorder;
    SpriteRenderer leftBorderSpriteRenderer;
    GameObject rightBorder;
    SpriteRenderer rightBorderSpriteRenderer;
    GameObject upBorder;
    SpriteRenderer upBorderSpriteRenderer;
    GameObject bottomBorder;
    SpriteRenderer bottomBorderSpriteRenderer;
    SpriteRenderer spikeSpriteRenderer;

    void Awake()
    {
        AssignVariables();
        PositionLeftBorder();
        PositionRightBorder();
        PositionUpBorder();
        PositionBottomBorder();
        BeginningTopSpikes();
        BeginningBottomSpikes();
    }

    void AssignVariables()
    {
        fitToScreen = GameObject.Find("FitToScreen");
        leftBorder = GameObject.Find("Borders").transform.Find("LeftBorder").gameObject;
        leftBorderSpriteRenderer = GameObject.Find("Borders").transform.Find("LeftBorder").GetComponent<SpriteRenderer>();
        rightBorder = GameObject.Find("Borders").transform.Find("RightBorder").gameObject;
        rightBorderSpriteRenderer = GameObject.Find("Borders").transform.Find("RightBorder").GetComponent<SpriteRenderer>();
        upBorder = GameObject.Find("Borders").transform.Find("TopBorder").gameObject;
        upBorderSpriteRenderer = GameObject.Find("Borders").transform.Find("TopBorder").GetComponent<SpriteRenderer>();
        bottomBorder = GameObject.Find("Borders").transform.Find("BottomBorder").gameObject;
        bottomBorderSpriteRenderer = GameObject.Find("Borders").transform.Find("BottomBorder").GetComponent<SpriteRenderer>();
        spikeSpriteRenderer = spikePrefab.GetComponent<SpriteRenderer>();
    }

    void PositionLeftBorder()
    {
        leftBorder.transform.position = new Vector3(fitToScreen.transform.position.x - fitToScreen.GetComponent<SpriteRenderer>().transform.localScale.x / 2 + leftBorder.transform.localScale.x / 2, 0, 0);
    }

    void PositionRightBorder()
    {
        rightBorder.transform.position = new Vector3(fitToScreen.transform.position.x + fitToScreen.GetComponent<SpriteRenderer>().transform.localScale.x / 2 - rightBorder.transform.localScale.x / 2, 0, 0);
    }

    void PositionUpBorder()
    {
        upBorder.transform.position = new Vector3(0, fitToScreen.transform.position.y + fitToScreen.transform.localScale.y / 2 - upBorder.transform.localScale.y / 2, 10);
    }

    void PositionBottomBorder()
    {
        bottomBorder.transform.position = new Vector3(0, fitToScreen.transform.position.y - fitToScreen.transform.localScale.y / 2 + bottomBorder.transform.localScale.y / 2, 10); 
    }

    void BeginningTopSpikes()
    {
        Vector3 spikePosition = new Vector3(0, fitToScreen.transform.localScale.y / -2 + upBorder.transform.localScale.y + spikeSpriteRenderer.size.y / 2, 0);
        float spikePositionX = spikePosition.x * -1 + spikeSpriteRenderer.size.x;
        float spikePositionY = spikePosition.y * -1;
        Vector3 spikeRotation = new Vector3(0, 0, 180);

        BeginningCenterTopSpike(spikePositionY, spikeRotation);

        for (int i = 0; i < beginningTopSpikesInstancesQuantity; i++)
        {
            BeginningLeftTopSpikes(spikePositionY, i, spikeRotation);
            BeginningRightTopSpikes(spikePositionY, i, spikeRotation);
        }
    }

    void BeginningCenterTopSpike(float spikePositionY, Vector3 spikeRotation)
    {
        Instantiate(spikePrefab, new Vector3(0, spikePositionY, 0), Quaternion.Euler(spikeRotation));
    }

    void BeginningLeftTopSpikes(float spikePositionY, int i,Vector3 spikeRotation)
    {
        Instantiate(spikePrefab, new Vector3(-spikesOffset * i, spikePositionY, 0), Quaternion.Euler(spikeRotation));
    }

    void BeginningRightTopSpikes(float spikePositionY, int i,Vector3 spikeRotation)
    {
        Instantiate(spikePrefab, new Vector3(spikesOffset * i, spikePositionY, 0), Quaternion.Euler(spikeRotation));
    }

    void BeginningBottomSpikes()
    {
        Vector3 spikePosition = new Vector3(0, fitToScreen.transform.localScale.y / -2 + upBorder.transform.localScale.y + spikeSpriteRenderer.size.y / 2, 0);
        float spikePositionX = spikePosition.x * -1 + spikeSpriteRenderer.size.x;
        float spikePositionY = spikePosition.y * -1;
        Vector3 spikeRotation = new Vector3(0, 0, 180);
        BeginningCenterBottomSpike(spikePositionY);

        for (int i = 0; i < beginningTopSpikesInstancesQuantity; i++)
        {
            BeginningLeftBottomSpikes(spikePositionY, i, spikeRotation);
            BeginningRightBottomSpikes(spikePositionY, i, spikeRotation);
        }
    }

    void BeginningCenterBottomSpike(float spikePositionY)
    {
        Instantiate(spikePrefab, new Vector3(0, -spikePositionY, 0), Quaternion.identity);
    }

    void BeginningLeftBottomSpikes(float spikePositionY, int i,Vector3 spikeRotation)
    {
        Instantiate(spikePrefab, new Vector3(-spikesOffset * i, -spikePositionY, 0), Quaternion.identity);
    }

    void BeginningRightBottomSpikes(float spikePositionY, int i,Vector3 spikeRotation)
    {
        Instantiate(spikePrefab, new Vector3(spikesOffset * i, -spikePositionY, 0), Quaternion.identity);
    }
}
