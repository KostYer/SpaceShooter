using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    internal class MainMenuController : MonoBehaviour, IMainMenuView
    {
        public event Action OnStartButtonPressed;
        public event Action OnQuitButtonPressed;

        [SerializeField]
        private Button m_GameStartButton = default;
        [SerializeField]
        private Button m_QuitGameButton = default;

        private void Awake()
        {
            m_GameStartButton.onClick.AddListener(() => {
                OnStartButtonPressed?.Invoke();
            });

            m_QuitGameButton.onClick.AddListener(() => {
                OnQuitButtonPressed?.Invoke();
            });
        }
    }
}