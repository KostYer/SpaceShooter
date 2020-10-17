using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Pr_enemy;
    [SerializeField] Transform[] spawnPoints;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void SpawnEnemy()
    {
        int point = Random.Range(0, spawnPoints.Length );
        var enemy = Instantiate(Pr_enemy, spawnPoints[point].position, Quaternion.identity, this.transform);
    
    }
}
