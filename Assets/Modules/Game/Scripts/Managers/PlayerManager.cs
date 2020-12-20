using UnityEngine;

namespace Game.GamePlay
{
    public class PlayerManager
    {
        private GameObject playerObject;
        private Transform spawnPoint;
        private GameObject player;
        
        public Vector3 PlayerPosition { get { if (player != null)  return player.transform.position ; return Vector3.zero; } }
            
            
      

        public PlayerManager(GameObject playerPrefab, GameObject point)
        {
               playerObject = playerPrefab;
               spawnPoint = point.transform;
        }



        public void SpawnPlayer()
        {
 
                player = GameObject.Instantiate(playerObject, spawnPoint.position, Quaternion.identity/*, spawnPoint*/) as GameObject;
                player.GetComponent<Health>().InitilazeHealth();
      
          


            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, 10f);
            foreach (var col in colliders)
            {
                var asteroid = col.gameObject.GetComponent<Asteroid>();
                if (asteroid != null)
                {
                    asteroid.Explode();
                }
            }
        }


        public void DestroyPlayer()
        {
            player.GetComponent<Health>().Die();
            GameObject.Destroy(player);

             
        }
    
    }
}