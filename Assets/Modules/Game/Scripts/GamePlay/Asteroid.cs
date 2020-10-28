using System;
using Game.Core;
using UnityEngine;

namespace Game.GamePlay
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    class Asteroid : PoolableGameObject
    {
        public event Action OnDestroy;
        public event Action<Collision > OnHit;



        public int minSize = 5;
        public int maxSize = 8;
        [SerializeField]
        PoolableGameObject m_Explosion = default;

        void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer(GameLayers.Asteroids);
        }

        void OnCollisionEnter(Collision collision)
        {
            OnHit?.Invoke(collision);
          
            
            //if (!collision.gameObject.tag.Equals(GameTags.Projectile))
            //{
            //    Explode();
            //}
            
            OnDestroyAsteroid();
        }

        public void Explode()
        {
            //Serivces.Get<IPoolingService>().Instantiate(m_Explosion.gameObject, transform.position, Quaternion.identity);
            //OnDestroyAsteroid();
        }

        void OnDestroyAsteroid()
        {
            //CancelInvoke(nameof(Explode));
            OnDestroy?.Invoke();
            OnDestroy = null;
        }

        public override void Init(Action onRelease)
        {
            GameServices.Get<AsteroidsService>().Register(this);
        ///    Invoke(nameof(Explode), 30f);
            OnDestroy += onRelease;
        }

        public override void Release()
        {
            GameServices.Get<AsteroidsService>().Unregister(this);
        }
    }
}
