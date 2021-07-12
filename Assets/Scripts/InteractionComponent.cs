using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionComponent : MonoBehaviour
{
    public Condition[] conditions;

    public InteractionOption[] actions;

    private int chosenOption = -1;



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
        {
            throw (new System.Exception("Error: Brak akcji"));
        }


        if (actions.Length == 1)
            actions[0].Do();
        else
        {
            //UIController.ShowContextMenu(actions);
            StartCoroutine(WaitForOptionChoiceCo());
        }

    }

    IEnumerator WaitForOptionChoiceCo()
    {
        yield return new WaitUntil(() => chosenOption >= 0);
        actions[chosenOption].Do();
        chosenOption = -1;
    }



}
