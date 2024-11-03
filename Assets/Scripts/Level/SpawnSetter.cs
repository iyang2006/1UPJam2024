using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSetter : MonoBehaviour
{
    private SpawnLoc spawnLocParent;

    void Start() {
        spawnLocParent = this.GetComponentInParent<SpawnLoc>();
    }

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            spawnLocParent.SetThisLoc();
        }
    }
}
