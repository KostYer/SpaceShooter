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
        [SerializeField] List<Transform> spawnPonts;
        [SerializeField] List<Enemy> enemyPrefabs;
        [SerializeField] Camera mainCamera;
        [SerializeField] GameObject targetObject;
      

        void Awake()
        {
           

            // Should be done on landing  
        Serivces.Register<IPoolingService>(new GameObjectsPool("Pool"));
        GameServices.Register(new EnemySpawnerService(spawnPonts, enemyPrefabs));
        GameServices.Register(new GameScoreService(m_GamePlayUIView));
        GameServices.Register(new CameraService(mainCamera));
      
        ///GameServices.Register(new CameraService(Camera.main));
        ///  GameServices.Register(new AsteroidsService());


        }

        private void Start()
        {

            StartLevel();

        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)  ) SpawnEnemiesByOne();
        }

        void StartLevel()
        {
            PlayerSpawner.instance.SpawnPlayer();
            GameServices.Get<EnemySpawnerService>().SpawnEnemiesOnField();
            AsteroidSpawner.instance.PopulatePlaneWithsteroids();
             

            InvokeRepeating(nameof(SpawnEnemiesByOne), 4f,6f);
           InvokeRepeating(nameof(SpawnAsteroidsByOne), 1f, 1f);
 
        }

        [ContextMenu("SpawnEnemiesByOne")]
        void SpawnEnemiesByOne()
        {
            GameServices.Get<EnemySpawnerService>().SpawnEnemyOnRandomPoint();

        }

        [ContextMenu("SpawnEnemiesByOne")]
        void SpawnAsteroidsByOne()
        {
            AsteroidSpawner.instance.SpawnAsteroidOnRandomPoint();

        }


        //[ContextMenu("SpawnEnemiesOnField")]
        //public void SpawnEnemiesManuallyTest()
        //{
        //    GameServices.Get<EnemySpawnerService>().SpawnEnemiesOnField( );

        //}


        //[ContextMenu("DestroyAllEnemies")]
        //public void DestroyAllEnemiesTest()
        //{
        //    GameServices.Get<EnemySpawnerService>().DestroyAllEnemies();
        //}

        //[ContextMenu("IsVIsibleToCamera")]
        //public void IsVIsibleToCamera( )
        //{

        //    if (GameServices.Get<CameraService>().IsVisibleToCamera(this.targetObject.GetComponent<Collider>())) { Debug.Log("visible to camera"); }
        //    else  
        //        { Debug.Log("visible NOT visible to camera"); }

        //}



    }
}