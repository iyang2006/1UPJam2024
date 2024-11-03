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
    [SerializeField] private AudioSource thisAudio;
    [SerializeField] private AudioSource secondAudio;

    
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
            StartCoroutine(Flash(1f, thisAudio));
            yield return new WaitForSeconds(1f);
            if (UnityEngine.Random.Range(0f, 1f) < doubleFlashProp) {
                float scal = UnityEngine.Random.Range(0.5f, 1f);
                StartCoroutine(Flash(scal, secondAudio));
            }
            yield return new WaitForSeconds(1f);
            float randDelay = UnityEngine.Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(randDelay);
        }
    }

    private void SetAudio(AudioSource aud, float qual) {
        aud.volume = Mathf.Lerp(0.2f, 1f, qual);
        float minPitch = 0.7f;
        float maxPitch = 1.2f;
        aud.pitch = Mathf.Lerp(minPitch, maxPitch, qual);
    }

    private IEnumerator Flash(float scal, AudioSource aud) {
        float intensity = UnityEngine.Random.Range(0f, 2f);
        if (intensity > 1f) {
            intensity = 1f;
        }
        float startT = Time.time;
        float curT = 0.01f;
        float bright = Brightness(curT);
        SetAudio(aud, intensity * scal);
        StartCoroutine(PlayAudio(1 - (intensity * scal), aud));
        yield return new WaitForEndOfFrame();
        while (bright >= 0) {
            curT = Time.time - startT;
            bright = Brightness(curT);
            strength = bright * intensity * scal;
            yield return new WaitForEndOfFrame();
        }
        strength = 0;
        yield return null;
    }

    private IEnumerator PlayAudio(float delay, AudioSource aud) {
        yield return new WaitForSeconds(delay);
        aud.Play();
        yield return new WaitForSeconds(1f);
        float starT = Time.time;
        float curT = Time.time;
        float baseVol = aud.volume;
        while (curT - starT < 2f) {
            yield return new WaitForEndOfFrame();
            curT = Time.time;
            aud.volume = Mathf.Lerp(baseVol, 0f, (curT - starT) / 2f);
        }
        yield return null;
    }


}
