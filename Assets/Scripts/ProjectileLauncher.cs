using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    [SerializeField] GameObject Pr_projectile;
    [SerializeField] Transform[] shootPoints;
    [SerializeField] float shootRate = 0.5f;


    float shootRateTimeStamp = 0f;

     


    public void Fire()
    {
        if (Time.time > shootRateTimeStamp)
        {

            foreach (var point in shootPoints)
            {

                GameObject projectile = Instantiate(Pr_projectile, point.position, point.transform.rotation) as GameObject;

            }
            shootRateTimeStamp = Time.time + shootRate;
        }

    }
}