using UnityEngine;
using UnityEditor;

public abstract class Requirement 
{
    public abstract bool IsFulfilled();
}


public class HasItemRequirement : Requirement
{
    public Item itemInInventory;

    public override bool IsFulfilled()
    {
        return Inventory.instance.HasItem(itemInInventory);
    }
}

public class UsedItemRequirement : Requirement
{
    public Item itemUsed;

    public override bool IsFulfilled()
    {
        return true;
    }
}


public class ItemAmountRequirement : Requirement
{
    public Item itemInInventory;
    public int minAmount;

    public override bool IsFulfilled()
    {
        return Inventory.instance.GetItemCount(itemInInventory) >= minAmount;
    }
}