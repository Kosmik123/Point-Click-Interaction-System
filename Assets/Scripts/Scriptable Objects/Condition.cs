using UnityEngine;
using UnityEditor;



[System.Serializable]
public class Condition
{
    public enum Type
    {
        HasItem,
        UsedItem,
        ItemAmount

    }

    public string name;
    public Type type;
    private Type lastType;
    public Requirement properties;

    public bool IsFulfilled()
    {
        return properties.IsFulfilled();
    }

    public bool HasTypeChanged()
    {
        return lastType != type;
    }

    public void ChangeRequirement()
    {
        switch (type)
        {
            case Type.HasItem:
                properties = new HasItemRequirement();
                name = "Has Item";
                break;
            case Type.UsedItem:
                name = "Used Item";
                properties = new UsedItemRequirement();
                break;
            case Type.ItemAmount:
                name = "Item Amount";
                properties = new ItemAmountRequirement();
                break;
        }
        lastType = type;
        Debug.Log("Changing requirement to " + properties);
    }


#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(Condition))]
    public class ConditionPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //base.OnGUI(position, property, label);

            EditorGUI.BeginProperty(position, label, property);

            // Precalculate some height values
            float heightHalf = (position.height - 20) * 0.5f;
            float heightOneFourth = (position.height - 20) * 0.25f;

            Rect labelRect = new Rect(position.x,
                          position.y + heightOneFourth,
                          position.width,
                          position.height);

            position = EditorGUI.PrefixLabel(labelRect,
                                             GUIUtility.GetControlID(FocusType.Passive),
                                             label);

            position.y -= heightOneFourth;

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;


            // type enum display
            Rect enumRect = new Rect(position.x,
                           position.y + heightOneFourth,
                           100,
                           heightHalf);
            SerializedProperty typeEnum = property.FindPropertyRelative("type");
            EditorGUI.PropertyField(enumRect, typeEnum, GUIContent.none);

            Type conditionType = (Type) typeEnum.enumValueIndex;
            switch (conditionType)
            {
                case Type.HasItem:
                    Rect itemRect = new Rect(position.x,
                            position.y + heightOneFourth,
                            100,
                            heightHalf);
                    SerializedProperty itemEnum = property.FindPropertyRelative("type");
                    EditorGUI.PropertyField(enumRect, typeEnum, GUIContent.none);


                    break;
                case Type.UsedItem:

                    break;
                case Type.ItemAmount:

                    break;
            }














            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) * 2 + 20;
        }

    }

#endif


}





