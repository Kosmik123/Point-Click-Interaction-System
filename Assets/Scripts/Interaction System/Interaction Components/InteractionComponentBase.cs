using UnityEngine;

// base class for condition -> action system
public abstract class InteractionComponentBase :  MonoBehaviour
{
    public abstract bool IsConditionFulfilled();
    public abstract void Perform();
}

