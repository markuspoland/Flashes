using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public CinemachineVirtualCamera sourceCam;
    public CinemachineVirtualCamera targetCam;
    public CinemachineVirtualCamera endCam;

    int activePriority = 11;
    int notActivePriority = 9;

    public void ActivateSourceCamera()
    {
        sourceCam.Priority = activePriority;
        targetCam.Priority = notActivePriority;
        if (endCam != null)
            endCam.Priority = notActivePriority;

    }

    public void ActivateTargetCamera()
    {
        sourceCam.Priority = notActivePriority;
        targetCam.Priority = activePriority;
        if (endCam != null)
            endCam.Priority = notActivePriority;
    }

    public void ActivateEndCamera()
    {
        if (endCam == null) return;

        sourceCam.Priority = notActivePriority;
        targetCam.Priority = notActivePriority;
        endCam.Priority = activePriority;
    }
}
