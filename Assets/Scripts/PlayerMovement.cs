using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float horizontal;
    float vertical;
    [SerializeField]  private float speed = 1f;
    [SerializeField] private float rotationSpeed = 1f;
    private float turnSmooth;
    float speedMultiplier = 400f;
    public Vector3 direction { get; set; }
    

        void Start()
    {
        rb = GetComponent<Rigidbody>();
 
    }
 

    void FixedUpdate()
    {
        if (direction.magnitude > 0.1f)
        {
            Move();
        }
        
    }

   

    private void Move()
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + rb.rotation.eulerAngles.y;  // + this.transform.eulerAngles.y;
        float smoothedAngle = Mathf.SmoothDamp(rb.rotation.eulerAngles.y, targetAngle, ref turnSmooth, 1/ rotationSpeed);
        ///transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);
        rb.MoveRotation(Quaternion.Euler(0f, smoothedAngle, 0f));

        var moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * speed * speedMultiplier ;
        /// transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
        rb.AddForce(moveDirection * Time.fixedDeltaTime, ForceMode.Acceleration);
    }


    

}