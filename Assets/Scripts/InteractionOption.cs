using UnityEngine.Events;

[System.Serializable]
public class InteractionOption
{
    public ContextMenuOptionProperties optionProperties;
    public CustomEvent action;

    public void Do()
    {
        action.Invoke(1,1);
    }

}


[System.Serializable]
public class CustomEvent : UnityEvent<int, int>
{

}