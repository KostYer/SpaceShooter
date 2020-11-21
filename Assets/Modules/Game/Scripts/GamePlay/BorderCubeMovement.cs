using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public class BorderCubeMovement : MonoBehaviour
    {
        float delta = 6f;
        float speed = 2f;
        Vector3 startPosition;
        void Start()
        {
            startPosition = transform.position;
        }

       
        void Update()
        {
             CubeMoveUpDown();
           
        }

       void CubeMoveUpDown()
        {
            transform.position = startPosition + new Vector3(0.0f, Mathf.Sin(Time.time * speed) * delta, 0.0f);

        }
    }

}