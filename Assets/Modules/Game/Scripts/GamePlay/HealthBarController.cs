using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Game.GamePlay
{
    public class HealthBarController : MonoBehaviour
    {
        //[SerializeField] private GameObject  pr_healthBarPrefab;
        [SerializeField] private HealthBar pr_healthBarPrefab;

        private Dictionary<Health, HealthBar> healthBars = new Dictionary<Health, HealthBar>();


        private void OnEnable()
        {
             
            Health.OnHealthAdded += AddHealthBar;
            Health.OnHealtRemoved += RemoveHealthBar;
        }

        private void AddHealthBar(Health health)
        {

            if (!healthBars.ContainsKey(health))
            {

                var healtBarObject = Instantiate(pr_healthBarPrefab, transform/*, false*/);
                healthBars.Add(health, healtBarObject);
                healtBarObject.SetHealth(health);

            }

        }

        private void RemoveHealthBar(Health health)
        {

            if (healthBars.ContainsKey(health))
            {

                Debug.Log("RemoveHealthBar");
                healthBars.Remove(health);
                //   Destroy(healthBars[health].gameObject);



            }
        }


    }
}
