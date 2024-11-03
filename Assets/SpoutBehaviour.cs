using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoutBehaviour : MonoBehaviour
{
    [SerializeField] private float pushStrength;
    private SpriteRenderer thisRend;
    private BoxCollider2D thisBox;
    private Rigidbody2D playerBody;
    private bool active;
    private bool pushingPlayer;
    public bool debug = false;

    // Start is called before the first frame update
    void Start()
    {
        thisRend = this.GetComponent<SpriteRenderer>();
        thisBox = this.GetComponent<BoxCollider2D>();
        thisRend.enabled = false;
        thisBox.enabled = false;
        active = false;
        pushingPlayer = false;
        playerBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debug) {
            debug = false;
            SetSpoutActive(!active);
        }
    }

    void FixedUpdate() 
    {
        if (pushingPlayer) {
            Vector3 vel = playerBody.velocity;
            vel.y += Time.fixedDeltaTime * pushStrength * 1;
            playerBody.velocity = vel;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (active && col.gameObject.tag == "Player") {
            pushingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            pushingPlayer = false;
        }
    }

    public void SetSpoutActive(bool enbl) {
        thisRend.enabled = enbl;
        active = enbl;
        if (enbl == false) {
            pushingPlayer = false;
        }
    }

}
