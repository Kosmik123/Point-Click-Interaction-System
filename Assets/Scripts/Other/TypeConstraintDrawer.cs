using UnityEditor;
using UnityEngine;



/*


public class StoreInterfaceReference : MonoBehaviour, MyInterface
{
    [TypeConstraint(typeof(MyInterface))]
    public GameObject myReference;

    public void Do()
    {
    }
}

public interface MyInterface
{
    void Do();
}

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

                if (draggedObject is GameObject)
                {
                    GameObject draggedGameObject = draggedObject as GameObject;
                    if (draggedGameObject.GetComponent( constraint.Type ) == null)
                    {
                        DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
                    }
                }
                else if ((draggedObject is IInventory) == false)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
                }

                
            }

            AssignProperty(position, property, label, constraint);

        }


        private static void AssignProperty(Rect position, SerializedProperty property, GUIContent label, TypeConstraintAttribute constraint)
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

            property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(Object), true);

        }
    }
}