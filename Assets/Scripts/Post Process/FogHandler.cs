using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class FogHandler : MonoBehaviour
{
    VolumeProfile fogVolumeProfile;
    Fog fog;
    float defaultFogVolume = 11.9f;
    public float targetFogVolume;

    // Start is called before the first frame update
    void Start()
    {
        fogVolumeProfile = GetComponent<Volume>()?.profile;

        if (!fogVolumeProfile.TryGet(out fog))
        {
            Debug.Log("Could not get FOG");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FogVolumeUp()
    {
        if (fog.meanFreePath.value > targetFogVolume)
        {
            fog.meanFreePath.value -= 6f * Time.deltaTime;
        }
        
    }

    public void ResetFog()
    {
        fog.meanFreePath.value = defaultFogVolume;
    }
}

    
