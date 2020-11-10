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
    public List<GameObject> objToHide;
    float defaultIntensity;
    

    public CinemachineVirtualCamera playerCam;
    float defaultShakeAmplitude = 0f;

    public Animator playerAnim;
    public PlayerController playerController;

    public ScenePostProcess postProcess;
    public FogHandler fogHandler;

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
        StartCoroutine(TimeJump());
    }

    IEnumerator TimeJumpAndFall(float waitForFlash = 1f)
    {
        playerController.ShowActionCamera();
        playerController.IsImmobilized = true;
        yield return new WaitForSeconds(waitForFlash);
        playerAnim.SetTrigger("blinded");
        playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2f;

        yield return new WaitForSeconds(0.5f);

        postProcess.FadeIn();

        yield return new WaitForSeconds(1f);
        
        foreach(var obj in objToHide)
        {
            obj.SetActive(false);
        }

        playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = defaultShakeAmplitude;
        fogHandler.ResetFog();
        postProcess.FadeOut();
   
              

    }

    IEnumerator TimeJump()
    {
        playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1f;

        yield return new WaitForSeconds(1f);

        postProcess.FadeIn();
        yield return new WaitForSeconds(1f);
        postProcess.FadeOut();

        playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = defaultShakeAmplitude;
    }
    private void RegainMovement()
    {
        //callback action is called from player controller see https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions
        playerController.ShowDefaultCamera(5.7f, () => { playerController.IsImmobilized = false; });
    }
}