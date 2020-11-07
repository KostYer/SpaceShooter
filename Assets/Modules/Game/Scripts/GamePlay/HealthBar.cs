
using Game.Core;
using System;
using UnityEngine;
using UnityEngine.UI;



namespace Game.GamePlay
{ 
public class HealthBar : PoolableGameObject
    {



    [SerializeField]  private Image foregroundImage;
 //   [SerializeField] private float positionOffset;

      public event Action onDestroy;

    public Health health;



    public void SetHealth(Health health)
    {
        this.health = health;
        health.OnHealthChanged += HandleHealthChange;
        HandleHealthChange(1);

        }

    private void HandleHealthChange(float amount)
    {
        foregroundImage.fillAmount = amount;
        foregroundImage.color = Color.Lerp(Color.red, Color.green, amount);
    }

        public void DestroyHealthBar()
        {
            health.OnHealthChanged -= HandleHealthChange;
            onDestroy?.Invoke();
           onDestroy = null;

        }

    
    void LateUpdate()
    {
 
        transform.position =  (health.transform.position + Vector3.up * 2f);
       //// transform.LookAt(Camera.main.transform);
        transform.LookAt(GameServices.Get<CameraService>().MainCamera.transform);
        }



        public override void Init(Action onRelease)
        {
            onDestroy += onRelease;
        }

        public override void Release()
        {
            
        }

    }
}
