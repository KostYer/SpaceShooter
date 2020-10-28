using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{ 
public class BorderScript : MonoBehaviour
{
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        var asteroidRb = collision.gameObject.GetComponent<Rigidbody>();
      ///  Debug.Log("collision");
        if (asteroidRb != null)
        {
           /// Debug.Log("collision rigidbody found");
            var currentVelosity = asteroidRb.velocity;
            var speed = currentVelosity.magnitude;
            //var direction = Vector3.Reflect(currentVelosity.normalized, collision.contacts[0].normal);
            var direction = (Vector3.zero - collision.contacts[0].normal).normalized ;
            direction.y = 0;
            collision.gameObject.GetComponent<Rigidbody>().AddForce( direction * speed * 1000f , ForceMode.Force ) ;
        }
    }



    }
}
