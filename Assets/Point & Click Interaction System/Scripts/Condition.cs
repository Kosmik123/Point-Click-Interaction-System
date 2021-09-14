using UnityEngine;
using UnityEditor;

namespace PointAndClick
{ 
    [System.Serializable]
    public class Condition
    {
        public enum Type
        {
            HasItem,
            UsedItem,
            ItemAmount,
            FlagState,
            VariableCompareValue,
            VariableCompareVariable,
            SavedCondition,
            AnimatorState
        }

        public string name;
        public Type type;
        private Type lastType;

        public Requirement properties;

        // conditioned properties
        public Item item;
        public int id, value;
        public bool flagState = true;
        public VariableSetting.CompareType variableCompareType;
        public Requirement savedCondition;
        public Animator animatorToCompare;
        public string animatorStateName;


        public Condition()
        {
            ChangeRequirement();
        }

        public bool IsFulfilled()
        {
            switch (type)
            {
                case Type.HasItem:
                    return InteractionController.Inventory.HasItem(item);

                case Type.UsedItem:
                    return InteractionController.Inventory.GetUsedItem() == item;

                case Type.ItemAmount:
                    return InteractionController.Inventory.GetItemCount(item) >= value;

                case Type.FlagState:
                    return InteractionController.Instance.GetFlag(id) == flagState;

                case Type.VariableCompareValue:
                    return InteractionController.Instance.CompareVariableWithValue(id, variableCompareType, value);

                case Type.VariableCompareVariable:
                    return InteractionController.Instance.CompareVariables(id, variableCompareType, value);

                case Type.SavedCondition:
                    return (savedCondition != null && savedCondition.IsFulfilled());

                case Type.AnimatorState:
                    return animatorToCompare.GetCurrentAnimatorStateInfo(0).IsName(animatorStateName);

            }
            return false;
            //return properties.IsFulfilled();
        }

        public bool HasTypeChanged()
        {
            return lastType != type;
        }

