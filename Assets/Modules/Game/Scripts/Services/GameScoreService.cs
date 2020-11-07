﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StansAssets.Foundation.Patterns;
using Modules.Game.UI;
using Game.Core;
using System;
using UnityEngine.UI;

namespace Game.GamePlay
{
    public class GameScoreService
    {

       

        int m_Score;
        int highScore =0;


        readonly IGamePlayUIView m_GamePlayUI;

        public static event Action OnRestartGame = delegate { };
        
 


        public GameScoreService(IGamePlayUIView gamePlayUIView)
        {
            m_GamePlayUI = gamePlayUIView;
            m_GamePlayUI.OnRestartRequest += Restart;
            m_GamePlayUI.OnRestartRequest += PlayerSpawner.instance.SpawnPlayer;
            m_GamePlayUI.OnRestartRequest += GameServices.Get<EnemySpawnerService>().SpawnEnemiesOnField;
            m_GamePlayUI.OnRestartRequest += AsteroidSpawner.instance.PopulatePlaneWithsteroids;



            Player.OnPlayerDied += ProcessGameOver;
            

            // Player.OnPlayerDied += EnemySpawner.instance.DestroyAllEnemies;
            ///  EnemySpawner.OnDisableEnemies += Restart;
            Restart();
          /////  PlayerSpawner.instance.SpawnPlayer();
          
        }

        public void Register(Enemy enemy)
        {
            
             
           enemy.OnDestroy += OnEnemyDied;
           
        }

        public void Unregister(Enemy enemy)
        {


            enemy.OnDestroy -= OnEnemyDied;
        }


        void OnEnemyDied()
        {
           
                m_Score ++;
                m_GamePlayUI.SetScore(m_Score);
          
                //Debug.Log("enemyDied");
           
        
        }

        void ProcessGameOver()
        {   
            HandleGameScore();
            m_GamePlayUI.ShowGameOverScreen();
            m_GamePlayUI.OnGameOver(m_Score, highScore);
         
            GameServices.Get<EnemySpawnerService>().DestroyAllEnemies();
            AsteroidSpawner.instance.DestroyAllAsteroids();
            HealthBarController.instance.ClearAllHealthBars();
            Time.timeScale = 0f;
            m_Score = 0;
            //m_GamePlayUI.SetHighScore(m_Score);
            //m_GamePlayUI.SetCurrentScore(m_Score);
        }
         



        void Restart()
        {

            
            m_Score = 0;
            m_GamePlayUI.SetScore(m_Score);
       


            ///   m_GamePlayUI.SetLivesCount(k_TotalLives, m_Lives);
            m_GamePlayUI.ShowGamePlayUI();
            Time.timeScale = 1f;
        }



 private void HandleGameScore( )
   {
        string highScoreKey = "highscore";


        if (PlayerPrefs.HasKey(highScoreKey))
        {
            highScore = PlayerPrefs.GetInt(highScoreKey);
        }

        if (m_Score > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, m_Score);
            highScore = PlayerPrefs.GetInt(highScoreKey);

        }

        //}
            
        }


    }
    }
 













 