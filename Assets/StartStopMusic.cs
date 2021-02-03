using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopMusic : MonoBehaviour
{
    public AudioSource sourceToStop;
    public float fadeTime = 0.2f;
    public bool destroy = false;
    bool playerEntered = false;

    void Update()
    {
        if (playerEntered)
        {
            if (destroy && !sourceToStop.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Playaaaaaaaaa");
            playerEntered = true;

            if (sourceToStop.isPlaying)
            {
                StartCoroutine(AudioFadeScript.FadeOut(sourceToStop, fadeTime));
            }
            else
            {
                StartCoroutine(AudioFadeScript.FadeIn(sourceToStop, fadeTime));
            }

        }
    }
}

