using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    internal class InGameMenuView : MonoBehaviour, IInGameMenuView
    {
        public event Action OnBackToMenuRequested;
        public event Action OnPauseRequested;
        public event Action OnGameResumeRequested;

        [SerializeField]
        private Button m_BackButton = default;
        [SerializeField]
        private Button m_PauseButton = default;
        [SerializeField]
        private Button m_ResumeButton = default;
        [SerializeField]
        private Image screenPanel = default;

        [SerializeField] Camera cam;

        private void Awake()
        {
            OnPauseRequested += HandlePause;
            OnGameResumeRequested += HandleResumeGame;
            m_BackButton.onClick.AddListener(() => {
                OnBackToMenuRequested?.Invoke();
            });

            m_PauseButton.onClick.AddListener(() => {
                OnPauseRequested?.Invoke();
            });
            m_ResumeButton.onClick.AddListener(() => {
                OnGameResumeRequested?.Invoke();
            });
        }


        void HandlePause()
        {
            Time.timeScale = 0f;
            screenPanel.gameObject.SetActive(true)  ;
            cam.gameObject.SetActive(true);
            m_PauseButton.gameObject.SetActive(false);
        }

        void HandleResumeGame()
        {
            Time.timeScale = 1f;
            screenPanel.gameObject.SetActive(false);
            cam.gameObject.SetActive(false);
            m_PauseButton.gameObject.SetActive(true);
        }

    }
}