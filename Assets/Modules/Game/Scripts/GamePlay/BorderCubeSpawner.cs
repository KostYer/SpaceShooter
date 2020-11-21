using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCubeSpawner : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] Transform[] spawnPoints = new Transform [4];
    void Start()
    {
        foreach (var point in spawnPoints)
        {
            Instantiate(cubePrefab, point.position, Quaternion.identity);
        }
        
    }

    
}
