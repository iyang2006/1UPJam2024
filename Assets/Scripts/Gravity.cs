using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    //[SerializeField] private float gravityWhenGoingUp;
    //[SerializeField] private float gravityWhenGoingDown;

    [SerializeField] private float gravity;
    [SerializeField] private float terminalVelocity;
    [SerializeField] private GameObject playerCollide;

    private bool canJump;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        canJump = playerCollide.GetComponent<PlayerTrigger>().canJump;
        if (!canJump)
        {
            Vector3 newVelocity = new Vector3(rb.velocity.x, rb.velocity.y - gravity * Time.deltaTime, 0);
            if (rb.velocity.y > terminalVelocity)
            {
                newVelocity = new Vector3(rb.velocity.x, terminalVelocity, 0);
            }
            rb.velocity = newVelocity;
        } else
        {
            Vector3 newVelocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            rb.velocity = newVelocity;
        }
    }
}
