using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField]
    private ItemSlot[] items;

    public Item usedItem;


    
    public bool HasItem(Item item)
    {
        foreach(ItemSlot slot in items)
        {
            if (slot.item == item)
                return true;
        }
        return false;
    }

    public int GetItemCount(Item item) 
    {
        foreach(ItemSlot slot in items)
        {
            if(slot.item == item)
                return slot.count;
        }
        return 0;
    }



}

