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
        playerController.ShowActionCamera();
        playerController.animator.SetTrigger("hit1");
        
        playerController.ShowDefaultCamera(1f);
        yield return null;
    }
}
