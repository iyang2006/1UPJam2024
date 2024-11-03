using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    private itemName activeItem = itemName.NULL;
    [SerializeField] private GameObject rocketItem;
    [SerializeField] private SpriteRenderer rocketSprite;
    [SerializeField] private GameObject brickItem;
    [SerializeField] private SpriteRenderer brickSprite;

    // Start is called before the first frame update
    void Start()
    {
        updateItemSprites();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Q)) {
            dropItem();
        }*/
    }

    public void startHoldingItem(itemName item)
    {
        dropItem();
        activeItem = item;
        updateItemSprites();
        //rocketSprite.enabled = (activeItem == itemName.ROCKET);
        //brickSprite.enabled = (activeItem == itemName.BRICK);
    }

    public void  dropItem()
    {
        switch (activeItem)
        {
            case itemName.NULL:
                break;
            case itemName.ROCKET:
                Instantiate(rocketItem, gameObject.transform.position, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case itemName.BRICK:
                Instantiate(brickItem, gameObject.transform.position, new Quaternion(0f, 0f, 0f, 0f));
                break;
        }
        activeItem = itemName.NULL;
        updateItemSprites();
    }

    private void updateItemSprites()
    {
        rocketSprite.enabled = (activeItem == itemName.ROCKET);
        brickSprite.enabled = (activeItem == itemName.BRICK);
    }
}


public enum itemName
{
    NULL,
    ROCKET,
    BRICK,
}
