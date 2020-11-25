using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieRunTrigger : MonoBehaviour
{
    public CameraHandler cameraHandler;
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.IsImmobilized = true;
            cameraHandler.ActivateTargetCamera();
            StartCoroutine(ResetCamera());
        }
    }

    private IEnumerator ResetCamera()
    {
        yield return new WaitForSeconds(3f);
        cameraHandler.ActivateSourceCamera();
        yield return new WaitForSeconds(2.3f);
        playerController.IsImmobilized = false;
        Destroy(this);
    }
}
