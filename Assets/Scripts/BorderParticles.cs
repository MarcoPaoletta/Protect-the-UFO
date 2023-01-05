using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderParticles : MonoBehaviour
{
    Vector3 playerPosition;
    ParticleSystem ps;

    void Start()
    {
        SetColor();
        SetPosition();
    }

    void SetColor()
    {
        ps = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main = ps.main;
        Color borderColor = GameObject.FindGameObjectWithTag("Border").GetComponent<SpriteRenderer>().color;
        main.startColor = borderColor;
    }

    void SetPosition()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = playerPosition;
    }

}
