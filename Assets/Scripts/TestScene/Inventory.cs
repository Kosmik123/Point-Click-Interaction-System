using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, PointAndClick.IInventory
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

    public void GiveItem(Item item)
    {
        foreach (ItemSlot slot in items)
        {    
            if (slot.item == item)
            {
                slot.count++;
                return;
            }
        }
        items.Add(new ItemSlot(item));
    }

    public void RemoveItem(Item item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            ItemSlot slot = items[i];
            if (slot.item == item)
            {
                if (slot.count > 0)
                    slot.count--;
                else
                    items.RemoveAt(i);
                return;
            }
        }
    }

}
