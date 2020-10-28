using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StansAssets.Foundation.Patterns;
using Modules.Game.UI;


namespace Game.GamePlay
{


    public class EnemyService  ///: MonoBehaviour
{

    
    readonly List<Enemy> m_Enemies = new List<Enemy>();
   

    public EnemyService( )
    {
        //m_GamePlayUI = gamePlayUIView;
        //m_GamePlayUI.OnRestartRequest += Restart;

        //Restart();
    }

    public void Register(Enemy enemy)
    {
            m_Enemies.Add(enemy);
            enemy.OnHit += OnEnemydHit;
    }

    public void Unregister(Enemy enemy)
    {
            m_Enemies.Remove(enemy);
            enemy.OnHit -= OnEnemydHit;
    }

    void Restart()
    {
        //using (ListPool<Enemy>.Get(out var enemyListCopy))
        //{
        //     enemyListCopy.AddRange(m_Enemies);
        //    foreach (var enemy in enemyListCopy)
        //    {
        //            enemy.Explode();
        //    }
        //}

        
    }

    void OnEnemydHit(Collision collision )
    {
         

            if (collision.gameObject.tag.Equals(GameTags.Projectile))
        {
               /// health.TakeDamage(5);
        }

        if (collision.gameObject.tag.Equals(GameTags.Player))
        {
            //  m_Lives--;
            /////  m_GamePlayUI.SetLivesCount(k_TotalLives, m_Lives);
            //  if (m_Lives <= 0)
            //  {
            //      Time.timeScale = 0;
            //      m_GamePlayUI.ShowGameOverScreen();
            //}
        }
    }
}



} 
