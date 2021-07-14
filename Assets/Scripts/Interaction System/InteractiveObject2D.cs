using UnityEngine;

[RequireComponent(typeof(InteractionComponent), typeof(Collider2D))]
public class InteractiveObject2D : InteractiveObject
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
