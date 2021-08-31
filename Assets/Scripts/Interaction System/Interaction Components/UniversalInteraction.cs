using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PointAndClick
{
    // system using inventory, variables and flags as conditions
    [RequireComponent(typeof(InteractiveObject))]
    public sealed class UniversalInteraction : InteractionBase
    {
        public Condition[] conditions;
        public InteractionOption[] actions;
        private bool isBusy;

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
            if (isBusy)
                return;

            if (actions.Length < 1)
                NoActionException();

            if (actions.Length == 1)
            {
                actions[0].Do();
            }
            else
            {
                OptionProperties[] options = GetOptions();
                ChoiceContextMenuInstanceState choiceInstance = GetNewContextMenuState(options);
                isBusy = true;
                StartCoroutine(WaitForOptionChoiceCo(choiceInstance));
            }
        }

        private IEnumerator WaitForOptionChoiceCo(ChoiceContextMenuInstanceState contextMenuInstance)
        {
            yield return new WaitUntil(() => contextMenuInstance.IsChosen);

            foreach(var action in actions)
            { 
                if (action.contextMenuProperties == contextMenuInstance.Option)
                {
                    action.Do();
                    isBusy = false;
                    break; 
                }
            } 
        }

        private OptionProperties[] GetOptions()
        {
            OptionProperties[] options = new OptionProperties[actions.Length];
            for (int i = 0; i < actions.Length; i++)
                options[i] = actions[i].contextMenuProperties;

            return options;
        }

        private ChoiceContextMenuInstanceState GetNewContextMenuState(OptionProperties[] options)
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
