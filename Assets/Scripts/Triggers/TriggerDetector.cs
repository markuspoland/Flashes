using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public List<Collider> weaponColiders;
    
    void OnTriggerEnter(Collider other)
    {
        CheckCollidingWeapons(other);
    }

    void OnTriggerExit(Collider other)
    {
        CheckExitingWeapons(other);
    }

    public Weapon GetTouchingWeapon()
    {
        foreach (Collider weaponColider in weaponColiders)
        {
            return weaponColider.transform.root.gameObject.GetComponent<Weapon>();
        }

        return null;
    }

    private void CheckCollidingWeapons(Collider other)
    {
        if (other.transform.root.gameObject.GetComponent<Weapon>() == null)
        {
            return;
        }

        if (!weaponColiders.Contains(other))
        {
            weaponColiders.Add(other);
        }
    }

    private void CheckExitingWeapons(Collider other)
    {
        if (other.transform.root.gameObject.GetComponent<Weapon>() == null)
        {
            return;
        }

        if (weaponColiders.Contains(other))
        {
            weaponColiders.Remove(other);
        }
    }
}
