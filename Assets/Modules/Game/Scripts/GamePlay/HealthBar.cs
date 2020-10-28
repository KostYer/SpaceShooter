
using System;
using UnityEngine;
using UnityEngine.UI;



namespace Game.GamePlay
{ 
public class HealthBar : MonoBehaviour
{



    [SerializeField]  private Image foregroundImage;
    [SerializeField] private float positionOffset;

    private Health health;



    public void SetHealth(Health health)
    {
        this.health = health;
        health.OnHealthChanged += HandleHealthChange;
         
    }

    private void HandleHealthChange(float amount)
    {
        foregroundImage.fillAmount = amount;
    }

     

    
    void LateUpdate()
    {
        // transform.position = Camera.main.WorldToScreenPoint(health.transform.position + Vector3.up * positionOffset);
        transform.position =  (health.transform.position + Vector3.up * 2f);
        //transform.rotation = health.transform.rotation;
        transform.LookAt(Camera.main.transform);
    }

    private void OnDestroy()
    {
        health.OnHealthChanged -= HandleHealthChange;
    }
}
}
