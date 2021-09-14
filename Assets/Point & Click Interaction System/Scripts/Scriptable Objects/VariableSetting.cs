using UnityEngine;
using UnityEditor;

namespace PointAndClick
{
    [CreateAssetMenu]
    public class VariableSetting : ScriptableObject
    {
        public enum Type
        {
            Set, Add,
            SetVariable, AddVariable
        }

        public enum CompareType
        {
            [InspectorName("<")] Less,
            [InspectorName(">=")] NotLess,
            [InspectorName("=")] Equal,
            [InspectorName("!=")] NotEqual,
            [InspectorName(">")] Greater,
            [InspectorName("<=")] NotGreater
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
                    name = "Variable[" + id + "] " + type.ToString() + " " + value;
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
}