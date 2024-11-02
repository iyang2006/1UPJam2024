using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] roomTargets;

    // default to -10
    [SerializeField] private float cameraZ = -10;
    private Transform mainCam;
    void Start()
    {
        mainCam = GameObject.FindWithTag("CameraHolder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchRoom(int roomID) {
        Vector3 newPos = roomTargets[roomID].transform.position;
        newPos.z = cameraZ;
        mainCam.position = newPos;
    }
}
