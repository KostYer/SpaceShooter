using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    internal class InGameMenuView : MonoBehaviour, IInGameMenuView
    {
        public event Action OnBackToMenuRequested;

        [SerializeField]
        private Button m_BackButton = default;

        private void Awake()
        {
            m_BackButton.onClick.AddListener(() => {
                OnBackToMenuRequested?.Invoke();
            });
        }
    }
}