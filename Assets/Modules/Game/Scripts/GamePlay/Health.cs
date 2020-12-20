using Game.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay

{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth;
        public int currentHealth;/// { get; private set; }
        [HideInInspector]
       

        public static  event Action<Health> OnHealthAdded = delegate { };  // to add healthBar 
        public static event Action<Health> OnHealtRemoved = delegate { };
        
        
        public event Action OnHealthDepleted = delegate { }; // to   destroy owner 
        public event Action<float> OnHealthChanged = delegate { }; // to update healthBar UI





         

        public void InitilazeHealth()
        {
            currentHealth = maxHealth;
            OnHealthAdded?.Invoke(this);
      

        }
          

       public void TakeDamage(int amount)
        {
        
            currentHealth -= amount;
            var healthPercentage = (float)currentHealth / (float)maxHealth;
            OnHealthChanged(healthPercentage);
            if (currentHealth <= 0)
            {
                Die();
            }

        }


        public void Die()
        {
            OnHealthDepleted?.Invoke();

            OnHealtRemoved(this);
         

        }

        public void OnDisable()
        {
            OnHealtRemoved(this);


        }

        
    }
}
