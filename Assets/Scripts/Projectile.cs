using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    Rigidbody rigidbody;
    float projectuleVelocity =  170f;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] ParticleSystem particles;

    void Start()
    {
         
        rigidbody = GetComponent<Rigidbody>();

         //rigidbody.AddRelativeForce(transform.forward * projectuleVelocity, ForceMode.Impulse);
         rigidbody.velocity = transform.forward *   projectuleVelocity;
       // transform.Rotate(new Vector3(1, 0, 0) *  90);
      //  particles.Play();


    }
    private void Update()
    {
        Destroy(this.gameObject, 1.5f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        var layer = collision.gameObject.layer;
         
        if (layer == targetLayer.value)
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }

}
