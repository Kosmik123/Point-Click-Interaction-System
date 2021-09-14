using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                button.GetComponentInChildren<Text>().text = option.title;
                button.GetComponentsInChildren<Image>()[1].sprite = option.icon;
                button.onClick.AddListener(delegate { answer.SetAction(option); });
            }

            return answer;
        }
    }
}
