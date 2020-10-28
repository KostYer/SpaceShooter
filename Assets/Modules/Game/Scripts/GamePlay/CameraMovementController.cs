using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay
{ 
[RequireComponent(typeof(Camera))]
public class CameraMovementController : MonoBehaviour
{
    private Camera cam;
    [SerializeField] Transform player;
    [SerializeField] float height ;
    [SerializeField] float distance ;
    [SerializeField] float angle;
    [SerializeField] float smoothingSpeed;

    Vector3 smoothVelociy;

    void Start()
    {
        cam = GetComponent<Camera>();
       
    }

   
    void LateUpdate()
    {
        Vector3 worldPosition = (Vector3.forward * -distance) + (Vector3.up * height);
        Debug.DrawLine(player.position, worldPosition, Color.red);

        Vector3 rotationVector =  Quaternion.AngleAxis(angle , Vector3.up) * worldPosition;
        Debug.DrawLine(player.position, rotationVector, Color.blue);

        Debug.DrawLine(player.position, worldPosition, Color.green);


        Vector3 flatTargetPosition = player.position;
        flatTargetPosition.y = 0;

        Vector3 finalPosition = flatTargetPosition + rotationVector;
        Debug.DrawLine(player.position, finalPosition, Color.blue);

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref smoothVelociy, smoothingSpeed);
        transform.LookAt(player);


    }



}
}
