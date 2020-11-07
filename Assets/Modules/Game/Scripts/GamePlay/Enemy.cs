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


        private void Awake()
        {

            //trailRenderer = GetComponentsInChildren<TrailRenderer>();
            //enemyController = GetComponent<EnemyController>();

        }

        public void Explode()
        {
            Serivces.Get<IPoolingService>().Instantiate(m_Explosion.gameObject, transform.position, Quaternion.identity);
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

        public override void Release()
        {
            GameServices.Get<GameScoreService>().Unregister(this);
            health.OnHealthDepleted -= OnDestroyEnemy;





        }
    }
}


