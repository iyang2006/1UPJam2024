using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAnimation : MonoBehaviour
{

    private Vector3 basePosition;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position += new Vector3(-5f, 0f, 0f);
        basePosition = gameObject.transform.position;
        StartCoroutine(rainLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator rainLoop()
    {
        while(true)
        {
            Vector3 currentPosition = gameObject.transform.position;
            gameObject.transform.position += new Vector3(((currentPosition.x == basePosition.x + 5f) ? -10f : 5f), 0f, 0f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
