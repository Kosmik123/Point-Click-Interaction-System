using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PointAndClick
{
    public class InteractiveObject : MonoBehaviour
    {
        public bool stackable;
        protected InteractionBase[] components;

        private void Awake()
        {
            components = GetComponents<InteractionBase>();
        }

        protected void Interact()
        {
            Debug.Log("Interacted");
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
            foreach (var component in components)
            {
                if (component.IsConditionFulfilled())
                {
                    component.Perform();
                    return;
                }
            }
        }

        private void OnMouseUpAsButton()
        {
            Debug.Log("Clicked");
            Interact();
        }
    }
}
