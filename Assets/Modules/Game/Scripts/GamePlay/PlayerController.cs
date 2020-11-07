﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public class PlayerController : MonoBehaviour
    {

        private PlayerMovement playerMovement;
        private ProjectileLauncher projectileLauncher;
        [SerializeField] PlayerInputController playerInputController;


     //   public Transform Player => this.transform;


        ///public static PlayerController instance;

        void Awake()
        {
            

            gameObject.tag = GameTags.Player;

        }

        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            projectileLauncher = GetComponent<ProjectileLauncher>();
          ///  playerInputController = GetComponent<PlayerInputController>();


        }

        void Update()
        {

            if (playerInputController.FireButton)
            {
                Debug.Log("FireButton");
                projectileLauncher.Fire();

            }

            playerMovement.direction = new Vector3(playerInputController.Horizontal, 0f, playerInputController.Vertical).normalized;

        }




    }
}