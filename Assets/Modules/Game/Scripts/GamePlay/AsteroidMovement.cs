using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay
{
    [RequireComponent(typeof(Rigidbody))]
    public class AsteroidMovement : MonoBehaviour
    {
        ///dd
        ///[HideInInspector] public PREV_AsteroidSpawner spawner;
        [SerializeField] GameObject rock;
        // public Gameplay gameplay;
        [SerializeField] float maxRotation = 45f;
        private float rotationX;
        private float rotationY;
        private float rotationZ;
        private Rigidbody rb;

        //private float maxSpeed;
        //private int _generation;
        [SerializeField] float dynamicMaxSpeed = 3f;


        void Start()
        {

            rotationX = Random.Range(-maxRotation, maxRotation);
            rotationY = Random.Range(-maxRotation, maxRotation);
            rotationZ = Random.Range(-maxRotation, maxRotation);

            rb = rock.GetComponent<Rigidbody>();


            rb.AddForce(transform.right * GetRandomVelocity());
            rb.centerOfMass = Vector3.zero;  // without this rb constrain on Y doesnt work



            //  rb.inertiaTensorRotation = Quaternion.identity;

            //  rb.AddForce(transform.forward * GetRandomVelocity());



        }





        void Update()
        {

            rb.centerOfMass = Vector3.zero;  // without this rb constrain on Y doesnt work
            rock.transform.Rotate(new Vector3(rotationX, rotationY, rotationZ) * Time.deltaTime);
            // CheckPosition();

            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -dynamicMaxSpeed, dynamicMaxSpeed), 0f, Mathf.Clamp(rb.velocity.z, -dynamicMaxSpeed, dynamicMaxSpeed));

        }

        //private void FixedUpdate()
        //{
        //    // transform.position.y = new ;
        //}

        private float GetRandomVelocity()
        {
            float speed = Random.Range(200f, 800f);
            int selector = Random.Range(0, 2);
            float direction = selector == 1 ? -1 : 1;

            float finalVelocity = speed * direction;
            return finalVelocity;

        }



        //private void OnTriggerEnter(Collision collision)
        //{

        //    //Destroy(collision.gameObject);
        //    //Destroy(this.gameObject);
        //}
    }
}
