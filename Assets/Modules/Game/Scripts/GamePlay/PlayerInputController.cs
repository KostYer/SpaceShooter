using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public  class PlayerInputController : MonoBehaviour
    {
        public float Horizontal { get;  set; }
        public float Vertical { get;  set; }
        public bool FireButton { get;  set; }



        void Update()
        {

            //Horizontal = Input.GetAxisRaw("Horizontal");
            //Vertical = Input.GetAxisRaw("Vertical");
            //FireButton = Input.GetKeyDown(KeyCode.Space);
            ///Debug.Log("PlayerInputController.Horizontal " + Horizontal);
            ////  if (FireButton) Debug.Log("FireButton");
        }
    }

}