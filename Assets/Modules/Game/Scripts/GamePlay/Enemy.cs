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

        private Health health;
        [SerializeField]
        PoolableGameObject m_Explosion = default;
      ///  AudioSource soundLaser;


        private void Awake()
        {

            //trailRenderer = GetComponentsInChildren<TrailRenderer>();
            //enemyController = GetComponent<EnemyController>();
            //explosionSound = GetComponent<AudioSource>();

        }

        public void Explode()
        {
            Serivces.Get<IPoolingService>().Instantiate(m_Explosion.gameObject, transform.position, Quaternion.identity);
          //  GameServices.Get<AudioServise>().OnExplode();
            OnDestroyEnemy();
        }

       


        public void OnDestroyEnemy()
        {
            
            //  CancelInvoke(nameof(Explode));
            OnDestroy?.Invoke();
            OnDestroy = null;

        }


        public override void Init(Action onRelease)
        {

            GameServices.Get<GameScoreService>().Register(this);
            ///   Invoke(nameof(Explode), 30f);
            health = GetComponent<Health>();
            health.OnHealthDepleted += Explode;
            health.InitilazeHealth();
            OnDestroy += onRelease;



        }


        //[ContextMenu("playSound")]
        //void PlaySound1()
        //{
        //    explosionSound.Play();
        //}

        public override void Release()
        {
            GameServices.Get<GameScoreService>().Unregister(this);
            health.OnHealthDepleted -= OnDestroyEnemy;
          
          




        }
    }
}


