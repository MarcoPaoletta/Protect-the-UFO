using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    [SerializeField] GameObject fuelPrefab;

    Player playerScript;
    float fuelPositionY;

    void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
    }

    public void SpawnFuel()
    {
        int randomNumber = Random.Range(1, 4);

        if(randomNumber == 3 && isTheOnlyFuelInstantiated())
        {
            DestroyFuel();
            SetFuelPositionY();
            Instantiate(fuelPrefab, new Vector3(0, fuelPositionY, 10),Quaternion.identity);
        }
    }

    bool isTheOnlyFuelInstantiated()
    {
        GameObject[] fuels = GameObject.FindGameObjectsWithTag("Fuel");

        if(fuels.Length == 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    void DestroyFuel()
    {
        GameObject[] fuels = GameObject.FindGameObjectsWithTag("Fuel");

        foreach(var fuel in fuels)
        {
            Destroy(fuel);
        }
    }

    void SetFuelPositionY()
    {
        float minimumFuelPositionY = -6f;
        float maximumFuelPositionY = 6f;
        fuelPositionY = Random.Range(minimumFuelPositionY, maximumFuelPositionY);
    }
}
