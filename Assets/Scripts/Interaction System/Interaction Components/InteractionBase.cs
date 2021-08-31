using UnityEngine;

namespace PointAndClick
{
    // base class for condition -> action system
    public abstract class InteractionBase : MonoBehaviour
    {
        public abstract bool IsConditionFulfilled();
        public abstract void Perform();

        protected static void NoActionException()
        {
            throw new System.Exception("Error: No action assigned!");
        }
    }
}
