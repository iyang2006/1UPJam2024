using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZJump : MonoBehaviour
{

    [SerializeField] private bool startNear = false;
    private bool isNear;



    // Start is called before the first frame update
    void Start()
    {
        isNear = startNear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void zJump()
    {
        if (isNear)
        {
            //JumpFar
        } else
        {
            //JumpNear
        }
    }
}
