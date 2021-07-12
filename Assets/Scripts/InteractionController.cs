using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController Instance { get { return instance; } }
    private static InteractionController instance = null;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void SetFlag(int id)
    {
        ;
    }    

    public void UnsetFlag(int id)
    {
        ;
    }

    public int ShowContextMenu(Condition condition)
    {
        return 0;
    }






}
