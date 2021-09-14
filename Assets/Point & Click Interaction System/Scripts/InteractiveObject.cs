using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PointAndClick
{ 
    public class InteractiveObject : MonoBehaviour
    {
        public bool stackable;
        protected InteractionBase[] components;

        private bool isBusy;


        private void Awake()
        {
            components = GetComponents<InteractionBase>();
        }

        public void Interact()
        {
            if (stackable)
                InteractStackable();
            else
                InteractNotStackable();
        }

        private void InteractStackable()
        {
            throw new System.NotImplementedException();
        }

        private void InteractNotStackable()
        {
            for(int i = components.Length-1; i >=0; i--)
            {
                var component = components[i];
                if (component.IsConditionFulfilled())
                {
                    Perform(component.GetActions());
                    return;
                }
            }
        }

        private void Perform(InteractionOption[] actions)
        {
            if (isBusy)
                return;

            if (actions.Length < 1)
                NoActionException();

            if (actions.Length == 1)
            {
                actions[0].Do();
            }
            else
            {
                isBusy = true;
                StartCoroutine(WaitForOptionChoiceCo(actions));
            }

        }

        private IEnumerator WaitForOptionChoiceCo(InteractionOption[] actions)
        {
            OptionProperties[] options = GetOptions(actions);
            var contextMenuInstance = GetNewContextMenuState(options);

            yield return new WaitUntil(() => contextMenuInstance.IsChosen);

            // Invoke chosen action
            foreach (var action in actions)
            {
                if (action.contextMenuProperties == contextMenuInstance.Option)
                {
                    Destroy(contextMenuInstance.contextMenu.gameObject);
                    action.Do();
                    isBusy = false;
                    break;
                }
            }
        }


        private OptionProperties[] GetOptions(InteractionOption[] actions)
        {
            OptionProperties[] options = new OptionProperties[actions.Length];
            for (int i = 0; i < actions.Length; i++)
                options[i] = actions[i].contextMenuProperties;

            return options;
        }

        private ChoiceContextMenuInstanceState GetNewContextMenuState(
            OptionProperties[] options)
        {
            ChoiceContextMenuInstanceState choiceInstance =
                UIController.Instance.CreateContextMenu(options);

            return choiceInstance;
        }


        protected static void NoActionException()
        {
            throw new System.Exception("Error: No action assigned!");
        }


        private void OnMouseUpAsButton()
        {
            Debug.Log("Clicked");
            Interact();
        }
    }
}
