using UnityEditor;
using UnityEngine;

/*
https://answers.unity.com/questions/1479756/

     +============================+
     |    Script by Xarbrough     |
     |  Mar 13, 2018 at 12:44 PM  |
     +============================+
*/

namespace PointAndClick
{
    public class TypeConstraintAttribute : PropertyAttribute
    {
        public System.Type Type { get; }

        public TypeConstraintAttribute(System.Type type)
        {
            Type = type;
        }
    }


    [CustomPropertyDrawer(typeof(TypeConstraintAttribute))]
    public class TypeConstraintDrawer : PropertyDrawer
    {
        private bool IsObjectOfType(object refObject, System.Type type)
        {
            if (refObject is GameObject)
            {
                GameObject draggedGameObject = refObject as GameObject;
                if (draggedGameObject.GetComponent(type) == null)
                {
                    return false;
                }
            }
            else if ((refObject is IInventory) == false)
            {
                return false;
            }
            return true;
        }



        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                // Show error
                // Also check that the user only uses the attribute on a GameObject or Component
                // because we need to call GetComponent
            }

            var constraint = attribute as TypeConstraintAttribute;




            if (DragAndDrop.objectReferences.Length > 0)
            {
                var draggedObject = DragAndDrop.objectReferences[0];
                if (IsObjectOfType(draggedObject, constraint.Type) == false)
                    DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;


            }

            AssignProperty(position, property, label, constraint);

        }


        private void AssignProperty(Rect position, SerializedProperty property, GUIContent label, TypeConstraintAttribute constraint)
        {
            /*
            // If a value was set through other means (e.g. ObjectPicker)
            if (property.objectReferenceValue != null)
            {
                GameObject go = property.objectReferenceValue as GameObject;
                if (go != null && go.GetComponent(constraint.Type) == null)
                {
                    // Clean out invalid references.
                    property.objectReferenceValue = null;
                }
            }            
            */

            //EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(Object), true);


            property.objectReferenceValue = EditorGUI.ObjectField(
                position, label, property.objectReferenceValue, typeof(Object), true);
            if (IsObjectOfType(property.objectReferenceValue, constraint.Type) == false)
                property.objectReferenceValue = null;

        }
    }
}