using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZJumpChecker : MonoBehaviour
{

    private ZJump zJump;

    // Start is called before the first frame update
    void Start()
    {
        zJump = GameObject.FindGameObjectWithTag("ZJumpHandler").GetComponent<ZJump>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StaticSprite" || other.gameObject.GetComponent<SpriteRenderer>() == null) return;
        zJump.interruptingObjects.Add(other.gameObject);
        zJump.jumpInterrupted = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!zJump.interruptingObjects.Contains(other.gameObject)) return;
        zJump.interruptingObjects.Remove(other.gameObject);
        zJump.jumpInterrupted = (zJump.interruptingObjects.Count > 0);
    }
}
