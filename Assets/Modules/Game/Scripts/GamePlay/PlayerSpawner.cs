using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] Transform spawnPoint;


        [ContextMenu("SpawnPlayer")]
        public void SpawnPlayer()
        {
          ///  Debug.Log("SpawnPlayer");
            player.transform.position = spawnPoint.position;

            //var rb = player.GetComponent<Rigidbody>();
           /// if (rb.IsSleeping()) { rb.WakeUp(); }
            player.GetComponent<Health>().InitilazeHealth();
            player.SetActive(true);


            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position,  10f);
            foreach (var col in colliders)
            {
                var asteroid = col.gameObject.GetComponent<Asteroid>();
                if ( asteroid != null)
                {
                    asteroid.Explode();
                }
            }
        }

        public static PlayerSpawner instance;


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



    }

}