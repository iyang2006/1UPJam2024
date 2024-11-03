using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private Transform targetTrans;
    [SerializeField] private int targetRoom;
    private CamSwitcher camSwitch;
    // Start is called before the first frame update
    void Start()
    {
        camSwitch = GameObject.FindWithTag("CameraSwitcher").GetComponent<CamSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player" && !col.isTrigger) {
            col.gameObject.transform.position = targetTrans.position;
            camSwitch.SwitchRoom(targetRoom);
        }
        //camSwitch.SwitchRoom(targetRoom);
    }
}
