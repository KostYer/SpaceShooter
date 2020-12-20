using Game.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay

{
    public class EnemySpawnerManager
    {


        readonly List<Transform> spawnPoints = new List<Transform>();
    
        
        List<Enemy> m_EnemyPrefabs = new List<Enemy>();

        readonly List<Enemy> enemies = new List<Enemy>();
        int startingEnemyNumber = 4;
        readonly int maxEnemiesOnField = 4;

 

        public EnemySpawnerManager(List<Transform> spawnPoints, List<Enemy> m_EnemyPrefabs)
        {
            this.spawnPoints = spawnPoints;
            this.m_EnemyPrefabs = m_EnemyPrefabs;
           
  

        }


        public void SpawnEnemiesOnField()
        {
            

            for (int i = 0; i < startingEnemyNumber; i++)
                {

                CreateEnemy(spawnPoints[i].position );
                }
                
 
        }

        private void CreateEnemy(Vector3 pos)
        {
            
            
            if (GetNumberOfActiveEnemies() >= maxEnemiesOnField) { return; }
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
                    //enemy.transform.position =  spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)].position ;  ///since merely OnDestroy doesn't reset position for some reason
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

        private int  GetNumberOfActiveEnemies()
        {
            int count = 0;
             

            var allPoolableObjects = GameObjectsPool.allPoolledObjects;
            foreach (var obj in allPoolableObjects)
            {
                if (obj.gameObject.activeInHierarchy)
                {
                    var enemy = obj.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        count++;
                    }
                }
                ////obj.GetComponent<Asteroid> != null
            }
         
            return count;

        }

    }
}


          
        
     
    
 












 