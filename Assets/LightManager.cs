using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class LightManager : MonoBehaviour
{
    HDAdditionalLightData lightData;
        
    void Start()
    {
        lightData = GetComponent<HDAdditionalLightData>();
    }

    // Update is called once per frame
    void Update()
    {
        SetHallwayIntensity();
    }

    void SetHallwayIntensity()
    {
        lightData.SetIntensity(35f);
    }
}
