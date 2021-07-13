﻿using UnityEngine;
using UnityEditor;


[CreateAssetMenu]
public class VariableSetting : ScriptableObject
{
    public enum Type
    {
        Set, Add,
        SetVariable, AddVariable
    }

    public int id;
    public Type type;
    public int value;

    private void OnValidate()
    {
        switch (type)
        {
            case Type.Set:
            case Type.Add:
                name  = "Variable[" + id + "] " + type.ToString() + " " + value;
                break;
            case Type.SetVariable:
                name = "Variable[" + id + "] Set Variable[" + value + "]";
                break;
            case Type.AddVariable:
                name = "Variable[" + id + "] Add Variable[" + value + "]";
                break;
        }
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), name);
    }
}
