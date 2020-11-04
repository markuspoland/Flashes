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

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.ControlsLock()) return;

        AnimateAttack();
        GrabWeapon();
    }

    private void AnimateAttack()
    {
        if (EquippedWeapon != null)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (EquippedWeapon.WeaponType == Weapon.Type.MELEE && attackCooldownTimer >= attackCooldown)
                {
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

    private void GrabWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Weapon weapon = playerController.triggerDetector.GetTouchingWeapon();
            if (weapon == null) return;

            weapon.GetComponent<InteractibleObject>().interactionEnabled = false;
            playerController.ShowActionCamera();
            TriggerAction("grabFromFloor");
            TriggerAction("equippedAxe");
            StartCoroutine(GrabWeaponFromFloor(weapon));
            playerController.ShowDefaultCamera(2.1f);
            EquippedWeapon = weapon;
        }
    }

    IEnumerator GrabWeaponFromFloor(Weapon weapon)
    {
        yield return new WaitForSeconds(1f);
        weapon.PickUp();
        weapon.GrabWeapon();
    }

    private void TriggerAction(string action)
    {
        playerController.animator.SetTrigger(action);
    }
}
