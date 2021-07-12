

[System.Serializable]
public class Condition
{
    public enum Type
    {
        HasItem,
        UsedItem
    }

    public Type type;
    public Requirement requirement;


    public bool IsFulfilled()
    {
        return requirement.IsFulfilled();
    }



    protected void OnValidate()
    {
        switch (type)
        {
            case Type.HasItem:
                requirement = new HasItemRequirement();
                break;
            case Type.UsedItem:
                requirement = new UsedItemRequirement();
                break;
        }
    }
}


