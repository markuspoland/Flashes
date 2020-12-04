using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    
    public Light directionalLight;
    public List<GameObject> objToHide;

    public CinemachineVirtualCamera playerCam;
    float defaultShakeAmplitude = 0f;

    public Animator playerAnim;
    public PlayerController playerController;

    public ScenePostProcess postProcess;
    public FogHandler fogHandler;

    public AudioClip timeJumpFull;
    public AudioClip timeJumpHalfOne;
    public AudioClip timeJumpHalfTwo;

    AudioSource audioSource;

    bool flashing = false;
    bool shouldFall = true;
    bool hasPlayed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (flashing)
        {
            StartCoroutine(TimeJumpAndFall());
        }

        if (!shouldFall)
        {
            StartCoroutine(TimeJump());
        }
    }

    public void FlashAndFall(float flashingTime, float regainMovementTime)
    {
        StartCoroutine(WaitForFlash());
        flashing = true;
        StartCoroutine(DisableFlashing(flashingTime));
        RegainMovement(regainMovementTime);
    }

    public void Flash(float flashingTime)
    {
        shouldFall = false;
        StartCoroutine(DisableFlashing(flashingTime));
    }

    IEnumerator WaitForFlash(float waitForFlash = 1f)
    {
        playerController.ShowActionCamera();
        playerController.IsImmobilized = true;
        yield return new WaitForSeconds(waitForFlash);
        playerAnim.SetTrigger("blinded");
    }

    IEnumerator DisableFlashing(float time = 1f)
    {
        yield return new WaitForSeconds(time);
        flashing = false;
    }

    IEnumerator TimeJumpAndFall()
    {
        playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2f;

        yield return new WaitForSeconds(0.5f);

        if (!hasPlayed)
        {
            PlayTimeJumpFull();
            hasPlayed = true;
        }
        

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

    private void RegainMovement(float duration)
    {
        playerController.ShowDefaultCamera(duration, () => { playerController.IsImmobilized = false; });
    }

    public void PlayTimeJumpFull()
    {
        audioSource.PlayOneShot(timeJumpFull);
    }

    public void PlayTimeJumpHalfOne()
    {
        audioSource.PlayOneShot(timeJumpHalfOne);
    }

    public void PlayTimeJumpHalfTwo()
    {
        audioSource.PlayOneShot(timeJumpHalfTwo);
    }
}