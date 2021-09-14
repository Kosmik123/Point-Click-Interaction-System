using UnityEngine;

namespace PointAndClick
{
    public class SavableInteraction : InteractionBase
    {


        public class InteractionSO : ScriptableObject
        {

        }

        public override bool IsConditionFulfilled()
        {
            throw new System.NotImplementedException();
        }


        public override InteractionOption[] GetActions()
        {
            InteractionOption[] actions = new InteractionOption[0];
            return actions;
        }
    }
}