        public void ChangeRequirement()
        {
            return;
            switch (type)
            {
                case Type.HasItem:
                    properties = new HasItemRequirement();
                    break;
                case Type.UsedItem:
                    properties = new UsedItemRequirement();
                    break;
                case Type.ItemAmount:
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
                // Precalculate some height values
                float heightHalf = (position.height - 20) * 0.5f;
                float heightOneFourth = (position.height - 20) * 0.25f;

                EditorGUI.BeginProperty(position, label, property);

                // draw property label
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
                               position.width / 2 - 4,
                               heightHalf);
                SerializedProperty typeEnum = property.FindPropertyRelative("type");
                EditorGUI.PropertyField(enumRect, typeEnum, GUIContent.none);

                // other rects








                // getting properties
                SerializedProperty itemProp = property.FindPropertyRelative("item");
                SerializedProperty idProp = property.FindPropertyRelative("id");
                SerializedProperty valueProp = property.FindPropertyRelative("value");
                SerializedProperty flagStateProp = property.FindPropertyRelative("flagState");
                SerializedProperty varCompareProp = property.FindPropertyRelative("variableCompareType");
                SerializedProperty savedConditionProp = property.FindPropertyRelative("savedCondition");
                SerializedProperty animatorRefProp = property.FindPropertyRelative("animatorToCompare");
                SerializedProperty stateNameProp = property.FindPropertyRelative("animatorStateName");


                float widthQuarter = position.width / 4 - 5;

                Type conditionType = (Type)typeEnum.enumValueIndex;
                switch (conditionType)
                {
                    case Type.HasItem:
                    case Type.UsedItem:
                    case Type.ItemAmount:
                        Rect itemRect = new Rect(position.x + position.width * 0.5f,
                                   position.y + heightOneFourth,
                                   position.width / 2,
                                   heightHalf);

                        EditorGUI.PropertyField(itemRect, itemProp, GUIContent.none);
                        if (conditionType == Type.ItemAmount)
                        {
                            Rect countRect = new Rect(position.x + position.width / 2,
                                        position.y + heightOneFourth + 18,
                                        position.width / 2,
                                        heightHalf);
                            EditorGUI.PropertyField(countRect, valueProp, GUIContent.none);
                        }

                        break;
                    case Type.FlagState:
                        Rect flagLabelRect = new Rect(position.x,
                                    position.y + heightOneFourth + 18,
                                    widthQuarter,
                                    heightHalf);
                        Rect flagRect = new Rect(position.x + widthQuarter,
                                    position.y + heightOneFourth + 18,
                                    widthQuarter,
                                    heightHalf);
                        Rect flagStateLabelRect = new Rect(position.x + 2 * widthQuarter + 5,
                                    position.y + heightOneFourth + 18,
                                    widthQuarter - 5,
                                    heightHalf);
                        Rect flagStateRect = new Rect(position.x + 3 * widthQuarter,
                                    position.y + heightOneFourth + 18,
                                    widthQuarter,
                                    heightHalf);
                        EditorGUI.LabelField(flagLabelRect, new GUIContent("Flag"));
                        EditorGUI.PropertyField(flagRect, idProp, GUIContent.none);
                        EditorGUI.LabelField(flagStateLabelRect, new GUIContent(" is"));
                        EditorGUI.PropertyField(flagStateRect, flagStateProp, GUIContent.none);
                        break;

                    case Type.VariableCompareValue:
                    case Type.VariableCompareVariable:
                        float widthOneFifth = position.width / 5;
                        Rect variableLabelRect = new Rect(position.x,
                                    position.y + heightOneFourth + 16,
                                    widthOneFifth - 2,
                                    heightHalf);
                        Rect variableRect = new Rect(position.x + widthOneFifth,
                                    position.y + heightOneFourth + 16,
                                    widthOneFifth - 2,
                                    heightHalf);
                        Rect compareVariableRect = new Rect(position.x + 2 * widthOneFifth,
                                    position.y + heightOneFourth + 16,
                                    widthOneFifth - 2,
                                    position.height);
                        Rect valueLabelRect = new Rect(position.x + 3 * widthOneFifth,
                                    position.y + heightOneFourth + 16,
                                    widthOneFifth - 2,
                                    heightHalf);
                        Rect valueRect = new Rect(position.x + 4 * widthOneFifth - 5,
                                    position.y + heightOneFourth + 16,
                                    widthOneFifth - 2,
                                    heightHalf);

                        EditorGUI.LabelField(variableLabelRect, new GUIContent("Variable"));
                        EditorGUI.PropertyField(variableRect, idProp, GUIContent.none);
                        EditorGUI.PropertyField(compareVariableRect, varCompareProp, GUIContent.none);
                        EditorGUI.LabelField(valueLabelRect,
                            new GUIContent(conditionType == Type.VariableCompareValue ? "Value" : "Variable"));
                        EditorGUI.PropertyField(valueRect, valueProp, GUIContent.none);
                        break;
                    case Type.SavedCondition:
                        Rect savedConditionRect = new Rect(position.x ,
                                    position.y + heightOneFourth + 18,
                                    position.width,
                                    heightHalf);
                        EditorGUI.PropertyField(savedConditionRect, savedConditionProp, GUIContent.none);
                        break;

                    case Type.AnimatorState:
                        Rect animatorRefRect = new Rect(position.x,
                                    position.y + heightOneFourth + 18,
                                    2 * widthQuarter,
                                    heightHalf);
                        Rect animatorStateNameRect = new Rect(position.x + position.width / 2,
                                    position.y + heightOneFourth + 18,
                                    position.width / 2,
                                    heightHalf);
                        EditorGUI.PropertyField(animatorRefRect, animatorRefProp, GUIContent.none);
                        EditorGUI.PropertyField(animatorStateNameRect, stateNameProp, GUIContent.none);
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
}
