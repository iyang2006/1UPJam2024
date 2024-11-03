using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public bool canJump = false;

    private void OnTriggerStay(Collider other)
    {
        if (!other.isTrigger) canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canJump = false;
    }
}
