using UnityEngine;
using UnityEditor;
using System;

namespace PointAndClick
{
    public abstract class Requirement
    {
        public abstract bool IsFulfilled();
    }


    public class HasItemRequirement : Requirement
    {
        public Item item;

        public override bool IsFulfilled()
        {
            return InteractionController.Inventory.HasItem(item);
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
            return InteractionController.Inventory.GetItemCount(itemInInventory) >= minAmount;
        }
    }
}