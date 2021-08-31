using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class InventorySO : ScriptableObject, PointAndClick.IInventory
{
    [SerializeField]
    private List<ItemSlot> items;

    public Item usedItem;

    public bool HasItem(Item item)
    {
        foreach (ItemSlot slot in items)
        {
            if (slot.item == item)
                return true;
        }
        return false;
    }

    public int GetItemCount(Item item)
    {
        foreach (ItemSlot slot in items)
        {
            if (slot.item == item)
                return slot.count;
        }
        return 0;
    }

    public Item GetUsedItem()
    {
        return usedItem;
    }
}
