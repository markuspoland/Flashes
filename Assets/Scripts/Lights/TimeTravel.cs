using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//using UnityEngine.Experimental.GlobalIllumination;

public class TimeTravel : MonoBehaviour
{
    
    public Light directionalLight;
    public float flashTime;
    public float targetIntensity;
    float defaultIntensity;

    public CinemachineVirtualCamera playerCam;
    float defaultShakeAmplitude = 0f;

    public Animator playerAnim;
    public PlayerController playerController;

    //public ScenePostProcess postProcess;

    void Start()
    {
        defaultIntensity = 0.2f;
    }

    public void FlashAndFall()
    {
        StartCoroutine(TimeJumpAndFall());
        RegainMovement();
    }

    public void Flash()
    {
        //StartCoroutine(TimeJump());
    }

    IEnumerator TimeJumpAndFall()
    {
        playerController.ShowActionCamera();
        playerController.IsImmobilized = true;
        playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2f;

        yield return new WaitForSeconds(1f);
        
        if (directionalLight.intensity < targetIntensity)
        {
            directionalLight.intensity += flashTime * Time.deltaTime;
        }
     

        if (directionalLight.intensity >= targetIntensity)
        {
            yield return new WaitForSeconds(0.1f);
            playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = defaultShakeAmplitude;
            targetIntensity = defaultIntensity;
            directionalLight.intensity -= flashTime * Time.deltaTime;
            
        }

        if (directionalLight.intensity < defaultIntensity)
        {
            directionalLight.intensity = defaultIntensity;
        }
       

    }

    //IEnumerator TimeJump()
    //{
        //playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1f;

        //yield return new WaitForSeconds(1f);

        //postProcess.FadeIn();
        //yield return new WaitForSeconds(1f);
        //postProcess.FadeOut();

        //playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = defaultShakeAmplitude;
    //}
    private void RegainMovement()
    {
        //callback action is called from player controller see https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions
        playerController.ShowDefaultCamera(4.7f, () => { playerController.IsImmobilized = false; });
    }
}