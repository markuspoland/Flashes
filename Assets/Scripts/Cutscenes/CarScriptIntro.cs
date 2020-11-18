using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScriptIntro : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

}
