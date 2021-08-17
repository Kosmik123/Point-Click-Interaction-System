using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PointAndClick
{
    // system using inventory, variables and flags as conditions
    [RequireComponent(typeof(InteractiveObject))]
    public class UniversalInteraction : InteractionBase
    {
        public Condition[] conditions;
        public InteractionOption[] actions;

        public override bool IsConditionFulfilled()
        {
            foreach (var condition in conditions)
            {
                if (!condition.IsFulfilled())
                    return false;
            }
            return true;
        }

        public override void Perform()
        {
            if (actions.Length < 1)
                throw (new System.Exception("Error: No action assigned!"));

            if (actions.Length == 1)
            {
                actions[0].Do();
            }
            else
            {
                ContextMenuOptionProperties[] options = GetOptions();
                ChoiceContextMenuInstanceState choiceInstance = GetNewContextMenuState(options);
                StartCoroutine(WaitForOptionChoiceCo(choiceInstance));
            }
        }

        private IEnumerator WaitForOptionChoiceCo(ChoiceContextMenuInstanceState contextMenuInstance)
        {
            yield return new WaitUntil(() => contextMenuInstance.IsChosen);

            foreach(var action in actions)
            { 
                if (action.optionProperties == contextMenuInstance.Option)
                {
                    action.Do();
                    break; 
                }
            } 
        }

        private ContextMenuOptionProperties[] GetOptions()
        {
            ContextMenuOptionProperties[] options = new ContextMenuOptionProperties[actions.Length];
            for (int i = 0; i < actions.Length; i++)
                options[i] = actions[i].optionProperties;

            return options;
        }

        private ChoiceContextMenuInstanceState GetNewContextMenuState(ContextMenuOptionProperties[] options)
        {
            ChoiceContextMenuInstanceState choiceInstance =
                UIController.Instance.CreateContextMenu(options);

            return choiceInstance;
        }

        private void OnValidate()
        {
            foreach (var condition in conditions)
                if (condition.HasTypeChanged())
                    condition.ChangeRequirement();
        }


    }
}