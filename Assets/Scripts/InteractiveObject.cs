using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionComponent))]
public class InteractiveObject : MonoBehaviour
{
    private InteractionComponent[] components;


    private void Awake()
    {
        components = GetComponents<InteractionComponent>();
    }



    public void Interact()
    {
        foreach(var component in components)
        {
            if(component.IsConditionFulfilled())
            {
                component.Perform();
                return;
            }
        }
    }

    private void OnMouseDown()
    {
        Interact();
    }


}
