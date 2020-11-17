using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandAttack : MonoBehaviour
{

    public PlayerController playerController;
    public CameraHandler cameraHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlayerGotHit());
        }
    }

    private IEnumerator PlayerGotHit()
    {
        cameraHandler.ActivateTargetCamera();
        playerController.animator.SetTrigger("hit1");
        yield return new WaitForSeconds(1f);
        cameraHandler.ActivateSourceCamera();
    }
}
