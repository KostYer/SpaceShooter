using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum States 
    {
      Chase, 
      Attack
    }

public class EnemyController : MonoBehaviour
{
    [Header("NavMeshSettings")]
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float angularSpeed = 120f;
    [SerializeField] private float acceleration = 15;
    [SerializeField] private float stopDistance = 20f;

    [SerializeField] private float distanceToStop;
    

    [SerializeField] private float pathRecalculateRate = 3f;
    private Transform target;
     
    private States state;
    private float currentDistance;
    private float pathRecalculateTimeStamp =0f;
    private Vector3 targert ;
    private ProjectileLauncher projectileLauncher;

    public event Action OnDestinationReached;
    Vector3 clickPoint;


 



    void Start()
    {
     ///  initilazeNavMeshAgent();
        /// InvokeRepeating("ChaseTarget", 1,  1f);
        target = PlayerController.instance.Player;
        state = IsCloseEnoughToShoot() ? States.Attack : States.Chase;

        projectileLauncher = GetComponent<ProjectileLauncher>();




    }

    void FixedUpdate()
    {




        
        //if (Input.GetMouseButtonDown(0))
        //    {
        //        /// Debug.Log("GetMouseButtonDown Enemy");
        //        //create a ray cast and set it to the mouses cursor position in game
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        RaycastHit hit;

        //        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //        {
        //        //Debug.Log("hit.point " + hit.point);
        //        //Debug.DrawRay(hit.point, this.transform.position, Color.red);

        //        targert = hit.point;
        //        navAgent.destination = targert ;
            
        //        //
        //        //    Debug.Log("pathPending  "+ navAgent.pathPending);
        //    }
        //    }

      
     
        //    currentDistance = Vector3.Distance(transform.position, targert );
        //Debug.Log("currentDistance " + currentDistance);
        //if (currentDistance <= distanceToStop)
        //    {
        //    Vector3 currentVelocity = navAgent.velocity;
        //    navAgent.velocity = Vector3.Lerp(currentVelocity, Vector3.zero, 0.5f);
        //    Fire();


        //    }

      ///  var rayDirection = targert - transform.position;
      ///  Debug.DrawRay(transform.position, rayDirection.normalized * distanceToStop, Color.red);
        /// navAgent.isStopped = navAgent.pathPending ? true : false;


         if (state == States.Chase)
         {
             Debug.Log("Chase");
            ChaseTarget();


             if (IsCloseEnoughToShoot())
             {

                 state = States.Attack;
             }

         }

         else if (state == States.Attack)
         {
             Debug.Log("Attack");
             StopMovement();
             Fire();
             if (!IsCloseEnoughToShoot())
             {
                 state = States.Chase;
             }
         }

        if (Vector3.Distance(this.transform.position, target.position) <= stopDistance * 0.7f)
        {
            MoveBackwards();
        }

        navAgent.enabled = true;
    }

    private void MoveBackwards()
    {
        //transform.LookAt(target.position);
        navAgent.enabled = false;
        transform.position += -transform.forward * movementSpeed * Time.fixedDeltaTime;
        RotateTowardsTarget();
        Debug.Log("move back");
    }

    private void RotateTowardsTarget()
    {
        Vector3 relativePos = target.position - transform.position;
        Quaternion desiredRotation = Quaternion.LookRotation(relativePos.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 5f * Time.deltaTime);

    }

    private void StopMovement()
    {
       Vector3 currentVelocity = navAgent.velocity;
       navAgent.velocity = Vector3.Lerp(currentVelocity, Vector3.zero, 0.8f);
      // navAgent.isStopped = true;
      

    }

    private void ChaseTarget()
    {
        if (navAgent.isStopped)  navAgent.isStopped = false;
        if (Time.time > pathRecalculateTimeStamp)
        {
            Vector3 destination = PlayerController.instance.Player.position;
         //   navAgent.ResetPath();
            //navAgent.SetDestination(destination);
            navAgent.destination = destination;
          
         ///  
        //    Debug.Log(" ChaseTarget destination " + destination.ToString() );
           
            ///Debug.Log("Warp " + navAgent.Warp(destination));
            pathRecalculateTimeStamp = Time.time + pathRecalculateRate;
          ///  Debug.Log("PathRecalculated");
        }
     


    }
 

    private void Fire()
    {
        RotateTowardsTarget();
        projectileLauncher.Fire();


    }

    void SetTargetPosition()
    {
        target = PlayerController.instance.Player;
       
    }

    bool IsCloseEnoughToShoot()
    {
        return Vector3.Distance(this.transform.position, target.position) <= stopDistance;


    }

    private void initilazeNavMeshAgent()
    {
        navAgent.stoppingDistance = stopDistance;
        navAgent.speed = angularSpeed;
        navAgent.acceleration = acceleration;
    }


    //private void OnDrawGizmos()
    //{   


    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(clickPoint, 1.5f) ;
    //}

}
