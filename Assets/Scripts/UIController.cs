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
        
    public void CreateContextMenu(ContextMenuOptionProperties[] optionsArray, ChoiceContextMenuInstanceState answer)
    {
        // Instantiate (ContextMenuPrefab)
        foreach(var option in optionsArray)
        {
             // Instantiate 1 option button with text = option.message and image = option.icon
        }
    }

}




public class ChoiceContextMenuInstanceState
{
    public bool IsChosen { get; private set; }
    public int OptionId { get; private set; }

    public ChoiceContextMenuInstanceState()
    {
        IsChosen = false;
        OptionId = -1;
    }

    public void Set(int opt)
    {
        OptionId = opt;
        IsChosen = true;
    }






}

