using Game.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : PoolableGameObject
    {
        Rigidbody rigidbody;
        readonly float projectuleVelocity = 170f;
        public int Damage { set { damage = value; }}
                
        int damage;
        public event Action OnDestroy;
        ///  [SerializeField] LayerMask targetLayer;
        [SerializeField] ParticleSystem particles;

        void Start()
        {
          
            rigidbody = GetComponent<Rigidbody>();
            
           
           /// Invoke(nameof(DestroyProjectile), 0.4f);
        }


        private void Update()
        {
            rigidbody.velocity = transform.forward * projectuleVelocity;
        }


        private void OnCollisionEnter(Collision collision)
        {
            var healt = collision.gameObject.GetComponent<Health>();

            if (healt != null)
            {
                if (!this.gameObject.tag.Equals(collision.gameObject.tag))
                {

                    healt.TakeDamage(damage);
                    DestroyProjectile();
                }
   
            }
            else return;
            //{
            //Destroy(this.gameObject);
            //Destroy(collision.gameObject);
            //}

        }

        void DestroyProjectile()
        {
            Debug.Log("DestroyProjectile");
            OnDestroy?.Invoke();
            OnDestroy = null;
             
        }

        public override void Init(Action onRelease)
        {
            OnDestroy += onRelease;
            
            
            Invoke(nameof(DestroyProjectile), 0.3f);
           
           
            Debug.Log("DestroyProjectile");
        }

        public override void Release()
        {
             CancelInvoke();
             rigidbody.Sleep();
             rigidbody.velocity = Vector3.zero;
            /// this.rigidbody.WakeUp();
             Debug.Log("ReleaseProjectile"); rigidbody.WakeUp();
            // rigidbody.WakeUp();
        }
    }
}
