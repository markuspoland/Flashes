using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CinemachineVirtualCamera playerCam;
    public CinemachineVirtualCamera actionCam;
    public Transform rightHand;
    
    public bool IsKilled = false;
    public bool IsResurrecting = false;
    public bool IsImmobilized = false;

    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public TriggerDetector triggerDetector;

    void Start()
    {
        animator = GetComponent<Animator>();
        triggerDetector = GetComponent<TriggerDetector>();
    }
    public bool ControlsLock()
    {
        return IsKilled || IsResurrecting || IsImmobilized;
    }

    public void ShowActionCamera()
    {
        actionCam.Priority = 11;
    }

    public void ShowDefaultCamera()
    {
        actionCam.Priority = 9;
    }

    //Action (callback) is a method passed via parameter. So we can invoke it after everythng is done (see ShowDefaultCameraCoroutine)
    public void ShowDefaultCamera(float duration, Action callback = null) => StartCoroutine(ShowDefaultCameraCoroutine(duration, callback));

    private IEnumerator ShowDefaultCameraCoroutine(float duration, Action callback)
    {
        yield return new WaitForSeconds(duration);
        ShowDefaultCamera();
        //everything is complete so we can invoke callback here
        //we also have to check if it is null. Using questionmark is equivalent of using callback == null
        callback?.Invoke();
    }
}
