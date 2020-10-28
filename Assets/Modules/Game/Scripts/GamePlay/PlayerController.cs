using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public class PlayerController : MonoBehaviour
    {

        private PlayerMovement playerMovement;
        private ProjectileLauncher projectileLauncher;
        private PlayerInputController playerInputController;


        public Transform Player => this.transform;
        public static PlayerController instance;

        void Awake()
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

            gameObject.tag = GameTags.Player;

        }

        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            projectileLauncher = GetComponent<ProjectileLauncher>();
            playerInputController = GetComponent<PlayerInputController>();


        }

        void Update()
        {

            if (playerInputController.FireButton)
            {
                projectileLauncher.Fire();

            }

            playerMovement.direction = new Vector3(playerInputController.Horizontal, 0f, playerInputController.Vertical).normalized;

        }




    }
}