using Game.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




namespace Game.GamePlay
{
    public class HealthBarController  : MonoBehaviour
    {
        //[SerializeField] private GameObject  pr_healthBarPrefab;
        [SerializeField] private HealthBar pr_healthBarPrefab;

        private Dictionary<Health, HealthBar> healthBars = new Dictionary<Health, HealthBar>();


        private void OnEnable()
        {

            Health.OnHealthAdded += AddHealthBar;
            Health.OnHealtRemoved += RemoveHealthBar;
            //Debug.Log("HealthBarController OnEnable");
        }

        public static HealthBarController instance;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }



        private void AddHealthBar(Health health)
        {
        
            if (!healthBars.ContainsKey(health))
            {

              ///  Debug.Log("AddHealthBar");
                var healthBarObject = Serivces.Get<IPoolingService>().Instantiate<HealthBar>(pr_healthBarPrefab.gameObject);
           //     Debug.Log("healthBarObject " + healthBarObject.gameObject.name);
                //var healtBarObject = Instantiate(pr_healthBarPrefab, transform/*, false*/);           
                healthBarObject.SetHealth(health);
                ///healthBarObject.transform.SetParent(this.transform);

                healthBars.Add(health, healthBarObject);



            }

        }

        private void RemoveHealthBar(Health health)
        {

             if (healthBars.ContainsKey(health))
            {

            
                
               ///    Destroy(healthBars[health].gameObject);

                HealthBar healthBar = healthBars[health];
                healthBars.Remove(health);
                healthBar.DestroyHealthBar();
                


            }
        }


        public void ClearAllHealthBars()
        {
            //foreach (var hBar  in healthBars)
            //{

            //    Health health = hBar.Key;
            //    RemoveHealthBar(health);

            //}
            for (int i = 0; i < healthBars.Keys.Count; i++)
            {
                Health health = healthBars.ElementAt(i).Key;
                RemoveHealthBar(health);
            }


        }


    }
}
