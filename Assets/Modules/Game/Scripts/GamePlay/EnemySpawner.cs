using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;
using System;

namespace Game.GamePlay

{
    public class EnemySpawner : MonoBehaviour
    {
        //    [SerializeField]
        //    List<GameObject> spawnPoints = new List<GameObject>();
        //    ///string spawnPointsEnemytag = GameTags.SpawnPointEnemy;
        //    [SerializeField]
        //    List<Enemy> m_EnemyPrefabs = new List<Enemy>();

        //    List<Enemy> enemies = new List<Enemy>();

        //    ///public static event Action OnRespawnEnemies = delegate { };
        //    //// public static event Action OnDisableEnemies = delegate { };

        //    public static EnemySpawner instance;


        //    private void OnEnable()
        //    {
        //        if (instance == null)
        //        {
        //            instance = this;
        //        }
        //        else
        //        {
        //            Destroy(gameObject);
        //            return;
        //        }
        //    }

        //    void Start()
        //    {
        //         /// OnRespawnEnemies += SpawnEnemiesOnField;
        //        //   OnDisableEnemies += destroyAllEnemies;

        //      // SpawnEnemiesOnField();
        //    }


        //    public void SpawnEnemiesOnField()
        //    {

        //        foreach (var point in spawnPoints)
        //        {
        //            if (!IsVisibleToPlayer(point.transform.position)) { CreateEnemy(point.transform.position); }

        //        }
        //    }


        //    [ContextMenu("destroyAllEnemies")]
        //    public void DestroyAllEnemies()
        //{
        //    if (enemies.Count > 0)
        //    {
        //        foreach (var enemy in enemies)
        //        {
        //            enemy.OnDestroyEnemy();

        //        }
        //    }
        //        enemies.Clear();

        //}

        //    [ContextMenu("Test Spawn")]
        //    void Spawn()
        //    {

        //        CreateEnemy(Vector3.zero);
        //    }

        //    void CreateEnemy(Vector3 pos)
        //    {

        //        var index = UnityEngine.Random.Range(0, m_EnemyPrefabs.Count - 1);
        //        var enemySheep = Serivces.Get<IPoolingService>().Instantiate<Enemy>(m_EnemyPrefabs[index].gameObject);
        //    ///    enemySheep.GetComponent<Health>().OnH;
        //        enemySheep.transform.position = pos;
        //        enemySheep.transform.SetParent(this.transform);
        //        //float scaleModifier = (Random.Range(5f, 8f));
        //        //asteroid.transform.localScale = new Vector3(scaleModifier, scaleModifier, scaleModifier);
        //        enemies.Add(enemySheep);


        //    }

        //     private bool IsVisibleToPlayer(Vector3 pos)
        //    {
        //        var cameraPos = GameServices.Get<CameraService>().MainCamera.transform.position;

        //        ///Ray ray = cam.ScreenPointToRay(pos);
        //        RaycastHit hit;
        //        RaycastHit hitInfo;
        //        int layerMask = 16;

        //       // Debug.DrawRay(ray.origin, ray.direction * 100000, Color.yellow);
        //        //if (Physics.Linecast(cameraPos, pos, out hitInfo , layerMask))
        //        //{
        //        //   //// print("I'm looking at nddothing!");

        //        //}

        //        //else
        //        //    ////print("I'm looking at nothing!");

        //        return false;
        //    }
    }
}

