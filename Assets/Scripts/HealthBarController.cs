using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    //[SerializeField] private GameObject  pr_healthBarPrefab;
    [SerializeField] private HealthBar pr_healthBarPrefab;

    private Dictionary<Health, HealthBar> healthBars = new Dictionary<Health, HealthBar>();


    private void OnEnable()
    {
        Debug.Log("HealthBarController Awake");
        Health.OnHealthAdded += AddHealthBar;
        Health.OnHealtRemoved += RemoveHealthBar;
    }

    private void AddHealthBar(Health health)
    {

        if (!healthBars.ContainsKey(health))
        {

            var healtBarObject = Instantiate(pr_healthBarPrefab , transform/*, false*/);
            healthBars.Add(health, healtBarObject);
            healtBarObject.SetHealth(health);
 
        }

    }

    private void RemoveHealthBar(Health health)
    {
        Debug.Log("RemoveHealthBar 1");
        if (healthBars.ContainsKey(health))
        {

            Debug.Log("RemoveHealthBar 2");
            healthBars.Remove(health);
         //   Destroy(healthBars[health].gameObject);
          


        }
    }

    
}
