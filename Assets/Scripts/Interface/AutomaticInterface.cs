using System;
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
            MainPanel = Instantiate(Prefabs.VerticalGroupPanel);
            SetPanelPosition(MainPanel, _mainPanelRect);

            MiniMapPanel = Loader.NewInstance(PrefabPaths.Panel);
            SetPanelPosition(MiniMapPanel, _miniMapPanelRect);

            CreateResourcePanel();
        }

        private void SetPanelPosition(GameObject what, Rect how)
        {
            var rectTransform = what.GetComponent<RectTransform>();
            rectTransform.SetParent(this.gameObject.transform);
            rectTransform.anchorMax = how.position + new Vector2(how.width, how.height);
            rectTransform.anchorMin = how.position;
            rectTransform.offsetMax = rectTransform.offsetMin = Vector2.zero;
        }

        private void CreateButtons()
        {
            foreach (var buttonName in _mainButtons)
            {
                var buttonGameObject = Instantiate(Prefabs.CogwheelButton);
                buttonGameObject.name = buttonName + "Button";
                buttonGameObject.transform.SetParent(MainPanel.transform);
                AddNotRotatingTextToButton(buttonGameObject, buttonName);
            }
            var globalMapButton = Instantiate(Prefabs.CasualButton);
        }

        private void AddNotRotatingTextToButton(GameObject button, string text)
        {
            var buttonRectTransform = button.GetComponent<RectTransform>();
            var textGO = Instantiate(Prefabs.NotRotatingText);

            textGO.transform.SetParent(button.transform);
            textGO.GetComponent<Text>().text = text;

            var textRectTransform = textGO.GetComponent<RectTransform>();
            textRectTransform.anchorMax = textRectTransform.anchorMin = buttonRectTransform.pivot;
            textRectTransform.offsetMax = buttonRectTransform.sizeDelta;
            textRectTransform.offsetMin = -buttonRectTransform.sizeDelta;
        }

        private void CreateResourcePanel()
        {
            ResourcePanel = Instantiate(Prefabs.HorizontalGroupPanel);
            SetPanelPosition(ResourcePanel, _resourcePanelRect);

            foreach (var sprite in Sprites.ResourcesSprites)
            {
                var indicator = Instantiate(Prefabs.ResourceIndicator);
                indicator.transform.SetParent(ResourcePanel.transform);
                indicator.GetComponentInChildren<Image>().sprite = sprite;
                Debug.Log(sprite.name);
                indicator.GetComponentInChildren<Text>().text = Controllers.CurrentInfo.Resources[sprite.name].GetQuantity().ToString();
                indicator.GetComponentInChildren<ResourceData>().Type = sprite.name;
            }
        }

    }
}
