using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody rb;
        float horizontal;
        float vertical;
        [SerializeField] private float speed = 1f;
        [SerializeField] private float rotationSpeed ;
        private readonly float turnSmooth;
    
        public Vector3 Direction { get; set; }



        //public float speed = 200.0f;
        //public float turnRate = 3.0f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
         //   rb.centerOfMass = Vector3.zero;

        }
        
        private void Update()
        {
          //  rb.centerOfMass = Vector3.zero;

            horizontal = Direction.x;
            vertical = Direction.z;

          



        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
            {
                Move();

            }
        }



          
            private void Move()
        {

            float zangle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg;
            Quaternion desiredRotation = Quaternion.AngleAxis(zangle, Vector3.up);
            rb.rotation = Quaternion.Lerp(rb.rotation, desiredRotation, rotationSpeed);
             rb.MovePosition(rb.position + transform.forward  *   speed /30f  );
            ///rb.AddForce(transform.forward * speed* 2 * Time.fixedDeltaTime, ForceMode.Impulse);

        }


        

    }
}