using UnityEngine.Events;

[System.Serializable]
public class InteractionOption
{
    public ContextMenuOptionProperties optionProperties;
    public UnityEvent action;

    public void Do()
    {
        action.Invoke();
    }

}