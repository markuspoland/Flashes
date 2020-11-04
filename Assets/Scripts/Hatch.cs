using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    public Animator animator;
    public HatchKey item;

    IInventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void OpenHatch()
    {
        if (inventory.HasItem(item, Inventory.ItemType.KEY))
        {
            animator.SetTrigger("openHatch");
            inventory.RemoveItem(item, Inventory.ItemType.KEY);
        }
    }
}
