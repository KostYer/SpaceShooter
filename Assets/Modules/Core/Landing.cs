using UnityEngine;

namespace Game.Core
{
    class Landing : MonoBehaviour
    {
        void Start()
        {


            Serivces.Register(new GameObjectsPool("Pool"));
            ApplicationManager.OpenMainMenu();

        }
    }
}