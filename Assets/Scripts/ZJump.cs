using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ZJump : MonoBehaviour
{

    [SerializeField] private bool startNear = false;
    private Transform player;
    private Transform mainCamera;
    private bool isNear;

    public List<SpriteRenderer> farRenderers;
    public List<SpriteRenderer> nearRenderers;
    public UnityEngine.Object[] allRenderers;


    [SerializeField] private bool zJumpDEV = false;



    // Start is called before the first frame update
    void Start()
    {
        allRenderers = FindObjectsOfType(typeof(SpriteRenderer));
        foreach (SpriteRenderer renderer in allRenderers)
        {
            if (renderer.gameObject.tag == "Player") continue;
            if (renderer.gameObject.transform.localToWorldMatrix.GetPosition().z > -5f)
            {
                farRenderers.Add(renderer);
            }
            else
            {
                nearRenderers.Add(renderer);
            }
        }
        //FindObjectsOfType
        isNear = startNear;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = GameObject.FindGameObjectWithTag("CameraHolder").transform;
        setSpriteAlphas();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            zJump();
        }

        if (zJumpDEV)
        {
            zJumpDEV = false;
            zJump();
        }
    }


    public void zJump()
    {
        if (isNear)
        {
            //JumpFar
            isNear = false;
            player.position = player.position + new Vector3(0f, 0f, 10f);
            //mainCamera.position = mainCamera.position + new Vector3(0f, 0f, 20f);
        } else
        {
            //JumpNear
            isNear = true;
            player.position = player.position + new Vector3(0f, 0f, -10f);
            //mainCamera.position = mainCamera.position + new Vector3(0f, 0f, -20f);
        }
        setSpriteAlphas();
    }


    public void setSpriteAlphas()
    {
        foreach (SpriteRenderer renderer in nearRenderers)
        {
            //float alpha = (isNear) ? 0.5
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, ((isNear) ? 1f : 0.3f));
        }
        foreach (SpriteRenderer renderer in farRenderers)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, ((!isNear) ? 1f : 0.3f));
        }
    }
}
