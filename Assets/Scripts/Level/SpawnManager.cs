using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    private SpawnLoc[] spawnLocas;
    private GameObject player;
    private int spawnID = 0;
    private ZJump zJumper;
    void Start()
    {
        spawnLocas = this.GetComponentsInChildren<SpawnLoc>();
        for (int i = 0; i < spawnLocas.Length; i++) {
            spawnLocas[i].SetID(i);
        }
        player = GameObject.FindWithTag("Player");
        zJumper = GameObject.FindWithTag("ZJumpHandler").GetComponent<ZJump>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer() {
        if (spawnLocas[spawnID].IsNear()) {
            zJumper.SetNear();
        }
        else {
            zJumper.SetFar();
        }
        spawnLocas[spawnID].SpawnPlayer(player);
    }

    public void SetSpawnLoc(int newID) {
        spawnID = newID;
    }
}
