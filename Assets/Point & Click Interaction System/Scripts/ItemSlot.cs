[System.Serializable]
public class ItemSlot
{
    public Item item;
    public int count = 1;

    public ItemSlot(Item item, int amount)
    {
        this.item = item;
        count = amount;
    }

    public ItemSlot(Item item)
    {
        this.item = item;
    }

    public static bool operator >(ItemSlot first, ItemSlot second)
    {
        if (first.item != second.item)
            return false;

        return first.count > second.count;
    }

    public static bool operator <(ItemSlot first, ItemSlot second)
    {
        if (first.item != second.item)
            return false;

        return first.count < second.count;
    }
}
