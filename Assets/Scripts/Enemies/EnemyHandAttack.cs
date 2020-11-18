using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandAttack : MonoBehaviour
{
    public PlayerController playerController;
    public CameraHandler cameraHandler;
    public float onHitDamage = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerGotHit();
        }
    }

    private void PlayerGotHit()
    {
        if (playerController.IsKilled) return;
        playerController.ShowActionCamera();
        playerController.animator.SetTrigger("hit1");
        playerController.playerHealth.TakeDamage(onHitDamage);
        if (!playerController.IsKilled) playerController.ShowDefaultCamera(1f);
    }
}
