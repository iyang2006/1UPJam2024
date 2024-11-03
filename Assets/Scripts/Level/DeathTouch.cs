using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : MonoBehaviour
{
    private SpawnManager spawnManage;

    // Start is called before the first frame update
    void Start()
    {
        spawnManage = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    private void OnCollisionEnter2D(Collision2D colsn) {
        GameObject colObj = colsn.gameObject;
        if (colObj.tag == "Player") {
            spawnManage.RespawnPlayer();
        }
    }
}
