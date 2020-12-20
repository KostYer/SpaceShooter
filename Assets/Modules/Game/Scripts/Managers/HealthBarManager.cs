using System.Collections.Generic;
using UnityEngine;
using Game.Core;
using System;
using System.Linq;

namespace Game.GamePlay
{
    internal class HealthBarManager
    {
        private HealthBar pr_healthBarPrefab;
        private Dictionary<Health, HealthBar> healthBars = new Dictionary<Health, HealthBar>();
        public HealthBarManager(HealthBar pr_healthBarPrefab)
        {
            this.pr_healthBarPrefab = pr_healthBarPrefab;
            Health.OnHealthAdded += AddHealthBar;
            Health.OnHealtRemoved += RemoveHealthBar;
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
            
            for (int i = 0; i < healthBars.Keys.Count; i++)
            {
                Health health = healthBars.ElementAt(i).Key;
                RemoveHealthBar(health);
            }


        }


    }








}
 
 