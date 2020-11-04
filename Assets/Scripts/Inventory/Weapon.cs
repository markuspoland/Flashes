using UnityEngine;

public class Weapon : MonoBehaviour, IPickable
{
    PlayerController playerController;
    IInventory inventory;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        inventory = FindObjectOfType<Inventory>();
    }

    public enum Type
    {
        MELEE,
        RANGED
    }

    public Vector3 CustomPosition = new Vector3();
    public Vector3 CustomRotation = new Vector3();

    public Type WeaponType = Type.MELEE;

    public void PickUp()
    {
        inventory.AddItem(this, Inventory.ItemType.WEAPON);
    }

    public void GrabWeapon()
    {
        transform.parent = playerController.rightHand.transform;
        transform.localPosition = CustomPosition;
        transform.localRotation = Quaternion.Euler(CustomRotation);
    }
}