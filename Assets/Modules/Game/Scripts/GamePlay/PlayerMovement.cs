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
        [SerializeField] private float rotationSpeed = 1f;
        private readonly float turnSmooth;
    
        public Vector3 Direction { get; set; }



        //public float speed = 200.0f;
        //public float turnRate = 3.0f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

        }
        /*
          move.x - joystick.Horizontal;
        move.y - joystick.Vertical;

        float hAxis = joystick.Horizontal;
        float vAxis = joystick.Vertical;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -zAxis);
         
         */
        private void Update()
        {

              horizontal = Direction.x;
              vertical = Direction.z;

            if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
            {
                Move();

            }



        }





        ////private void Move()
        ////{

        ////    float zangle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg;
        ////    Quaternion desiredRotation = Quaternion.AngleAxis(zangle, Vector3.up);
        ////    transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 0.8f);
        ////    transform.Translate(  transform.forward   /**30f * Time.deltaTime  direction.normalized **/  );


        ////}

        //void FixedUpdate()
        //{

        //    if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        //    {
        //        Move();

        //    }

        //}



        private void Move()
        {

            float zangle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg;
            Quaternion desiredRotation = Quaternion.AngleAxis(zangle, Vector3.up);
            rb.rotation = Quaternion.Lerp(rb.rotation, desiredRotation, 0.05f);
            rb.MovePosition(rb.position + transform.forward * /*direction.normalized **/ speed / 40f /** Time.fixedDeltaTime)*/);


        }


        /*
         
          Vector3 move = new Vector3(hInput, vInput, 0);
 
         if(move.x != 0.0f || move.y != 0.0f)
         {
             targetRotation = Quaternion.LookRotation(Vector3.forward, move);
             transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnRate);
             rb.AddRelativeForce(Vector3.up * speed * Time.fixedDeltaTime);
         }
             // Get a left or right 90 degrees angle based on the rigidbody current rotation velocity
         float steeringRightAngle;
         if(rb.angularVelocity > 0) {
             steeringRightAngle = -90;
         } else {
             steeringRightAngle = 90;
         }
             // Find a Vector2 that is 90 degrees relative to the local forward direction (2D top down)
         Vector2 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * Vector2.up;
             // Calculate the 'drift' sideways velocity from comparing rigidbody forward movement and the right angle to this.
         float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized));
             // Calculate an opposite force to the drift and apply this to generate sideways traction (aka tyre grip)
         Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);
         rb.AddForce(rb.GetRelativeVector(relativeForce));
     }
         
         */

    }
}