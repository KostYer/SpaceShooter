﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public class PlayerInputContraller : MonoBehaviour
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
        }
    }
}
