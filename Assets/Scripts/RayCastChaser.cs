using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastChaser : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] LayerMask layerMask;
    Rigidbody rb;
    float rayLen = 8f;
    float movementSpeed =5f;
    float rotSpeed = 1;
    float rotationAngle = 20;
    float sensorAngle = 30f;
    bool isObstacle = false;



    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isObstacle)
        {
            Debug.Log("if (!isObstacle)"); 
            Vector3 relativePos = target.transform.position - transform.position;


            relativePos = new Vector3(relativePos.x, 0, relativePos.z);
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            rb.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.14f);
            // rb.rotation = Quaternion.Slerp(rb.rotation, rotation, 0.2f);  
            Debug.DrawRay(transform.position, relativePos, Color.blue);
        }
        var velocity = transform.forward * movementSpeed;
        rb.velocity = velocity;

        Debug.DrawRay(transform.position, transform.right * rayLen, Color.white);
        Debug.DrawRay(transform.position, -transform.right * rayLen, Color.white);
 
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayLen, layerMask)
            || Physics.Raycast(transform.position, Quaternion.AngleAxis(-sensorAngle, transform.up) * transform.forward, out hitInfo, rayLen, layerMask)
            // || Physics.Raycast(transform.position, Quaternion.AngleAxis(sensorAngle, transform.up) * transform.forward, out hitInfo, rayLen, layerMask)
            )
        {
            Debug.Log("if (Physics.Raycas1)");
            Debug.DrawRay(transform.position, transform.forward * rayLen, Color.red);
            Debug.DrawRay(transform.position, Quaternion.AngleAxis(-sensorAngle, transform.up) * transform.forward * rayLen, Color.blue);
            Debug.DrawRay(transform.position, Quaternion.AngleAxis(sensorAngle, transform.up) * transform.forward * rayLen, Color.red);


            isObstacle = true;
            //Debug.Log("isObstacle = true");
            //    var velocityIncrement= transform.up * rorAngle * Mathf.Deg2Rad * Time.fixedDeltaTime * rotSpeed;

            //rb.angularVelocity = Vector3.zero;
            //rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, velocityIncrement,1f);


            var q = Quaternion.AngleAxis(rotationAngle, transform.up) * rb.rotation;

            // rb.rotation = Quaternion.Slerp(rb.rotation, q, 0.8f);
            rb.rotation = Quaternion.Slerp(rb.rotation, q, 0.5f);


        }
        else if (Physics.Raycast(transform.position, Quaternion.AngleAxis(sensorAngle, transform.up) * transform.forward, out hitInfo, rayLen)
                 && !Physics.Raycast(transform.position, Quaternion.AngleAxis(-sensorAngle, transform.up) * transform.forward, out hitInfo, rayLen, layerMask))
        {
            Debug.Log("if (Physics.Raycas2)");
            isObstacle = true;
            //var velocityIncrement = transform.up * -rorAngle * Mathf.Deg2Rad * Time.fixedDeltaTime * rotSpeed;
            //rb.angularVelocity = Vector3.zero;
            //rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, velocityIncrement, 1f);

            var q2 = Quaternion.AngleAxis(-rotationAngle, transform.up) * rb.rotation;

            // rb.rotation = Quaternion.Slerp(rb.rotation, q2, 0.8f);
            rb.rotation = Quaternion.Slerp(rb.rotation, q2, 0.5f);


        }


        //else if (Physics.Raycast(transform.position, Quaternion.AngleAxis(sensorAngle, transform.up) * transform.forward, out hitInfo, rayLen))
        //{ 


        //}


        //else if (


        //   (!Physics.Raycast(transform.position, transform.forward, out hitInfo, rayLen * 1.2f, layerMask)
        //&& !Physics.Raycast(transform.position, Quaternion.AngleAxis(-sensorAngle, transform.up) * transform.forward, out hitInfo, rayLen * 1.2f, layerMask)
        //&& !Physics.Raycast(transform.position, Quaternion.AngleAxis(sensorAngle, transform.up) * transform.forward, out hitInfo, rayLen * 1.2f, layerMask)

        //))
        else if (!Physics.Raycast(transform.position, transform.right, out hitInfo, rayLen * 1.2f, layerMask)
            && !Physics.Raycast(transform.position, -transform.right, out hitInfo, rayLen * 1.2f, layerMask))
        {
            Debug.Log("isObstacle = false");

            isObstacle = false;
        }


     

    }
}
