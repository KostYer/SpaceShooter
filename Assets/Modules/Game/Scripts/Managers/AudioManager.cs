using System;
using UnityEngine;


namespace Game.GamePlay
{
    public  class AudioManager
    {
          
        public AudioManager() 
        {
            
        }



        public void PlayEnemyDeathAudio( )
        {
            AudioClip explosionSound = Resources.Load<AudioClip>("Sounds/Explosion1");
            AudioSource.PlayClipAtPoint(explosionSound, Vector3.zero);
        }


    }
}