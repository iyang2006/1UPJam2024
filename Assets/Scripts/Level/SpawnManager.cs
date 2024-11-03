using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    private SpawnLoc[] spawnLocas;
    private GameObject player;
    private int spawnID = 0;
    void Start()
    {
        spawnLocas = this.GetComponentsInChildren<SpawnLoc>();
        for (int i = 0; i < spawnLocas.Length; i++) {
            spawnLocas[i].SetID(i);
        }
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer() {
        spawnLocas[spawnID].SpawnPlayer(player);
    }

    public void SetSpawnLoc(int newID) {
        spawnID = newID;
    }
}
