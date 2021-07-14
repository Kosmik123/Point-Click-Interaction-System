using UnityEngine;

[RequireComponent(typeof(InteractionComponent), typeof(Collider))]
public class InteractiveObject3D : InteractiveObject
{
    private void Awake()
    {
        components = GetComponents<InteractionComponent>();
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Clicked");
        Interact();
    }
}