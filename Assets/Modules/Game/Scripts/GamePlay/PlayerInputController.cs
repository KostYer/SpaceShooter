using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public class PlayerInputController : MonoBehaviour
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public bool FireButton { get; private set; }



        void Update()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            FireButton = Input.GetKeyDown(KeyCode.Space);

            if (FireButton) Debug.Log("FireButton");
        }
    }

}