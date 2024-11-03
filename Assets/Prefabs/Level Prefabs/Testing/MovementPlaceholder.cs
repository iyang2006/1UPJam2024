using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlaceholder : MonoBehaviour
{
    [SerializeField] private Transform thisTransform;
    [SerializeField] private Rigidbody thisBody;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inpHor = Input.GetAxisRaw("Horizontal");
        float inpVer = Input.GetAxisRaw("Vertical");
        Vector2 vel = Vector2.zero;
        vel.y = thisBody.velocity.y;
        vel.x = inpHor * speed;
        if (inpVer > 0) {
            vel.y = inpVer * speed;
        }
        thisBody.velocity = vel;
    }
}
