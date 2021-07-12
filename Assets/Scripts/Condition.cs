using UnityEngine;



[CreateAssetMenu()]
public abstract class Condition : ScriptableObject
{
    public abstract bool IsFulfilled();
}
