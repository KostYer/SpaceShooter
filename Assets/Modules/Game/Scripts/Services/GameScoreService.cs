using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StansAssets.Foundation.Patterns;
using Modules.Game.UI;


namespace Game.GamePlay
{
    public class GameScoreService
    {




        const int k_TotalLives = 5;

        int m_Score;
        int m_Lives;
        readonly IGamePlayUIView m_GamePlayUI;
        readonly List<Asteroid> m_Asteroids = new List<Asteroid>();

        public GameScoreService(IGamePlayUIView gamePlayUIView)
        {
            //    m_GamePlayUI = gamePlayUIView;
            //    m_GamePlayUI.OnRestartRequest += Restart;

            //    Restart();
        }













    }

}
