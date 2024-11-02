using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableCtrl : MonoBehaviour
{
    [SerializeField] private Interactable target;
    [SerializeField] private bool isCollectible;
    private bool available;
    // Start is called before the first frame update
    void Start()
    {
        available = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && available) {
            this.InteractBehaviour();
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            available = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            available = false;
        }
    }

    private void InteractBehaviour() {
        target.Interact();
        if (isCollectible) {
            Destroy(this.gameObject);
        }
    }
}
