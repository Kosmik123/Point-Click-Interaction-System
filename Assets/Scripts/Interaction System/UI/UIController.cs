using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PointAndClick
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance { get; private set; }

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
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        public ChoiceContextMenuInstanceState CreateContextMenu(OptionProperties[] optionsArray)
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
        public OptionProperties Option { get; private set; }

        public ContextMenu contextMenu;
        public UnityAction<OptionProperties> setAction;

        public ChoiceContextMenuInstanceState(ContextMenu menu)
        {
            setAction += Set;
            IsChosen = false;
            Option = null;
            contextMenu = menu;
        }

        public void Set(OptionProperties opt)
        {
            Option = opt;
            IsChosen = true;
        }
    }
}
