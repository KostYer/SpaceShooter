using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GamePlay
{
    public  class PlayerInputController : MonoBehaviour
    {
        public float Horizontal { get;  set; }
        public float Vertical { get;  set; }
        public bool FireButton { get;  set; }

        private FixedJoystick joystick;
        private Button onScreenFireButton;
        private void Start()
        {
            joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
            onScreenFireButton = GameObject.FindGameObjectWithTag("FireButton").GetComponent<Button>();
            onScreenFireButton.onClick.AddListener(HandleFireButtonDown);
          
        }

        private void HandleFireButtonDown()
        {
            FireButton = true;
          
        }

        void Update()
        {
            FireButton = false;
            Horizontal = joystick.Horizontal;
            Vertical = joystick.Vertical;

            //Horizontal = Input.GetAxisRaw("Horizontal");
            //Vertical = Input.GetAxisRaw("Vertical");
            //FireButton = Input.GetKeyDown(KeyCode.Space);

           
        }
    }

}