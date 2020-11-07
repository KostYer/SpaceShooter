using Game.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay

{
    public class EnemySpawnerService
    {


        List<Transform> spawnPoints = new List<Transform>();
        ///string spawnPointsEnemytag = GameTags.SpawnPointEnemy;
        [SerializeField]
        List<Enemy> m_EnemyPrefabs = new List<Enemy>();

        List<Enemy> enemies = new List<Enemy>();
         int startingEnemyNumber = 4;

        ///public static event Action OnRespawnEnemies = delegate { };
        //// public static event Action OnDisableEnemies = delegate { };

        public EnemySpawnerService(List<Transform> spawnPoints, List<Enemy> m_EnemyPrefabs)
        {
            this.spawnPoints = spawnPoints;
            this.m_EnemyPrefabs = m_EnemyPrefabs;


        }




        //void Start()
        //{
        //    /// OnRespawnEnemies += SpawnEnemiesOnField;
        //    //   OnDisableEnemies += destroyAllEnemies;

        //    // SpawnEnemiesOnField();
        //}


        public void SpawnEnemiesOnField()
        {

           
                for (int i = 0; i < startingEnemyNumber; i++)
                {

                    CreateEnemy(spawnPoints[i].position );
                }
                
 
        }

        private void CreateEnemy(Vector3 pos)
        {
            var index = UnityEngine.Random.Range(0, m_EnemyPrefabs.Count - 1);
            var enemyShip = Serivces.Get<IPoolingService>().Instantiate<Enemy>(m_EnemyPrefabs[index].gameObject);
            enemyShip.GetComponent<EnemyController>().navAgent.nextPosition =  pos;
           /// enemyShip.gameObject.transform.SetPositionAndRotation(pos, Quaternion.identity);
        ///    enemySheep.transform.SetParent(this.transform);
            //float scaleModifier = (Random.Range(5f, 8f));
            //asteroid.transform.localScale = new Vector3(scaleModifier, scaleModifier, scaleModifier);
            ///   enemyShip.GetComponent<Health>().InitilazeHealth();
            enemies.Add(enemyShip);
           
        }

        


        ///   [ContextMenu("destroyAllEnemies")]
        public void DestroyAllEnemies()
        {
            if (enemies.Count > 0)
            {
                foreach (var enemy in enemies)
                {
                    //enemy.transform.position = Vector3.zero;
                    enemy.OnDestroyEnemy();
                    enemy.transform.position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)].position ;  ///since merely OnDestroy doesn't reset position for some reason
                     ///enemy.Release();


                }
            }
            
 
        }

        
        public void SpawnEnemyOnRandomPoint()
        {

            int index = UnityEngine.Random.Range(0, spawnPoints.Count);
          ////  CreateEnemy(spawnPoints[index].position);

            var spawnPointCollider = spawnPoints[index].gameObject.GetComponent<Collider>();

            if (!GameServices.Get<CameraService>().IsVisibleToCamera(spawnPointCollider))
            {
                CreateEnemy(spawnPoints[index].position);
                return;

            }
            else if (GameServices.Get<CameraService>().IsVisibleToCamera(spawnPointCollider))
            {
                SpawnEnemyOnRandomPoint();
                return;
            }


            //throw new InvalidOperationException();

        }

    }
}


          
        
     
    
 












 