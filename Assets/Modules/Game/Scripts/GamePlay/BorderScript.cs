using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{ 
public class BorderScript : MonoBehaviour
{




        private void OnCollisionEnter(Collision collision)
        {
            var colliderRB = collision.gameObject.GetComponent<Rigidbody>();
            ///  Debug.Log("collision");
            if (colliderRB != null)
            {
                var asteroid = collision.gameObject.GetComponent<Asteroid>();
                if (asteroid != null)
                {

                    /// Debug.Log("collision rigidbody found");
                    var currentVelosity = colliderRB.velocity;
                    var speed = currentVelosity.magnitude;
                    //var direction = Vector3.Reflect(currentVelosity.normalized, collision.contacts[0].normal);
                    var direction = (Vector3.zero - collision.contacts[0].normal).normalized;
                    direction.y = 0;
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * speed * 1000f, ForceMode.Force);
                }
            }

        }

    }
}
