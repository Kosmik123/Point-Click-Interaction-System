using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// system using inventory, variables and flags as conditions
[RequireComponent(typeof(InteractiveObject))]
public class InteractionComponent : InteractionComponentBase
{
    public Condition[] conditions;
    public InteractionOption[] actions;

    public override bool IsConditionFulfilled()
    {
        foreach(var condition in conditions)
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
            ChoiceContextMenuInstanceState choiceInstance = GetOptionFromContextMenu(options);
            StartCoroutine(WaitForOptionChoiceCo(choiceInstance));
        }
    }

    private IEnumerator WaitForOptionChoiceCo(ChoiceContextMenuInstanceState contextMenuInstance)
    {
        yield return new WaitUntil(() => contextMenuInstance.IsChosen);
        actions[contextMenuInstance.OptionId].Do();
    }

    private ContextMenuOptionProperties[] GetOptions()
    {
        ContextMenuOptionProperties[] options = new ContextMenuOptionProperties[actions.Length];
        for (int i = 0; i < actions.Length; i++)
            options[i] = actions[i].optionProperties;

        return options;
    }

    private ChoiceContextMenuInstanceState GetOptionFromContextMenu(ContextMenuOptionProperties[] options)
    {
        ChoiceContextMenuInstanceState choiceInstance = new ChoiceContextMenuInstanceState();
        UIController.Instance.CreateContextMenu(options, choiceInstance);

        return choiceInstance;
    }

    private void OnValidate()
    {
        foreach (var condition in conditions)
            if (condition.HasTypeChanged())
                condition.ChangeRequirement();
    }


}
