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
}
