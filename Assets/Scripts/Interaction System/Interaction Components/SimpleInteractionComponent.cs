
// only needs specific items to be in inventory to fulfill the condition
public abstract class SimpleInteractionComponent : InteractionComponentBase
{
    
    public ItemSlot[] neededItems;

    public override bool IsConditionFulfilled()
    {
        foreach(var condition in neededItems)
        {
            if(Inventory.instance.GetItemCount(condition.item) < condition.count)
                return false;
        }
        return true;
    }
}

