using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int CurrentHealth { get; private set; }

    public static event Action<Health> OnHealthAdded = delegate { };
    public static event Action<Health> OnHealtRemoved = delegate { };


    public event Action <float> OnHealthChanged = delegate { };




    private void Start()
    {
        CurrentHealth = maxHealth;
        OnHealthAdded(this);
        Debug.Log("Health EnableD");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            TakeDamage(10);
            Debug.Log("CurrentHealth " + CurrentHealth);
        }


    }

    void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        var healthPercentage = (float)CurrentHealth /(float)maxHealth;
        OnHealthChanged(healthPercentage);
        if (CurrentHealth <= 0)
            {
           Die();
            }

    }


    void  Die()
    {
        ///  AsteroidSpawner.OnDied? invoke();
        Debug.Log(" Die ");

    }

    private void OnDisable()
    {
        OnHealtRemoved(this);


    }
}
