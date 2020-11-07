using Game.Core;
using Game.GamePlay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;


namespace Game.GamePlay
{
    public class Player : MonoBehaviour
    {
        [HideInInspector]
        public Health health;
        public static event Action OnPlayerDied;

        public static Player instance;

        [SerializeField]
        PoolableGameObject m_Explosion = default;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        void Start()
        {
              
            health = GetComponent<Health>();
            health.OnHealthDepleted += PlayerDied;
            /// health.OnHealthDepleted += PlayerDied;
           
        }

        public IEnumerator HandlePlayerDeath()
        {
            Explode();
            yield return new WaitForSeconds(0.4f);
           
            gameObject.GetComponent<Rigidbody>().Sleep();
            OnPlayerDied?.Invoke();
            GetComponentInChildren<MeshRenderer>().forceRenderingOff = false;
        }


        public void PlayerDied()
        {
            StartCoroutine(nameof(HandlePlayerDeath));
         


        }

        void Explode()
        {
            Serivces.Get<IPoolingService>().Instantiate(m_Explosion.gameObject, transform.position, Quaternion.identity);
            GetComponentInChildren<MeshRenderer>().forceRenderingOff = true;


        }
    }
}
