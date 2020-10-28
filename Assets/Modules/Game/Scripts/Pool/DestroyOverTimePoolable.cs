using System;
using Game.Core;
using UnityEngine;
using System.Collections;

namespace Game.GamePlay
{
    public class DestroyOverTimePoolable : PoolableGameObject
    {
        [SerializeField]
        float m_PlayTime = 1f;
        
        Action m_OnComplete;
        
        public override void Init(Action onRelease)
        {
            m_OnComplete = onRelease;
            StartCoroutine(WaitForPlay());
        }
        
        IEnumerator WaitForPlay()
        {
            yield return new WaitForSeconds(m_PlayTime);
            m_OnComplete.Invoke();
        }
        
        public override void Release()
        {
            
        }
    }
}
