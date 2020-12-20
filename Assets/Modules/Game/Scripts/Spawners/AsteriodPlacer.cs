using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodPlacer : MonoBehaviour
{
    [SerializeField] GameObject plane;
    float boundsX;
    float boundsZ;
    int generationStep = 40;

    void Start()
    {

        Mesh planeMesh = plane.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;
        // size in pixels
        boundsX = plane.transform.localScale.x * bounds.size.x;
        boundsZ = plane.transform.localScale.z * bounds.size.z;

    }

    public static void PlaceAsteroidsOnField()
    {


        //float offcet = 8f;
        //float offsetX = Random.Range(-offcet, offcet);
        //float offsetZ = Random.Range(-offcet, offcet);


        //for (int i = 0; i <= boundsX; i += generationStep)
        //{
        //    for (int j = 0; j <= boundsZ; j += generationStep)
        //    {

        //        Vector3 position = new Vector3(-boundsX / 2 + i, 0f, -boundsZ / 2 + j) + new Vector3(offsetX, 0, offsetZ);


        //      ////  SpawnAsteroid(position);
        //    }
        //}

    }



}
