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
    Vector3 direction;
    PlayerInputContraller playerInputContraller;

    public static PlayerMovement instance;
    public Transform Player => this.transform;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

        void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputContraller = GetComponent<PlayerInputContraller>();
    }

    //void Update()
    //{
    //    horizontal = Input.GetAxisRaw("Horizontal");
    //    vertical = Input.GetAxisRaw("Vertical");
    //    moveVector = new Vector3(horizontal, 0f, vertical);
    //    moveVector.Normalize();

    //    float angle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg;
    //    var quat = Quaternion.Euler(new Vector3(0, angle, 0f) * Time.deltaTime * rotationSpeed);


    //    /// quat = Quaternion.LookRotation(moveVector);

    //    // rb.velocity += vertical * this.transform.forward   * Time.deltaTime;
    //   /// rb.MovePosition(vertical*100f * transform.forward * Time.deltaTime);
    //     //var rotationAmount = rotationSpeed * Time.deltaTime * horizontal;
    //     //rb.rotation = Quaternion.Euler(0, rb.rotation.eulerAngles.y + rotationAmount, 0);

    //    //  rb.AddForce(moveVector , ForceMode.VelocityChange);
    //    if (moveVector.magnitude > 0)
    //    {
    //      ///rb.velocity += moveVector;
    //     rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    //        rb.MoveRotation(rb.rotation * quat  );
    //     ///   rb.AddTorque(moveVector  * rotationSpeed, ForceMode.Impulse);

    //    }
    //}


    void Update()
    {

        horizontal = playerInputContraller.Horizontal;
        vertical = playerInputContraller.Vertical;

        direction = new Vector3(horizontal, 0f, vertical).normalized;
        //Debug.Log("direction " + direction);
       // Debug.Log("player position " + this.transform.position);
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