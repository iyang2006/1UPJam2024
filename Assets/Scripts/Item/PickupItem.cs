using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    [SerializeField] private itemName itemType;
    private bool isInteractable = false;
    private GameObject player;
    private bool isActivating = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(activateItem());
    }

    // Update is called once per frame
    void Update()
    {
        if (/*Input.GetKeyDown(KeyCode.E) &&*/ isInteractable) {
            player.GetComponent<ItemHolder>().startHoldingItem(itemType);
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isActivating)
        {
            player = other.gameObject;
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteractable = false;
        }
    }


    private IEnumerator activateItem()
    {
        isActivating = true;
        yield return new WaitForSeconds(2f);
        isActivating = false;
    }
}
