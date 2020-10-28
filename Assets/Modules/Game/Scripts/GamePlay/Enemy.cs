using System;
using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;





namespace Game.GamePlay
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Enemy : PoolableGameObject
    {
        
        public event Action OnDestroy;
        public event Action<Collision > OnHit;
        private Health health;


        private void Awake()
        {
          health = GetComponent<Health>();
 
        }

        void OnCollisionEnter(Collision collision)
        {
            //OnHit?.Invoke(collision );


            //if (!collision.gameObject.tag.Equals(GameTags.Projectile))
            //{
            //    Explode();
            //}

            //OnDestroyAsteroid();
        }


        public void Explode()
        {
            Debug.Log("Enemy exploded"); 
        }



        public void OnDestroyEnemy()
        {
         //  CancelInvoke(nameof(Explode));
            OnDestroy?.Invoke();
            OnDestroy = null;
        }


        public override void Init(Action onRelease)
        {
            GameServices.Get<EnemyService>().Register(this);
         ///   Invoke(nameof(Explode), 30f);
            OnDestroy += onRelease;
        }

        public override void Release()
        {
            GameServices.Get<EnemyService>().Unregister(this);
        }
    }
}


