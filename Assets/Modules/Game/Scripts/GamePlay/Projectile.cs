using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        Rigidbody rigidbody;
        float projectuleVelocity = 170f;
        public int Damage { set { damage = value; }}
                
        int damage;
        
      ///  [SerializeField] LayerMask targetLayer;
        [SerializeField] ParticleSystem particles;

        void Start()
        {

            rigidbody = GetComponent<Rigidbody>(); 
            rigidbody.velocity = transform.forward * projectuleVelocity;
 


        }


        private void Update()
        {
            Destroy(this.gameObject, 0.15f);
        }


        private void OnCollisionEnter(Collision collision)
        {
            var healt = collision.gameObject.GetComponent<Health>();

            if (healt != null)
            {
                if (!this.gameObject.tag.Equals(collision.gameObject.tag))
                {

                    healt.TakeDamage(damage);
                    Destroy(this.gameObject);
                }
   
            }
            else return;
            //{
            //Destroy(this.gameObject);
            //Destroy(collision.gameObject);
            //}

        }

    }
}
