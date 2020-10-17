using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    GameObject Pr_projectile;
    [SerializeField]
    Transform hitPoint;
    float shootRate =0.5f;
    float shootRateTimeStamp = 0f;
    public float rotation;



    void Start()
    {
       
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (Time.time > shootRateTimeStamp)
            {
                Fire();
                shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }


    public void Fire()
    {
       GameObject projectile = Instantiate(Pr_projectile, hitPoint.position, hitPoint.transform.rotation   ) as GameObject;
      
 
      

    }
}
