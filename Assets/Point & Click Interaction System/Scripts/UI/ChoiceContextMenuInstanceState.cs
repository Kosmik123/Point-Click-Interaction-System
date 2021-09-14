using UnityEngine.Events;

namespace PointAndClick
{
    public class ChoiceContextMenuInstanceState
    {
        public bool IsChosen { get; private set; }
        public OptionProperties Option { get; private set; }

        public ContextMenu contextMenu;
        
        // maybe will use it in the future. For now I dont know how to configure it
        public UnityAction<OptionProperties> SetAction;

        public ChoiceContextMenuInstanceState(ContextMenu menu)
        {
            SetAction += Set;
            IsChosen = false;
            Option = null;
            contextMenu = menu;
        }

        public void Set(OptionProperties opt)
        {
            Option = opt;
            IsChosen = true;
        }
    }
}
