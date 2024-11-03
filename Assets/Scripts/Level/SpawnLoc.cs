using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoc : MonoBehaviour
{
    [SerializeField] private int roomID = 0;
    [SerializeField] private Transform spawnTrans;
    [SerializeField] private bool isNear;
    private int ourID = 0;
    private SpawnManager spawnParent;
    private CamSwitcher camSwitch;
    // Start is called before the first frame update
    void Start()
    {
        spawnParent = this.GetComponentInParent<SpawnManager>();
        camSwitch = GameObject.FindWithTag("CameraSwitcher").GetComponent<CamSwitcher>();
    }

    public void SetID(int id) {
        ourID = id;
    }

    public void SetThisLoc() {
        spawnParent.SetSpawnLoc(ourID);
    }

    public bool IsNear() {
        return isNear;
    }

    public void SpawnPlayer(GameObject player) {
        Debug.Log(spawnTrans.position);
        player.transform.position = spawnTrans.position;
        camSwitch.SwitchRoom(roomID);
    }
}
