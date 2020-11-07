using System;
using Game.Core;
using UnityEngine;

namespace Game.GamePlay
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    
   public class Asteroid :   PoolableGameObject
    {
        public event Action OnDestroy;
        ///public event Action<Collision > OnHit;



        public int minSize = 5;
        public int maxSize = 8;
        [SerializeField]
        PoolableGameObject m_Explosion = default;

        void Awake()
        {
            //gameObject.layer = LayerMask.NameToLayer(GameLayers.Asteroids);
            gameObject.tag = GameTags.Asteroid;
        }

        void OnCollisionEnter(Collision collision)
        {
            /// OnHit?.Invoke(collision);
              if (collision.gameObject.tag.Equals(GameTags.Asteroid))
            {
                var direction = new Vector3(UnityEngine.Random.Range(0, 1), 0, UnityEngine.Random.Range(0, 1));

                collision.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * 600, ForceMode.Impulse);

            }

            else if (!collision.gameObject.tag.Equals(GameTags.SpawnPoint))
            {

                Explode();
            }
           



        }

        public void Explode()
        {
             Serivces.Get<IPoolingService>().Instantiate(m_Explosion.gameObject, transform.position, Quaternion.identity);
             OnDestroyAsteroid();
        }

        public void OnDestroyAsteroid()
        {
            //CancelInvoke(nameof(Explode));
            OnDestroy?.Invoke();
            OnDestroy = null;
        }

        public override void Init(Action onRelease)
        {
          ///  GameServices.Get<AsteroidsService>().Register(this);
            ///    Invoke(nameof(Explode), 30f);
            OnDestroy += onRelease;
        }

        public override void Release()
        {
           /// GameServices.Get<AsteroidsService>().Unregister(this);
        }
    }
}
