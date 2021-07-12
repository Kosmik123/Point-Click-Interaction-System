using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get { return instance; } }
    private static UIController instance = null;

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



}




public class ChoiceContextMenuInstanceState
{
    public bool IsChosen { get; private set; }
    public int Option { get; private set; }

    public ChoiceContextMenuInstanceState()
    {
        IsChosen = false;
        Option = -1;
    }

    public void Set(int opt)
    {
        Option = opt;
        IsChosen = true;
    }

}

