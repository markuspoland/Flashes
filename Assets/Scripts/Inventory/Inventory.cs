using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory
{

    public enum ItemType
    {
        WEAPON,
        KEY,
        TRASH
    }

    public Dictionary<ItemType, List<IPickable>> items = new Dictionary<ItemType, List<IPickable>>();

    void Start()
    {
        items.Add(ItemType.WEAPON, new List<IPickable>());
        items.Add(ItemType.KEY, new List<IPickable>());
        items.Add(ItemType.TRASH, new List<IPickable>());
    }

    public void AddItem(IPickable item, ItemType itemType)
    {
        if (!items[itemType].Contains(item))
        {
            items[itemType].Add(item);
        }
    }

    public void RemoveItem(IPickable item, ItemType itemType)
    {
        if (items[itemType].Contains(item))
        {
            items[itemType].Remove(item);
        }
    }

    public bool HasItem(IPickable item, ItemType itemType) => items[itemType].Contains(item);
}
