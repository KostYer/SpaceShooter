using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public class JoystickController : MonoBehaviour
    {
        [SerializeField] PlayerInputController playerInputController;
        [SerializeField] FixedJoystick fixedJoystick;
       

       
           

          //  void Start()
          //  {
             
          //////  playerInputController = GetComponent<PlayerInputController>();
          //  }


            void Update()
            {

            if (fixedJoystick.Horizontal > 0.1 || fixedJoystick.Vertical >0.1)
            {
                playerInputController.Horizontal = fixedJoystick.Horizontal;
                playerInputController.Vertical = fixedJoystick.Vertical;
            }
           

            ////    Debug.Log("JoystickController.Horizontal " + fixedJoystick.Horizontal );
        }
     }


    
}