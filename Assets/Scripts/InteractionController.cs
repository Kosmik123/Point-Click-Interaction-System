using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController Instance { get { return instance; } }
    private static InteractionController instance = null;

    private static Dictionary<int, bool> flags;
    private static Dictionary<int, int> variables;


    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void SetFlag(int id)
    {
        flags[id] = true;
    }    

    public void UnsetFlag(int id)
    {
        flags[id] = false;
    }
    public void ToggleFlag(int id)
    {
        flags[id] = flags[id];
    }


    public void ChangeVariable(VariableSetting settings)
    {
        ;
    }


    public ChoiceContextMenuInstanceState ChooseOption(ContextMenuOptionProperties[] options)
    {
        ChoiceContextMenuInstanceState choiceInstance = new ChoiceContextMenuInstanceState();

        return choiceInstance;
    }




}
