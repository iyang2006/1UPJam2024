using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class ZJump : MonoBehaviour
{

    [SerializeField] private bool startNear = false;
    [SerializeField] private float alphaHigh = 1.0f;
    [SerializeField] private float alphaLow = 0.3f;
    [SerializeField] private float alphaFadeTime = 0.3f;
    [SerializeField] private float alphaFadeTickRate = 0.025f;
    [SerializeField] private Color interruptingObjectColor;
    [SerializeField] private float interruptingObjectFadeTime = 0.5f;
    private Transform player;
    private bool isNear;
    private bool canZJump = false;
    public List<GameObject> interruptingObjects;
    public bool jumpInterrupted = false;
    private List<GameObject> stashedInterruptingObjects;

    public List<SpriteRenderer> farRenderers;
    public List<SpriteRenderer> nearRenderers;
    public UnityEngine.Object[] allRenderers;


    [SerializeField] private bool zJumpDEV = false;



    // Start is called before the first frame update
    void Start()
    {
        allRenderers = FindObjectsOfType(typeof(SpriteRenderer));
        foreach (SpriteRenderer renderer in allRenderers)
        {
            if (renderer.gameObject.tag == "Player" || renderer.gameObject.tag == "StaticSprite") continue;

            if (renderer.gameObject.transform.localToWorldMatrix.GetPosition().z > -5f &&
                renderer.gameObject.transform.localToWorldMatrix.GetPosition().z < 5f)
            {
                farRenderers.Add(renderer);
                continue;
            }
            if (renderer.gameObject.transform.localToWorldMatrix.GetPosition().z > -15f &&
                renderer.gameObject.transform.localToWorldMatrix.GetPosition().z < -5f)
            {
                nearRenderers.Add(renderer);
            }
        }
        isNear = startNear;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        setSpriteAlphas(1f);
        interruptingObjects = new List<GameObject>();
        canZJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            zJump();
        }

        if (zJumpDEV)
        {
            zJumpDEV = false;
            zJump();
        }
    }

    public void SetNear() {
        if (!isNear) {
            this.zJump();
        }
    }

    public void SetFar() {
        if (isNear) {
            this.zJump();
        }
    }

    public bool IsNear() {
        return isNear;
    }

    public void zJump()
    {
        if (!canZJump) return;

        if (jumpInterrupted)
        {
            StartCoroutine(fadeInterruptingSpriteColors());
            return;
        }

        if (isNear)
        {
            //JumpFar
            isNear = false;
            player.position = player.position + new Vector3(0f, 0f, 10f);
        } else
        {
            //JumpNear
            isNear = true;
            player.position = player.position + new Vector3(0f, 0f, -10f);
        }
        StartCoroutine(fadeSpriteAlphas());
    }



    public void setSpriteAlphas(float fadePercentage)
    {
        float highFadeAmount = alphaLow + ((alphaHigh - alphaLow) * fadePercentage);
        float lowFadeAmount = alphaHigh - ((alphaHigh - alphaLow) * fadePercentage);
        foreach (SpriteRenderer renderer in nearRenderers)
        {
            if (renderer == null) continue;
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, ((isNear) ? highFadeAmount : lowFadeAmount));
        }
        foreach (SpriteRenderer renderer in farRenderers)
        {
            if (renderer == null) continue;
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, ((!isNear) ? highFadeAmount : lowFadeAmount));
        }
    }



    private IEnumerator fadeSpriteAlphas()
    {
        canZJump = false;
        for (int i = 1; i <= alphaFadeTime / alphaFadeTickRate; i++)
        {
            setSpriteAlphas((alphaFadeTickRate / alphaFadeTime) * i);
            yield return new WaitForSeconds(alphaFadeTickRate);
        }
        canZJump = true;
    }





    private void setInterruptingSpriteColors(float fadePercentage)
    {
        float redFadeAmount = 1f - ((1f - interruptingObjectColor.r) * fadePercentage);
        float greenFadeAmount = 1f - ((1f - interruptingObjectColor.g) * fadePercentage);
        float blueFadeAmount = 1f - ((1f - interruptingObjectColor.b) * fadePercentage);
        foreach (GameObject interruptingObject in stashedInterruptingObjects)
        {
            SpriteRenderer renderer = interruptingObject.GetComponent<SpriteRenderer>();
            if (renderer == null) continue;
            renderer.color = new Color(redFadeAmount, greenFadeAmount, blueFadeAmount, renderer.color.a);
        }
    }



    private IEnumerator fadeInterruptingSpriteColors()
    {
        canZJump = false;
        stashedInterruptingObjects = new List<GameObject>();
        foreach(GameObject interruptingObject in interruptingObjects)
        {
            stashedInterruptingObjects.Add(interruptingObject);
        }
        for (int i = 0; i <= interruptingObjectFadeTime / alphaFadeTickRate; i++)
        {
            setInterruptingSpriteColors(1f - ((alphaFadeTickRate / interruptingObjectFadeTime) * i));
            yield return new WaitForSeconds(alphaFadeTickRate);
        }
        setInterruptingSpriteColors(0f);
        canZJump = true;
    }
}
