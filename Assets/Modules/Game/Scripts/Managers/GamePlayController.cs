using Game.Core;
using Modules.Game.UI;
using UnityEngine;

namespace Game.GamePlay
{
    public class GamePlayController : MonoBehaviour
    {
        [SerializeField]
        GamePlayUIView m_GamePlayUIView = default;
        
        void Awake()
        {
            // Should be done on landing
            Serivces.Register<IPoolingService>(new GameObjectsPool("Pool"));
            GameServices.Register(new EnemyService());
            GameServices.Register(new CameraService(Camera.main));
            GameServices.Register(new AsteroidsService(m_GamePlayUIView));
            
        }
    }
}