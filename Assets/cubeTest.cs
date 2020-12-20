using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeTest : MonoBehaviour
{
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] Rigidbody rb;
    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(fixedJoystick.Horizontal) > 0.1 || Mathf.Abs(fixedJoystick.Vertical) > 0.1)
        {
             
            MoveTest(fixedJoystick.Horizontal, fixedJoystick.Vertical);
        }

    }

    private void MoveTest(float h, float v)
    {
        
        float zangle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
        this.transform.eulerAngles = new Vector3(0,  zangle,0 );

         rb.MovePosition(rb.position  + transform.forward * 15f * Time.deltaTime);
      
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position+transform.forward *15f  );
    }

}
