using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

namespace Game.GamePlay

{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> spawnPoints = new List<GameObject>();
        ///string spawnPointsEnemytag = GameTags.SpawnPointEnemy;
        [SerializeField]
        List<Enemy> m_Enemies = new List<Enemy>();

        /*
         
     public string searchTag;
     public List<GameObject> actors = new List<GameObject>();
     */

        void Start()
        {
            foreach (var point in spawnPoints)
            {
                if (!IsVisibleToPlayer(point.transform.position)) { CreateEnemy(point.transform.position); }
               
            }


        }






        // Update is called once per frame
        void Update()
        {

        }



        //void SpawnEnemy()
        //{
        //    int point = Random.Range(0, spawnPoints.Length);
        //    var enemy = Instantiate(Pr_enemy, spawnPoints[point].position, Quaternion.identity, this.transform);

        //}


        [ContextMenu("Test Spawn")]
        void Spawn()
        {
            CreateEnemy(Vector3.zero);
        }

        void CreateEnemy(Vector3 pos)
        {

            var index = Random.Range(0, m_Enemies.Count - 1);
            var enemySheep = Serivces.Get<IPoolingService>().Instantiate<Enemy>(m_Enemies[index].gameObject);

            enemySheep.transform.position = pos;
            enemySheep.transform.SetParent(this.transform);
            //float scaleModifier = (Random.Range(5f, 8f));
            //asteroid.transform.localScale = new Vector3(scaleModifier, scaleModifier, scaleModifier);



        }

         private bool IsVisibleToPlayer(Vector3 pos)
        {
            var cameraPos = GameServices.Get<CameraService>().MainCamera.transform.position;

            ///Ray ray = cam.ScreenPointToRay(pos);
            RaycastHit hit;
            RaycastHit hitInfo;
            int layerMask = 16;

           // Debug.DrawRay(ray.origin, ray.direction * 100000, Color.yellow);
            if (Physics.Linecast(cameraPos, pos, out hitInfo , layerMask))
            {
                print("I'm looking at nddothing!");

            }

            else
                print("I'm looking at nothing!");

            return false;
        }
    }
}

