namespace PointAndClick
{
    public interface IInventory
    {
        bool HasItem(Item item);
        int GetItemCount(Item item);
        Item GetUsedItem();
    }
}
