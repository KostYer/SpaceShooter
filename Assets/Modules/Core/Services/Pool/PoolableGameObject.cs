using System;
using UnityEngine;

namespace Game.Core
{
    public abstract class PoolableGameObject : MonoBehaviour
    {
        public abstract void Init(Action onRelease);
        public abstract void Release();
    }
}
