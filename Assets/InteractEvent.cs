using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEvent : MonoBehaviour
{

    [SerializeField] private InteractUse interactUse;
    [SerializeField] private SpriteRenderer doorRenderer;
    [SerializeField] private GameObject doorWay;
    private bool isCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        doorRenderer.enabled = false;
        doorWay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interactUse.isCompleted && !isCompleted)
        {
            isCompleted = true;
            doEvent();
        }
    }

    public void doEvent()
    {
        isCompleted = true;
        doorRenderer.enabled = true;
        doorWay.SetActive(true);
    }
}
