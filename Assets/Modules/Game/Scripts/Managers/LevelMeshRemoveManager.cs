using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay { 
public class LevelMeshRemoveManager : MonoBehaviour
{
    [SerializeField]    GameObject levelObjects;
    void Start()
    {
            MeshRenderer[] meshes = levelObjects.GetComponentsInChildren<MeshRenderer>();

            foreach (var mr in meshes)
            {  
                mr.forceRenderingOff = true;

            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

}
