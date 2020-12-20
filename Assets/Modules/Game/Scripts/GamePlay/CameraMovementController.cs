using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay
{ 
[RequireComponent(typeof(Camera))]
public class CameraMovementController : MonoBehaviour
{
    private Camera cam;
     Vector3 playerPosition;
    [SerializeField] float height ;
    [SerializeField] float distance ;
    [SerializeField] float angle;
    [SerializeField] float smoothingSpeed;

    Vector3 smoothVelociy;

    void Start()
    {
            cam = GameServices.Get<CameraService>().MainCamera;
            playerPosition = GameServices.Get<PlayerManager>().PlayerPosition;

    }

   
    void LateUpdate()
        {
            playerPosition = GameServices.Get<PlayerManager>().PlayerPosition;
            Vector3 worldPosition = (Vector3.forward * -distance) + (Vector3.up * height);
        Debug.DrawLine(playerPosition, worldPosition, Color.red);

        Vector3 rotationVector =  Quaternion.AngleAxis(angle , Vector3.up) * worldPosition;
        Debug.DrawLine(playerPosition, rotationVector, Color.blue);

        Debug.DrawLine(playerPosition, worldPosition, Color.green);


        //Vector3 flatTargetPosition = player.GetComponent<Rigidbody>().position;
        //flatTargetPosition.y = 0;

        Vector3 finalPosition = playerPosition + rotationVector;
        Debug.DrawLine(playerPosition, finalPosition, Color.blue);

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref smoothVelociy, smoothingSpeed);
        transform.LookAt(playerPosition);


    }



}
}
