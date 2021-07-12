using UnityEngine;
using UnityEditor;


[CreateAssetMenu]
public class VariableSetting : ScriptableObject
{
    public enum Type
    {
        Set, Add
    }

    public int id;
    public Type type;
    public int value;

    private void OnValidate()
    {
        name = type == Type.Set ?
            "Set variable " + id + " as " + value :
            "Add " + value + " to variable " + id;
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), name);
    }
}
