using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractiveObject : MonoBehaviour
{
    protected InteractionComponentBase[] components;

    private void Awake()
    {
        components = GetComponents<InteractionComponentBase>();
    }

    protected void Interact()
    {
        Debug.Log("Interacted");
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
