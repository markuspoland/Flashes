using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerCombat playerCombat;
    Weapon playerWeapon;

    void Start()
    {
        playerCombat = FindObjectOfType<PlayerCombat>();
    }

    public void EnableWeaponAttack()
    {
        playerWeapon = playerCombat.EquippedWeapon;
        playerWeapon.ActivateHitCollider();
    }

    public void DisableWeaponAttack()
    {
        playerWeapon.ActivateHitCollider();
    }
}
