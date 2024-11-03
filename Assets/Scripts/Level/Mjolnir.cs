using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Mjolnir : MonoBehaviour
{
    [SerializeField] private Material lightningMat;

    // strength is normalised from 0 to 1
    [SerializeField] [Range(0f, 1f)] private float strength;
    [SerializeField] private float minInterval;
    [SerializeField] private float maxInterval;
    [SerializeField] private float doubleFlashProp;

    
    // Start is called before the first frame update
    void Start()
    {
        strength = 0;
        StartCoroutine(FlashTest());
    }

    // Update is called once per frame
    void Update()
    {
        lightningMat.SetFloat("_LightLerp", strength);
    }

    private float Brightness(float q) {
        float t = q + 0.01f;
        float val = (-8 / Mathf.Exp(8 * t)) * (Mathf.Pow(t, 2) - (3*t)) - 0.01f;
        return val;
    }

    private IEnumerator FlashTest() {
        while (true) {
            StartCoroutine(Flash(1f));
            yield return new WaitForSeconds(1f);
            if (UnityEngine.Random.Range(0f, 1f) < doubleFlashProp) {
                float scal = UnityEngine.Random.Range(0.5f, 1f);
                StartCoroutine(Flash(scal));
            }
            yield return new WaitForSeconds(1f);
            float randDelay = UnityEngine.Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(randDelay);
        }
    }

    private IEnumerator Flash(float scal) {
        float intensity = UnityEngine.Random.Range(0f, 2f);
        if (intensity > 1f) {
            intensity = 1f;
        }
        float startT = Time.time;
        float curT = 0.01f;
        float bright = Brightness(curT);
        yield return new WaitForEndOfFrame();
        while (bright >= 0) {
            curT = Time.time - startT;
            bright = Brightness(curT);
            Debug.Log(bright);
            strength = bright * intensity * scal;
            yield return new WaitForEndOfFrame();
        }
        strength = 0;
        yield return null;
    }


}
