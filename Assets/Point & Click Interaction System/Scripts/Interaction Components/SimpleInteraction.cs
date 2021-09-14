namespace PointAndClick
{
    // only needs specific items in inventory to fulfill the condition
    public class SimpleInteraction : InteractionBase
    {
        public ItemSlot[] neededItems;
        public InteractionOption[] actions;

        public override InteractionOption[] GetActions()
        {
            return actions;
        }

        public override bool IsConditionFulfilled()
        {
            foreach (var condition in neededItems)
            {
                if (InteractionController.Inventory.GetItemCount(condition.item) < condition.count)
                    return false;
            }
            return true;
        }

    }
}
