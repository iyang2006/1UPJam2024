using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private Transform targetTrans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            col.gameObject.transform.position = targetTrans.position;
        }
    }
}
