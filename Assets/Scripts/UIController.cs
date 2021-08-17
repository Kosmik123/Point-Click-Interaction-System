using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace PointAndClick
{

    public class UIController : MonoBehaviour
    {
        public static UIController Instance { get { return instance; } }
        private static UIController instance = null;

        [Header("Prefabs")]
        public GameObject contextMenuPrefab;
        public GameObject contextMenuButtonPrefab;

        [Header("To Link")]
        public RectTransform contextMenuContainer;


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

        public ChoiceContextMenuInstanceState CreateContextMenu(ContextMenuOptionProperties[] optionsArray)
        {
            GameObject contextMenuObj = Instantiate(contextMenuPrefab, contextMenuContainer);
            ContextMenu contextMenu = contextMenuObj.GetComponent<ContextMenu>();
            ChoiceContextMenuInstanceState answer = new ChoiceContextMenuInstanceState(contextMenu);

            foreach (var option in optionsArray)
            {
                GameObject buttonObj = Instantiate(contextMenuButtonPrefab, contextMenuObj.transform);
                Button button = buttonObj.GetComponent<Button>();
                button.onClick.AddListener(delegate { answer.setAction(option); });
            }

            return answer;
        }

    }




    public class ChoiceContextMenuInstanceState
    {
        public bool IsChosen { get; private set; }
        public ContextMenuOptionProperties Option { get; private set; }

        public ContextMenu contextMenu;
        public UnityAction<ContextMenuOptionProperties> setAction;

        public ChoiceContextMenuInstanceState(ContextMenu menu)
        {
            setAction += Set;
            IsChosen = false;
            Option = null;
            contextMenu = menu;
        }

        public void Set(ContextMenuOptionProperties opt)
        {
            Option = opt;
            IsChosen = true;
        }






    }

}