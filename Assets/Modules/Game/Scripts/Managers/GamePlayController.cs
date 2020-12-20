using Game.Core;
using Modules.Game.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay
{
    public class GamePlayController : MonoBehaviour
    {
        [SerializeField]
        GamePlayUIView m_GamePlayUIView = default;
        [SerializeField] List<Transform> spawnPointsEnemies;
        [SerializeField] List<Enemy> enemyPrefabs;
        [SerializeField] GameObject playerPrefab;
        [SerializeField] GameObject targetObject;
        [SerializeField] HealthBar pr_healthBarPrefab;
        [SerializeField] GameObject playerSpawnPoint;
        Camera mainCamera;
        void Awake()
        {
            //mainCamera = Camera.main.gameObject;
            mainCamera = Camera.main;


            ActivateServises();
           


            ///GameServices.Register(new CameraService(Camera.main));
            ///  GameServices.Register(new AsteroidsService());


        }

        private void Start()
        {

            StartLevel();

        }


      

        void StartLevel()
        {

             GameServices.Get<PlayerManager>().SpawnPlayer();
            //PlayerSpawner.instance.SpawnPlayer();
           GameServices.Get<EnemySpawnerManager>().SpawnEnemiesOnField();
            AsteroidSpawner.instance.PopulatePlaneWithsteroids();


            InvokeRepeating(nameof(SpawnEnemiesByOne), 4f, 6f);
            InvokeRepeating(nameof(SpawnAsteroidsByOne), 1f, 1f);

        }

        [ContextMenu("SpawnEnemiesByOne")]
        void SpawnEnemiesByOne()
        {
            GameServices.Get<EnemySpawnerManager>().SpawnEnemyOnRandomPoint();

        }

        [ContextMenu("SpawnEnemiesByOne")]
        void SpawnAsteroidsByOne()
        {
            AsteroidSpawner.instance.SpawnAsteroidOnRandomPoint();

        }



        [ContextMenu("GetNumberOfActiveEnemies")]
        void GetNumberOfActiveEnemies()
        {
            int count = 0;
           /// var asteroid =GameServices.Get<Enemy>();

            var allPoolableObjects = GameObjectsPool.allPoolledObjects;
            foreach( var obj in allPoolableObjects)  
                    {
                if (obj.gameObject.activeInHierarchy)
                {
                    var enemy = obj.GetComponent<Enemy>();
                           if(enemy != null)
                            {
                        count++;
                            }
                }
                      ////obj.GetComponent<Asteroid> != null
         }
            print("enenmy count" + count);

        }





        [ContextMenu("GetNumberOfActiveAsteroids")]
        void GetNumberOfActiveAsteroids()
        {
            int count = 0;
            /// var asteroid =GameServices.Get<Enemy>();

            var allPoolableObjects = GameObjectsPool.allPoolledObjects;
            foreach (var obj in allPoolableObjects)
            {
                if (obj.gameObject.activeInHierarchy)
                {
                    var enemy = obj.GetComponent<Asteroid>();
                    if (enemy != null)
                    {
                        count++;
                    }
                }

            }
            print("asteroid count" + count);

        }

        

        static public void DeactivateServices()
        {
            
            GameServices.Unregister<AudioManager>();
            GameServices.Unregister<EnemySpawnerManager>();
            GameServices.Unregister<CameraService>();
            
            GameServices.Unregister<HealthBarManager>();
            GameServices.Unregister<GameScoreManager>();
            // GameServices.Unregister<PlayerManager>();
          ///  Serivces.Get<IPoolingService>.gameObject();
            //GameServices.Unregister<CameraService>(); /// (new CameraService(mainCamera));
            // GameServices.Unregister<AsteroidManager>();

        }

         public void ActivateServises()
        {
            // Should be done on landing   
            Serivces.Register<IPoolingService>(new GameObjectsPool("Pool"));
            GameServices.Register(new CameraService(mainCamera));
            GameServices.Register(new HealthBarManager(pr_healthBarPrefab));


            GameServices.Register(new PlayerManager(playerPrefab, playerSpawnPoint ));
            GameServices.Register(new EnemySpawnerManager(spawnPointsEnemies, enemyPrefabs));
            GameServices.Register(new GameScoreManager(m_GamePlayUIView));
            GameServices.Register(new AudioManager());
            ///   GameServices.Register<AsteroidManager>();


        }

    }
}