using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ZomMove : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float pointX1;
    [SerializeField] private float pointX2;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private bool toX1 = false;
    private bool turning = false;
    private int dir;
    private float angle = 0;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = GetDirection(pointX2);
    }

    void Update()
    {
        if (!toX1)
        {
            if (!turning)
            {
                animator.SetFloat("Speed", 1);
                dir = GetDirection(pointX2);
                rb.velocity = new Vector3(dir * speed, 0, 0);
                if (Mathf.Abs(transform.position.x - pointX2) < 0.3)
                {
                    rb.velocity = Vector3.zero;
                    turning = true;
                }
            }
            else
            {
                animator.SetFloat("Speed", 0);
                float angleChange = turnSpeed * Time.deltaTime;
                angle += angleChange;
                if (angle >= 180)
                {
                    angleChange = Mathf.Abs(180 - angle);
                    toX1 = true;
                    turning = false;
                    angle = 0;
                }
                transform.Rotate(0, angleChange, 0, Space.World);
            }
        }
        else
        {
            if (!turning)
            {
                animator.SetFloat("Speed", 1);
                dir = GetDirection(pointX1);
                rb.velocity = new Vector3(dir * speed, 0, 0);
                if (Mathf.Abs(transform.position.x - pointX1) < 0.3)
                {
                    rb.velocity = Vector3.zero;
                    turning = true;
                }
            }
            else
            {
                animator.SetFloat("Speed", 0);
                float angleChange = turnSpeed * Time.deltaTime;
                angle += angleChange;
                if (angle >= 180)
                {
                    angleChange = Mathf.Abs(180 - angle);
                    toX1 = false;
                    turning = false;
                    angle = 0;
                }
                transform.Rotate(0, angleChange, 0, Space.World);
            }
        }
    }

    private int GetDirection(float toPoint)
    {
        if (transform.position.x - toPoint > 0)
        {
            return -1;
        }
        return 1;
    }
}
