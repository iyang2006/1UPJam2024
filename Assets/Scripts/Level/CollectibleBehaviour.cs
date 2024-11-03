using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : Interactable
{
    [SerializeField] private int itemID;

    public override void Interact() {
        Debug.Log(itemID);
        // give the player the item
    }
}
