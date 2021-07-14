using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionComponent : MonoBehaviour
{
    public Condition[] conditions;

    public InteractionOption[] actions;

    
    public bool IsConditionFulfilled()
    {
        foreach(var cond in conditions)
        {
            if (!cond.IsFulfilled())
                return false;
        }
        return true;
    }

    public void Perform()
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
            ChoiceContextMenuInstanceState choiceInstance = ChooseOption(options);
            StartCoroutine(WaitForOptionChoiceCo(choiceInstance));
        }
    }

    private IEnumerator WaitForOptionChoiceCo(ChoiceContextMenuInstanceState contextMenuInstance)
    {
        yield return new WaitUntil(() => contextMenuInstance.IsChosen);
        actions[contextMenuInstance.Option].Do();
    }

    private ContextMenuOptionProperties[] GetOptions()
    {
        ContextMenuOptionProperties[] options = new ContextMenuOptionProperties[actions.Length];
        for (int i = 0; i < actions.Length; i++)
            options[i] = actions[i].optionProperties;
        return options;
    }


    public ChoiceContextMenuInstanceState ChooseOption(ContextMenuOptionProperties[] options)
    {
        ChoiceContextMenuInstanceState choiceInstance = new ChoiceContextMenuInstanceState();

        return choiceInstance;
    }








}
