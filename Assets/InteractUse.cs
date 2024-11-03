using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUse : Interactable
{

    [SerializeField] private itemName requiredItemType;
    public bool isCompleted = false;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        if (player.GetComponent<ItemHolder>().activeItem == requiredItemType && !isCompleted)
        {
            isCompleted = true;
            player.GetComponent<ItemHolder>().useItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            Interact();
        }
    }
}
