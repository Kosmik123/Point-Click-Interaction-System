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
