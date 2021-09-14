using UnityEngine;
using UnityEditor;
using System;

namespace PointAndClick
{
    public abstract class Requirement : ScriptableObject
    {
        public const string folderName = "Requirement Assets";
        public abstract bool IsFulfilled();
    }

    [CreateAssetMenu(menuName = folderName + "/Has Item")]
    public class HasItemRequirement : Requirement
    {
        public Item item;

        public override bool IsFulfilled()
        {
            return InteractionController.Inventory.HasItem(item);
        }

        private void OnValidate()
        {
            name = "Has item " + item?.name;
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), name);
        }
    }

    [CreateAssetMenu(menuName = folderName + "/Item Used")]
    public class UsedItemRequirement : Requirement
    {
        public Item itemUsed;

        public override bool IsFulfilled()
        {
            return InteractionController.Inventory.GetUsedItem() == itemUsed;
        }

        private void OnValidate()
        {
            name = "Used item " + itemUsed?.name;
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), name);
        }
    }

    [CreateAssetMenu(menuName = folderName + "/Item Amount")]
    public class ItemAmountRequirement : Requirement
    {
        public Item item;
        public int minAmount;

        public override bool IsFulfilled()
        {
            return InteractionController.Inventory.GetItemCount(item) >= minAmount;
        }

        private void OnValidate()
        {
            name = "Has " + minAmount + " " + item?.name + "'s";
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), name);
        }
    }

    [CreateAssetMenu(menuName = folderName + "/Flag State")]
    public class FlagRequirement : Requirement
    {
        public int flagId;
        public bool state;

        public override bool IsFulfilled()
        {
            return InteractionController.Instance.GetFlag(flagId) == state;
        }

        private void OnValidate()
        {
            name = "Flag " + flagId + " is set as " + state; 
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), name);
        }
    }

    [CreateAssetMenu(menuName = folderName + "/Compare Variable with Value")]
    public class VariableValueRequirement : Requirement 
    {
        public int variableId;
        public VariableSetting.CompareType compare;
        public int value;

        public override bool IsFulfilled()
        {
            return InteractionController.Instance.CompareVariableWithValue(variableId, compare, value);
        }

        private void OnValidate()
        {
            name = "Variable " + variableId + " is " + compare + " " + value;
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), name);
        }
    }

    [CreateAssetMenu(menuName = folderName + "/Compare Variables")]
    public class VariablesCompareRequirement : Requirement
    {
        public int variable1;
        public VariableSetting.CompareType compare;
        public int variable2;

        public override bool IsFulfilled()
        {
            return InteractionController.Instance.CompareVariables(variable1, compare, variable2);
        }

        private void OnValidate()
        {
            name = "Variable " + variable1 + " is " + compare + " variable " + variable2;
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), name);
        }
    }
}