﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchKey: Key, IPickable
{
    public Hatch hatch;
    IInventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void PickUp()
    {
        inventory.AddItem(this, Inventory.ItemType.KEY);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    override public void UseKey()
    {
        hatch.OpenHatch();
    }
}
