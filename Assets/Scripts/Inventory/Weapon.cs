using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour, IPickable
{
    PlayerController playerController;
    PlayerCombat playerCombat;
    IInventory inventory;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        inventory = FindObjectOfType<Inventory>();
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
}