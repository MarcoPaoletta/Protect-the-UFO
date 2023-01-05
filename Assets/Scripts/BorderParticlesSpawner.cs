using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderParticlesSpawner : MonoBehaviour
{
    [SerializeField] GameObject borderParticlesPrefab;

    public void SpawnBorderParticles()
    {
        DestroyBorderParticles();
        Instantiate(borderParticlesPrefab, Vector3.zero, Quaternion.identity);
    }

    void DestroyBorderParticles()
    {
        GameObject[] borderParticles = GameObject.FindGameObjectsWithTag("BorderParticles");

        foreach(var borderParticle in borderParticles)
        {
            Destroy(borderParticle);
        }
    }
}
