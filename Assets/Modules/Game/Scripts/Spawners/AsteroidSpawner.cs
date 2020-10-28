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

        [SerializeField, Range(5f, 10f)]
        float m_SpawnRateMax = 1f;

        [SerializeField]
        List<Asteroid> m_Asteroids = new List<Asteroid>();


        [SerializeField] MeshFilter plane;
        [SerializeField] int generationStep = 40;


        void Awake()
        {
            //DestroyComponent<MeshRenderer>();
            //DestroyComponent<MeshFilter>();
      
            //StartCoroutine(SpawnLoop());
            //PlaceAsteroidsOnField();
        }

        private void Start()
        {
            PopulatePlaneWithsteroids();
        }

        void DestroyComponent<T>() where T : Component
        {
            var component = GetComponent<T>();
            if (component != null)
                Destroy(component);
        }

        //IEnumerator SpawnLoop()
        //{
        //    while (true)
        //    {
        //        yield return new WaitForSeconds(Random.Range(m_SpawnRateMin, m_SpawnRateMax));
        //        Spawn();
        //    }
        //}

        [ContextMenu("Test Spawn")]
        void Spawn()
        {
            CreateAsteroid(Vector3.zero);
        }

        //void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.green;

        //    var from = transform.position;
        //    from.x -= m_SpawnRang;

        //    var to = transform.position;
        //    to.x += m_SpawnRang;

        //    Gizmos.DrawLine(from, to);
        //}

        //void _CreateAsteroid()
        //{
        //    var index = Random.Range(0, m_Asteroids.Count - 1);
        //    var asteroid = Serivces.Get<IPoolingService>().Instantiate<Asteroid>(m_Asteroids[index].gameObject);

        //    var asteroidGameObject = asteroid.gameObject;
        //   /// var spawnSpread = Random.Range(-m_SpawnRang, m_SpawnRang);
        //    asteroidGameObject.transform.SetParent(transform);
        //    ///    asteroidGameObject.transform.localPosition = new Vector3(spawnSpread, 0, 0);

        //    var v = GameServices.Get<CameraService>().MainCamera.transform.position - transform.position;
        //    asteroidGameObject.GetComponent<Rigidbody>().AddForce(v.normalized * 250f);
        //}

        void CreateAsteroid(Vector3 pos)
        {

            var index = Random.Range(0, m_Asteroids.Count - 1);
            var asteroid = Serivces.Get<IPoolingService>().Instantiate<Asteroid>(m_Asteroids[index].gameObject);

            asteroid.transform.position = pos;
            asteroid.transform.SetParent(this.transform);
            float scaleModifier = (Random.Range(5f, 8f));
            asteroid.transform.localScale = new Vector3(scaleModifier, scaleModifier, scaleModifier);



        }

        public void PopulatePlaneWithsteroids()
        {
             
           Bounds bounds = plane.mesh.bounds;
            //     // size in pixels
            float boundsX = plane.transform.localScale.x * bounds.size.x;
            float boundsZ = plane.transform.localScale.z * bounds.size.z;

            float offcet = 8f;
            float offsetX = Random.Range(-offcet, offcet);
            float offsetZ = Random.Range(-offcet, offcet);


            for (int i = 0; i <= boundsX; i += generationStep)
            {
                for (int j = 0; j <= boundsZ; j += generationStep)
                {

                    Vector3 position = new Vector3(-boundsX / 2 + i, 0f, -boundsZ / 2 + j) + new Vector3(offsetX, 0, offsetZ);


                    CreateAsteroid(position);
                }
            }
        }

    }
}
