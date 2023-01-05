using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelParticlesSpawner : MonoBehaviour
{
    public void SpawnFuelParticles()
    {
        GameObject fuelParticles = GameObject.FindGameObjectWithTag("FuelParticles");
        GameObject fuel = GameObject.FindGameObjectWithTag("Fuel");
        fuelParticles.transform.position = fuel.transform.position;
        fuelParticles.GetComponent<ParticleSystem>().Play();
    }
}
