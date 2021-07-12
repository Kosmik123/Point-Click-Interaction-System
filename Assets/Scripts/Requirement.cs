using UnityEngine;



[System.Serializable]
public class Requirement 
{
    public virtual bool IsFulfilled() { return false; }
}


[System.Serializable]
public class HasItemRequirement : Requirement
{
    public ScriptableObject itemInInventory;

    public override bool IsFulfilled()
    {
        return true;
    }

}

[System.Serializable]
public class UsedItemRequirement : Requirement
{
    public ContextMenuOptionProperties itemUsed;

    public override bool IsFulfilled()
    {
        return true;
    }
}


