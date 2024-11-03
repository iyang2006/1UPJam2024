using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMove : MonoBehaviour
{
    public float sideAccel;
    public float sideTopSpeed;
    public float stopDistance;
    public float stopTime;
    public Vector3 verticalVelocity;

    private float sideVelocity;
    private float targetPos;
    private InputAction moveAction;

    private void Start()
    {
        targetPos = transform.position.x;
        moveAction = GetComponent<PlayerInput>().actions.FindAction("Move");
    }

    void Update()
    {
        SideMovement();
    }

    public void OnJump()
    {

    }

    private void SideMovement()
    {
        float displacement = moveAction.ReadValue<float>();
        if (displacement != 0)
        {
            sideVelocity += displacement * sideAccel * Time.deltaTime;
            if (Mathf.Abs(sideVelocity) > sideTopSpeed)
            {
                sideVelocity = displacement * sideTopSpeed;
            }
            //targetPos = transform.position.x + sideVelocity * Time.deltaTime
            //            + stopDistance;
            transform.position += new Vector3(sideVelocity, 0, 0) * Time.deltaTime;
        }
        else
        {
            sideVelocity = 0;
            //float newX = Mathf.SmoothDamp(transform.position.x, targetPos,
            //            ref sideVelocity, stopTime);
            //transform.position += new Vector3(newX, 0, 0) * Time.deltaTime;

            //Vector3 yv = Vector3.zero;
            //Vector3 target = new Vector3(4, transform.position.y, transform.position.z);
            //transform.position = Vector3.SmoothDamp(transform.position, target, ref yv, stopDistance / stopTime);
            
        }
    }
}