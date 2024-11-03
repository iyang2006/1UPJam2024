using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //[SerializeField] private float gravityWhenGoingUp;
    //[SerializeField] private float gravityWhenGoingDown;

    [SerializeField] private float gravity;

    [HideInInspector] public Vector3 velocity;

    private Vector3 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        Vector3 currPos = transform.position;
        if (currPos.y - lastPos.y > 0)
        {
        }
    }
}
