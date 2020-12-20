using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(Rigidbody))]
public class MovingObject : MonoBehaviour
{
    private Vector3 center;
    private int range = 15;
    Rigidbody rb;
    float speed = 8f;
    bool isNewPositionSelected =false;
    Vector3 nextPosition;
    private float stopingdistance = 0.5f;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        center = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
      

        if (!isNewPositionSelected)
        {
            nextPosition = new Vector3(Random.Range(-range, range), center.y, Random.Range(-range, range));
            isNewPositionSelected = true;
        }


         
        rb.MovePosition( nextPosition * speed * Time.deltaTime);

        var distanceToNextPosition = Mathf.Abs( Vector3.Distance(this.transform.position, nextPosition));

        if (distanceToNextPosition <= stopingdistance)
        {
            isNewPositionSelected = false;
        }

    }
}
