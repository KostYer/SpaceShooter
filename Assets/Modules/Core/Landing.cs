using UnityEngine;

namespace Game.Core
{
    class Landing : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Start Landing");

            Serivces.Register(new GameObjectsPool("Pool"));
            ApplicationManager.OpenMainMenu();

        }
    }
}