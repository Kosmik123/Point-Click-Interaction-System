using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionComponent))]
public abstract class InteractiveObject : MonoBehaviour
{
    protected InteractionComponent[] components;

    private void Awake()
    {
        components = GetComponents<InteractionComponent>();
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
}
