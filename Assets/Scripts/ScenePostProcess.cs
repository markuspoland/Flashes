using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class ScenePostProcess : MonoBehaviour
{
    ColorAdjustments colorAdjustments;
    VolumeProfile volumeProfile;
    float defaultExposure = 0f;
    public float targetExposure = 10f;
    float exposureSpeed = 3f;
        
    void Awake()
    {
        //colorAdjustments = GetComponent<ColorAdjustments>();
        volumeProfile = GetComponent<Cinemachine.PostFX.CinemachineVolumeSettings>()?.m_Profile;

        if (!volumeProfile.TryGet(out colorAdjustments))
        {
            Debug.Log("Could not get COLOR ADJUSTMENTS");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Blind();
    }

    public void FadeIn()
    {
        if (colorAdjustments.postExposure.value < targetExposure)
        {
            colorAdjustments.postExposure.value += 5f * Time.deltaTime;
        }
    }

    public void FadeOut()
    {
        if (colorAdjustments.postExposure.value >= targetExposure)
        {
            targetExposure = defaultExposure;
            colorAdjustments.postExposure.value -= 5f * Time.deltaTime;
        }

        if (colorAdjustments.postExposure.value < defaultExposure)
        {
            colorAdjustments.postExposure.value = defaultExposure;
        }
    }

    public bool IsFaded()
    {
        if (colorAdjustments.postExposure.value > 9.5f)
        {
            return true;
        }

        return false;
    }

    public void SetExposureToZero()
    {
        colorAdjustments.postExposure.value = 0f;
    }

    public void SetExposureToTarget()
    {
        colorAdjustments.postExposure.value = targetExposure;
    }
}
