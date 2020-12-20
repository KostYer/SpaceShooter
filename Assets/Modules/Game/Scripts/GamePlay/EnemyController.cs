using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.GamePlay

{
    enum States
    {
        Chase,
        Attack
    }

    [RequireComponent (typeof(NavMeshAgent))]
    public class EnemyController : MonoBehaviour
    {  
        [Header("NavMeshSettings")]
        public NavMeshAgent navAgent;
        [SerializeField] private float movementSpeed = 20f;
        [SerializeField] private float angularSpeed = 120f;
        [SerializeField] private float acceleration = 15;
        [SerializeField] private float stopDistance = 20f;

        [SerializeField] private float distanceToStop;


        [SerializeField] private float pathRecalculateRate = 3f;
        private Vector3 target;

        private States state;
        //private float currentDistance;
        private float pathRecalculateTimeStamp = 0f;
        private Vector3 targert;
        private ProjectileLauncher projectileLauncher;

        ///public event Action OnDestinationReached;
        // Vector3 clickPoint;


        



        void Start()
        {
            ///  initilazeNavMeshAgent();
            /// InvokeRepeating("ChaseTarget", 1,  1f);
            target =  GameServices.Get<PlayerManager>().PlayerPosition; // new Transform();// Player.instance.transform;
            state = IsCloseEnoughToShoot() ? States.Attack : States.Chase;

            projectileLauncher = GetComponent<ProjectileLauncher>();

            gameObject.tag = GameTags.Enemy;


        }

        void Update()
        {

            target =   GameServices.Get<PlayerManager>().PlayerPosition;


            if (state == States.Chase)
            {
               // Debug.Log("Chase");
                ChaseTarget();


                if (IsCloseEnoughToShoot())
                {

                    state = States.Attack;
                }

            }

            else if (state == States.Attack)
            {
              //  Debug.Log("Attack");
                StopMovement();
                Attack();
                if (!IsCloseEnoughToShoot())
                {
                    state = States.Chase;
                }
            }

            if (Vector3.Distance(this.transform.position, target) <= stopDistance * 0.7f)
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
           //// Debug.Log("move back");
        }

        private void RotateTowardsTarget()
        {
            Vector3 relativePos = target - transform.position;
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
            
            
         ///   if  (navAgent.enabled = false) navAgent.enabled = true;
            if (navAgent.isStopped) navAgent.isStopped = false;
            if (Time.time > pathRecalculateTimeStamp)
            {
                //Vector3 destination =  Player.instance.transform.position;
                Vector3 destination = GameServices.Get<PlayerManager>().PlayerPosition;
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


        private void Attack()
        {
            RotateTowardsTarget();
            projectileLauncher.Fire();


        }

        void SetTargetPosition()
        {
            target = GameServices.Get<PlayerManager>().PlayerPosition;

        }

        bool IsCloseEnoughToShoot()
        {
            return Vector3.Distance(this.transform.position, target ) <= stopDistance;


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


        public void DisableNavMeshAgent()
        {
           /// this.navAgent.enabled = false;
            navAgent.ResetPath();
        }

        public void EnableNamMeshAgent()
        {
         ///   this.navAgent.enabled = true;
          
        }
    }
}


