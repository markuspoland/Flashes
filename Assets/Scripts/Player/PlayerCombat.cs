using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Weapon EquippedWeapon = null;

    public float attackCooldown = 1f;
    public float attackCooldownTimer;
    public float grabCooldown = 1f;

    private PlayerController playerController;

    AudioSource audioSource;
    public AudioClip[] attackSounds;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.ControlsLock()) return;

        AnimateAttack();
    }

    private void AnimateAttack()
    {
        if (EquippedWeapon != null)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (EquippedWeapon.WeaponType == Weapon.Type.MELEE && attackCooldownTimer >= attackCooldown)
                {
                    EquippedWeapon.PlaySwipeAudio();
                    PlayAttackSound();
                    playerController.ShowActionCamera();
                    playerController.animator.SetTrigger("attackAxe");
                    playerController.ShowDefaultCamera(0.9f);
                    attackCooldownTimer = 0f;
                }

                return;
            }
        }

        if (Input.GetMouseButtonDown(0) && attackCooldownTimer >= attackCooldown)
        {
            playerController.ShowActionCamera();
            TriggerAction("attackPunchLeft");
            playerController.ShowDefaultCamera(0.9f);
            attackCooldownTimer = 0f;
        }

        if (Input.GetMouseButtonDown(1) && attackCooldownTimer >= attackCooldown)
        {
            playerController.ShowActionCamera();
            TriggerAction("attackPunchRight");
            playerController.ShowDefaultCamera(0.9f);
            attackCooldownTimer = 0f;
        }

        if (attackCooldownTimer < 1f)
            attackCooldownTimer += 1f * Time.deltaTime;
    }

    private void TriggerAction(string action)
    {
        playerController.animator.SetTrigger(action);
    }

    void PlayAttackSound()
    {
        int randomSound = Random.Range(0, 4);
        audioSource.PlayOneShot(attackSounds[randomSound]);
    }
}
