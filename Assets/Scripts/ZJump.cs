using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZJump : MonoBehaviour
{

    [SerializeField] private bool startNear = false;
    private Transform player;
    private Transform mainCamera;
    private bool isNear;


    [SerializeField] private bool zJumpDEV = false;



    // Start is called before the first frame update
    void Start()
    {
        isNear = startNear;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = GameObject.FindGameObjectWithTag("CameraHolder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("LeftShift"))
        {
            zJump();
        }*/

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
            player.position = player.position + new Vector3(0f, 20f, 0f);
            mainCamera.position = mainCamera.position + new Vector3(0f, 20f, 0f);
        } else
        {
            //JumpNear
            isNear = true;
            player.position = player.position + new Vector3(0f, -20f, 0f);
            mainCamera.position = mainCamera.position + new Vector3(0f, -20f, 0f);
        }
    }
}
