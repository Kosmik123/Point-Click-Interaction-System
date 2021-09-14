using UnityEngine;

namespace PointAndClick
{
    // base class for condition -> action system
    public abstract class InteractionBase : MonoBehaviour
    {

        public abstract bool IsConditionFulfilled();

        public abstract InteractionOption[] GetActions();

    }
}
