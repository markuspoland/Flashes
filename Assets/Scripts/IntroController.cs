using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;

public class IntroController : MonoBehaviour
{
    public ScenePostProcess postProcess;
    VolumeProfile level1VolumeProfile;
    ColorAdjustments cAjd;

    AudioSource audioSource;
    public AudioClip audioClip;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        level1VolumeProfile = GetComponent<Volume>()?.profile;
        if (!level1VolumeProfile.TryGet(out cAjd))
        {
            Debug.Log("Could not get level 1 volume profile!");
        }

        cAjd.postExposure.value = 10f;
        postProcess.SetExposureToZero();
    }
    void Update()
    {
        if (postProcess.IsFaded())
        {
            SceneManager.LoadScene(1);
        }
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(audioClip);
    }

    
}
