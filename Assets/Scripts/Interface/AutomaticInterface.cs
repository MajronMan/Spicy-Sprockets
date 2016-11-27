using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class AutomaticInterface : MonoBehaviour
    {
        /// <summary>
        /// The panel which allows performing most of actions in game
        /// </summary>
        public GameObject MainPanel;
        private Rect _mainPanelRect = new Rect(0.8f, 0.3f, 0.2f, 0.7f);
        /// <summary>
        /// Panel with amounts of resources in current city
        /// </summary>
        public GameObject ResourcePanel;
        private Rect _resourcePanelRect = new Rect(0.05f, 0, 0.7f, 0.05f);
        /// <summary>
        /// Panel which shows minimap
        /// </summary>
        public GameObject MiniMapPanel;
        private Rect _miniMapPanelRect = new Rect(0.8f, 0, 0.2f, 0.25f);

        private string[] _mainButtons =
        {
            "Production",
            "Character",
            "Diplomacy",
            "Law",
            "Science",
            "Build",
            "Trade"
        };

        public void Start ()
        {
            CreatePanels();
            CreateButtons();
        }

       
        private void CreatePanels()
        {
            MainPanel = Loader.NewInstance(PrefabPaths.MainPanel);
            SetPanelPosition(MainPanel, _mainPanelRect);

            ResourcePanel = Loader.NewInstance(PrefabPaths.Panel);
            SetPanelPosition(ResourcePanel, _resourcePanelRect);

            MiniMapPanel = Loader.NewInstance(PrefabPaths.Panel);
            SetPanelPosition(MiniMapPanel, _miniMapPanelRect);

        }

        private void SetPanelPosition(GameObject what, Rect how)
        {
            var rectTransform = what.GetComponent<RectTransform>();
            rectTransform.SetParent(transform);
            rectTransform.anchorMax = how.position + new Vector2(how.width, how.height);
            rectTransform.anchorMin = how.position;
            rectTransform.offsetMax = rectTransform.offsetMin = Vector2.zero;
        }

        private void CreateButtons()
        {
            foreach (var button in _mainButtons)
            {
                var buttonGO = Instantiate(Prefabs.CogwheelButton);
                buttonGO.name = button + "Button";
                buttonGO.transform.SetParent(MainPanel.transform);
                var buttonRectTransform = buttonGO.GetComponent<RectTransform>();
                var textGO = Instantiate(Prefabs.NotRotatingText);
                textGO.transform.SetParent(buttonGO.transform);
                textGO.GetComponent<Text>().text = button;
                var textRectTransform = textGO.GetComponent<RectTransform>();
                textRectTransform.anchorMax = buttonRectTransform.pivot;
                textRectTransform.anchorMin = buttonRectTransform.pivot;
                textRectTransform.offsetMax = buttonRectTransform.sizeDelta;
                textRectTransform.offsetMin = -buttonRectTransform.sizeDelta;

            }
        }

    }
}
