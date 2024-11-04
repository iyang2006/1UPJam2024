using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEvent : MonoBehaviour
{

    [SerializeField] private InteractUse interactUse;
    [SerializeField] private SpriteRenderer doorRenderer;
    [SerializeField] private GameObject doorWay;
    [SerializeField] private ZomMove zombie;
    private bool isCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        doorRenderer.enabled = false;
        doorWay.SetActive(false);
        zombie.enabled = false;
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
        //zombie.enabled = true;
        StartCoroutine(activeZombie());
    }

    private IEnumerator activeZombie()
    {
        yield return new WaitForSeconds(4f);
        zombie.enabled = true;
    }
}
