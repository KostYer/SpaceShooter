using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GamePlay
{
    public class JoystickController : MonoBehaviour
    {
        [SerializeField] PlayerInputController playerInputController;
        [SerializeField] FixedJoystick fixedJoystick;
        [SerializeField] Button fireButton;



        void Start()
        {

            fireButton.onClick.AddListener(FireButtonHandler);
        }

        private void FireButtonHandler()
        {
            playerInputController.FireButton = true;
          //  playerInputController.FireButton = false;
        }

        void Update()
            {
        
            playerInputController.FireButton = false;
            //if (fixedJoystick.Direction.magnitude > 0.1)

            //{
                playerInputController.Horizontal = fixedJoystick.Horizontal;
                playerInputController.Vertical = fixedJoystick.Vertical;
               // playerInputController.FireButton = 
            //}
                
        
            

            ////    Debug.Log("JoystickController.Horizontal " + fixedJoystick.Horizontal );
        }
     }


    
}