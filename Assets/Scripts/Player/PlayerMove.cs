using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float sideAccel;
    [SerializeField] private float sideDecel;
    [SerializeField] private float sideTopSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private GameObject playerCollide;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    private bool switchDir = false;
    private Rigidbody rb;
    private InputAction moveAction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = GetComponent<PlayerInput>().actions.FindAction("Move");
    }

    void Update()
    {
        SideMovement();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("ZJump");
        }
    }

    public void OnJump()
    {
        bool canJump = playerCollide.GetComponent<PlayerTrigger>().canJump;
        if (canJump)
        {
            Vector3 newVector = new Vector3(rb.velocity.x, jumpHeight, 0);
            rb.velocity = newVector;
            //What the fuck is happening unity?
        }
    }

    private void SideMovement()
    {
        float displacement = moveAction.ReadValue<float>();

        // If there is input for left or right, accelerate the player move in those directions
        if (displacement != 0)
        {
            Vector3 newVelocity = new Vector3(rb.velocity.x + displacement * sideAccel
                        * Time.deltaTime, rb.velocity.y, 0);
            if (Mathf.Abs(newVelocity.x) > sideTopSpeed)
            {
                newVelocity = new Vector3(displacement * sideTopSpeed, rb.velocity.y, 0);
            }
            rb.velocity = newVelocity;
            switchDir = false;

            spriteRenderer.flipX = (displacement < 0f);

            // If there is no input for left or right, decelerate the player
        } else
        {
            if (!switchDir && (rb.velocity.x != 0))
            {
                // Decelerate until the velocity is close to 0
                Vector3 xVelocity = new Vector3(rb.velocity.x, 0, 0).normalized;
                Vector3 newVelocity = new Vector3(rb.velocity.x - xVelocity.x
                            * sideDecel * Time.deltaTime, rb.velocity.y, 0);
                if (Mathf.Abs(newVelocity.x) < 0.3)
                {
                    switchDir = true;
                    newVelocity = new Vector3(0, rb.velocity.y, 0);
                }
                rb.velocity = newVelocity;
            }
        }

        animator.SetFloat("HorizontalSpeed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("VerticalVelocity", rb.velocity.y);
        animator.SetBool("IsOnGround", playerCollide.GetComponent<PlayerTrigger>().canJump);
        animator.SetBool("IsMoving", (displacement != 0f));
        animator.SetBool("IsSliding", ((displacement > 0f && rb.velocity.x < 0f) || (displacement < 0f && rb.velocity.x > 0f)));
    }
}