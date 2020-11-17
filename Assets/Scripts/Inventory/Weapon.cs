using System.Collections;
using UnityEngine;
using System.Linq;

public class Weapon : MonoBehaviour, IPickable
{
    public float hitRadius = 0.5f;

    PlayerController playerController;
    PlayerCombat playerCombat;
    IInventory inventory;
    bool hitEnabled = false;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        inventory = FindObjectOfType<Inventory>();
    }

    void FixedUpdate()
    {
        TriggerHitColliders(transform.position, hitRadius);
    }

    public enum Type
    {
        MELEE,
        RANGED
    }

    public Vector3 InHandPosition = new Vector3();
    public Vector3 InHandRotation = new Vector3();

    public Type WeaponType = Type.MELEE;

    public void PickUp()
    {
        inventory.AddItem(this, Inventory.ItemType.WEAPON);
        GrabWeapon();
    }

    private void GrabWeapon()
    {
        playerController.ShowActionCamera();
        TriggerAction("grabFromFloor");
        TriggerAction("equippedAxe");
        StartCoroutine(GrabWeaponFromFloor());
        playerController.ShowDefaultCamera(2.1f);
        playerCombat.EquippedWeapon = this;
    }

    private void EquipWeapon()
    {
        transform.parent = playerController.rightHand.transform;
        transform.localPosition = InHandPosition;
        transform.localRotation = Quaternion.Euler(InHandRotation);
    }

    IEnumerator GrabWeaponFromFloor()
    {
        yield return new WaitForSeconds(1f);
        EquipWeapon();
    }

    private void TriggerAction(string action)
    {
        playerController.animator.SetTrigger(action);
    }

    public void ActivateHitCollider()
    {
        hitEnabled = true;
    }

    void TriggerHitColliders(Vector3 center, float radius)
    {
        if (!hitEnabled) return;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            EnemyAI enemy = hitCollider.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.GetHit();
            }
            hitEnabled = false;
        }
    }
}