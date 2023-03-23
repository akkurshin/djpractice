using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;   

    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();   

        for (int i = 0; i < 10; i++)               
        {
            SpawnerPosition.x = Random.Range(-1.7f, 1.7f);  
            SpawnerPosition.y += Random.Range(1f, 2f);      

            Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);  
        }
    }

  
}