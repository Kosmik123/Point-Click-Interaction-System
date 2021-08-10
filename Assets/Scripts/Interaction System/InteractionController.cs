using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController Instance { get { return instance; } }
    private static InteractionController instance = null;

    private static Dictionary<int, bool> flags = new Dictionary<int, bool>();
    private static Dictionary<int, int> variables = new Dictionary<int, int>();

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
        flags[id] = !flags[id];
    }
    public bool GetFlag(int id)
    {
        if(!flags.ContainsKey(id))
            UnsetFlag(id);
        return flags[id];
    }

    public void ChangeVariable(VariableSetting settings)
    {
        switch (settings.type)
        {
            case VariableSetting.Type.Set:
                variables[settings.id] = settings.value;
                break;
            case VariableSetting.Type.Add:
                variables[settings.id] += settings.value;
                break;
            case VariableSetting.Type.SetVariable:
                variables[settings.id] = variables[settings.value];
                break;
            case VariableSetting.Type.AddVariable:
                variables[settings.id] += variables[settings.value];
                break;
        }
    }

    public bool CompareVariableWithValue(int varId, VariableSetting.CompareType compareType, int value)
    {
        switch (compareType)
        {
            case VariableSetting.CompareType.Less:
                return variables[varId] < value;

            case VariableSetting.CompareType.NotLess:
                return variables[varId] >= value;

            case VariableSetting.CompareType.Equal:
                return variables[varId] == value;

            case VariableSetting.CompareType.NotEqual:
                return variables[varId] != value;

            case VariableSetting.CompareType.Greater:
                return variables[varId] > value;

            case VariableSetting.CompareType.NotGreater:
                return variables[varId] <= value;
        }
        return false;
    }

    public bool CompareVariables(int var1, VariableSetting.CompareType compareType, int var2)
    {
        switch (compareType)
        {
            case VariableSetting.CompareType.Less:
                return variables[var1] < variables[var2];

            case VariableSetting.CompareType.NotLess:
                return variables[var1] >= variables[var2];

            case VariableSetting.CompareType.Equal:
                return variables[var1] == variables[var2];

            case VariableSetting.CompareType.NotEqual:
                return variables[var1] != variables[var2];

            case VariableSetting.CompareType.Greater:
                return variables[var1] > variables[var2];

            case VariableSetting.CompareType.NotGreater:
                return variables[var1] <= variables[var2];
        }
        return false;
    }


    public void Print(object obj)
    {
        Debug.Log(obj);
    }



}
