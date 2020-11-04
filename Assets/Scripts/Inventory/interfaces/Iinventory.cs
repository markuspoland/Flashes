
public interface IInventory
{
    void AddItem(IPickable item, Inventory.ItemType itemType);
    void RemoveItem(IPickable item, Inventory.ItemType itemType);
    bool HasItem(IPickable item, Inventory.ItemType itemType);
}
