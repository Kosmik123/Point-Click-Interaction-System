using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PointAndClick
{
    // system using inventory, variables and flags as conditions
    [RequireComponent(typeof(InteractiveObject))]
    public sealed class UniversalInteraction : InteractionBase
    {
        public Condition[] conditions = new Condition[0];
        public InteractionOption[] actions = new InteractionOption[0];
        private bool isBusy;


        public override InteractionOption[] GetActions()
        {
            return actions;
        }


        public override bool IsConditionFulfilled()
        {
            foreach (var condition in conditions)
            {
                if (!condition.IsFulfilled())
                    return false;
            }
            return true;
        }



        private void OnValidate()
        {
            foreach (var condition in conditions)
                if (condition.HasTypeChanged())
                    condition.ChangeRequirement();
        }
    }
}
