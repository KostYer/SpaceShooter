using Game.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Game.GamePlay
{
    public class ProjectileLauncher  : MonoBehaviour
    {

        [SerializeField] GameObject Pr_projectile;
        [SerializeField] Transform[] shootPoints;
        [SerializeField] float shootRate = 0.5f;
        [SerializeField] int damage = 5;
        [SerializeField] AudioSource laserAudio;
         

        float shootRateTimeStamp = 0f;

       
        



        public void Fire()
        {
            if (Time.time > shootRateTimeStamp)
            {

                foreach (var point in shootPoints)
                {

                    //  GameObject projectile = GameObject.Instantiate(Pr_projectile, point.position, point.transform.rotation) as GameObject;
                    var projectile= Serivces.Get<IPoolingService>().Instantiate(Pr_projectile.gameObject, point.position, point.transform.rotation);
                    projectile.GetComponent<Projectile>().Damage = damage;
                    projectile.tag = this.gameObject.tag;
                    ///projectile.transform.SetParent(transform);

                }
                laserAudio.Play();
                shootRateTimeStamp = Time.time + shootRate;
            }

        }
    }
}