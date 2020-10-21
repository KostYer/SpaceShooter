//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject pr_asteroid;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject plane;
    float boundsX;
    float boundsZ;
    int generationStep = 40;

   // public static event Action <GameObject> OnDied;


    [HideInInspector] static public Queue<GameObject> asteroidQ;

    void Start()
    {
       

        Mesh planeMesh = plane.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;
        // size in pixels
        boundsX = plane.transform.localScale.x * bounds.size.x;
        boundsZ = plane.transform.localScale.z * bounds.size.z;
        FillAsteroisdQ(120);
        PlaceAsteroidsOnField();

        

    }

     


    void SpawnAsteroid(Vector3 position)
    {
  
  
        var asteroid = asteroidQ.Dequeue();
        asteroid.transform.position = position;
        asteroid.transform.SetParent(this.transform);
        float scaleModifier = (Random.Range(5f, 8f));
        asteroid.transform.localScale = new Vector3 (scaleModifier, scaleModifier, scaleModifier)  ;
        asteroid.SetActive(true);
        

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;

    //    int generationStep = 40;

    //    float offcet = 5f;
    //    float offsetX = Random.Range(-offcet, offcet);
    //    float offsetZ = Random.Range(-offcet, offcet);
    //    for (int i = 0; i <= boundsX; i += generationStep)
    //    {
    //        for (int j = 0; j <= boundsZ; j += generationStep)
    //        {

    //            Vector3 position = new Vector3(-boundsX / 2 + i, 0f, -boundsZ / 2 + j);// + new Vector3 (offsetX , 0 , offsetZ);
    //            Gizmos.DrawSphere(position, 2f);
    //        }
    //    }

    //}

    private void PlaceAsteroidsOnField()
    {
       

        float offcet = 8f;
        float offsetX = Random.Range(-offcet, offcet);
        float offsetZ = Random.Range(-offcet, offcet);


        for (int i = 0; i <= boundsX; i += generationStep)
        {
            for (int j = 0; j <= boundsZ; j += generationStep)
            {

                Vector3 position = new Vector3(-boundsX / 2 + i, 0f, -boundsZ / 2 + j) + new Vector3(offsetX, 0, offsetZ);
               
                
                SpawnAsteroid(position);
            }
        }

    }

    private void FillAsteroisdQ(int qSize)
    {
       /// asteroidQ.Clear();

        asteroidQ = new Queue<GameObject>();

        for (int i =0; i<= qSize; i++)
        {
            var asteroid = Instantiate(pr_asteroid) as GameObject;
            asteroid.SetActive(false);
            asteroid.transform.parent = this.transform;
            asteroid.GetComponent<Asteroid>().spawner = this; 
            asteroidQ.Enqueue(asteroid);

        }

    }

}
