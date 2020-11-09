using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public CinemachineVirtualCamera sourceCam;
    public CinemachineVirtualCamera targetCam;

    private int sourceCamPriority;

    private void Start()
    {
        sourceCamPriority = sourceCam.Priority;
    }

    public void ActivateSourceCamera()
    {
        targetCam.Priority = sourceCamPriority - 1;
    }

    public void ActivateTargetCamera()
    {
        targetCam.Priority = sourceCamPriority + 1;
    }
}
