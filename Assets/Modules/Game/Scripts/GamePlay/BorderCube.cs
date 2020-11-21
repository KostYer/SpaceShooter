using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePlay
{
    public class BorderCube : MonoBehaviour
    {
        Camera cam;
        
        public float totalSeconds = 1.5f;     // The total of seconds the flash wil last
        public float maxIntensity = 3f;     // The maximum intensity the flash will reach
        void Start()
        {
            cam = GameServices.Get<CameraService>().MainCamera;
           
            //StartCoroutine(nameof(flashNow));
        }


        void Update()
        {
            var direcion = cam.transform.position - transform.position;
            transform.LookAt(direcion);
        }


        
    }
}
