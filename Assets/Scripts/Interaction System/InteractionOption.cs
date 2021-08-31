using UnityEngine.Events;

namespace PointAndClick
{
    [System.Serializable]
    public class InteractionOption
    {
        public OptionProperties contextMenuProperties;
        public UnityEvent action;

        public void Do()
        {
            action.Invoke();
        }
    }
}
