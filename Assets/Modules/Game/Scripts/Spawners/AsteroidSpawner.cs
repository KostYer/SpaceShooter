using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.GamePlay
{
    class AsteroidSpawner : MonoBehaviour
    {
        //[SerializeField, Range(1, 5)]
        //float m_SpawnRang = 1f;

        [SerializeField, Range(0.1f, 5f)]
        float m_SpawnRateMin = 1f;

        //[SerializeField, Range(5f, 10f)]
        //float m_SpawnRateMax = 1f;

        [SerializeField]
        List<Asteroid> m_Asteroids = new List<Asteroid>();

        [SerializeField] List<Transform> spawnPoints;
        public MeshFilter meshForGenerationgAsteroidsOnGameLevel;
        public MeshFilter meshForGenerationgAsteroidsBelow;
        [SerializeField] int generationStep = 40;
        private readonly int maxAsteroidsCapacity = 70;

        public static AsteroidSpawner instance;


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


        [HideInInspector] public List<Asteroid> asteroids = new List<Asteroid>();
     

        void CreateAsteroid(Vector3 pos)
        {
            if (GetNumberOfActiveAsteroids() >= maxAsteroidsCapacity) return;


            var index = Random.Range(0, m_Asteroids.Count - 1);
            var asteroid = Serivces.Get<IPoolingService>().Instantiate<Asteroid>(m_Asteroids[index].gameObject);

            asteroid.transform.position = pos;
            asteroid.transform.SetParent(this.transform);
            float scaleModifier = (Random.Range(5f, 12f));
            asteroid.transform.localScale = new Vector3(scaleModifier, scaleModifier, scaleModifier);
            asteroids.Add(asteroid);


        }


         
        private int  GetNumberOfActiveAsteroids()
        {
            int count = 0;
 

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
           
            return count;

        }

        public void DestroyAllAsteroids()
        {
            if (asteroids.Count > 0)
            {
                foreach (var asteroid in asteroids)
                {
                    asteroid.OnDestroyAsteroid();

                }
            }
            asteroids.Clear();
            //Debug.Log("OnDestroyAsteroids");

        }

        public void PopulatePlaneWithsteroids()
        {
            //PopulatePlaneBelowLevel();
            Bounds bounds = meshForGenerationgAsteroidsOnGameLevel.mesh.bounds;
            //     // size in pixels
            float boundsX = meshForGenerationgAsteroidsOnGameLevel.transform.localScale.x * bounds.size.x;
            float boundsZ = meshForGenerationgAsteroidsOnGameLevel.transform.localScale.z * bounds.size.z;

            float offcet = 8f;
            float offsetX = Random.Range(-offcet, offcet);
            float offsetZ = Random.Range(-offcet, offcet);


            for (int i = 0; i <= boundsX; i += generationStep )
            {
                for (int j = 0; j <= boundsZ; j += generationStep )
                {

                    Vector3 position = new Vector3(-boundsX / 2 + i, 0f, -boundsZ / 2 + j) + new Vector3(offsetX, 0, offsetZ);


                    CreateAsteroid(position);
                }
            }
            
        }


        //public void PopulatePlaneBelowLevel()
        //{
        //    var yPosition = meshForGenerationgAsteroidsBelow.gameObject.transform.position.y;
        //    Bounds bounds = meshForGenerationgAsteroidsBelow.mesh.bounds;
        //    //     // size in pixels
        //    float boundsX = meshForGenerationgAsteroidsBelow.transform.localScale.x * bounds.size.x;
        //    float boundsZ = meshForGenerationgAsteroidsBelow.transform.localScale.z * bounds.size.z;

        //    float offcet = 8f;
        //    float offsetX = Random.Range(-offcet, offcet);
        //    float offsetZ = Random.Range(-offcet, offcet);


        //    for (int i = 0; i <= boundsX; i += generationStep )
        //    {
        //        for (int j = 0; j <= boundsZ; j += generationStep )
        //        {

        //            Vector3 position = new Vector3(-boundsX / 2 + i, yPosition, -boundsZ / 2 + j) + new Vector3(offsetX, offsetX * 20f, offsetZ);


        //            CreateAsteroid(position);
        //        }
        //    }
        //}




        public void SpawnAsteroidOnRandomPoint()
        {
          ///  if (asteroids.Count >= maxAsteroidsCapacity) return;
            int index = UnityEngine.Random.Range(0, spawnPoints.Count);
            ////  CreateEnemy(spawnPoints[index].position);

            var spawnPointCollider = spawnPoints[index].gameObject.GetComponent<Collider>();

            if (!GameServices.Get<CameraService>().IsVisibleToCamera(spawnPointCollider))
            {
                CreateAsteroid(spawnPoints[index].position );  
                //return;

            }
            else if (GameServices.Get<CameraService>().IsVisibleToCamera(spawnPointCollider))
            {
                //SpawnAsteroidOnRandomPoint();  
                //return;
            }


        }
         
    }
}
