using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class AutomaticInterface : MonoBehaviour
    {
        /// <summary>
        /// The panel which allows performing most of actions in game
        /// </summary>
        public GameObject MainPanel;
        private Rect _mainPanelRect = new Rect(0.9f, 0.3f, 0.1f, 0.7f);
        /// <summary>
        /// Panel with amounts of resources in current city
        /// </summary>
        public GameObject ResourcePanel;
        private Rect _resourcePanelRect = new Rect(0.05f, 0, 0.7f, 0.05f);
        /// <summary>
        /// Panel which shows minimap
        /// </summary>
        public GameObject MiniMapPanel;
        private Rect _miniMapPanelRect = new Rect(0.9f, 0, 0.1f, 0.25f);

        private Rect _centerRect = new Rect(0.2f, 0.1f, 0.6f, 0.8f);
        private Rect _exitRect = new Rect(0, 0.95f, 0.05f, 0.05f);

        private Dictionary<string, GameObject> buttonPanels;

        public void Start ()
        {
            CreatePanels();
            CreateButtons();
        }

       
        private void CreatePanels()
        {
            MainPanel = Instantiate(Prefabs.VerticalGroupPanel);
            SetGameObjectPosition(MainPanel, _mainPanelRect, transform);

            MiniMapPanel = Instantiate(Prefabs.Panel);
            SetGameObjectPosition(MiniMapPanel, _miniMapPanelRect, transform);
            
            CreateResourcePanel();
        }

        private void SetGameObjectPosition(GameObject what, Rect how, Transform parent)
        {
            var rectTransform = what.GetComponent<RectTransform>();
            rectTransform.SetParent(parent);
            rectTransform.anchorMax = how.position + new Vector2(how.width, how.height);
            rectTransform.anchorMin = how.position;
            rectTransform.offsetMax = rectTransform.offsetMin = Vector2.zero;
        }

        private void CreateButtons()
        {
            buttonPanels = new Dictionary<string, GameObject>
            {
                {"Production", Instantiate(Prefabs.Panel)},
                {"Character", Instantiate(Prefabs.Panel)},
                {"Diplomacy", Instantiate(Prefabs.Panel)},
                {"Law", Instantiate(Prefabs.Panel)},
                {"Science", Instantiate(Prefabs.Panel)},
                {"Build", Instantiate(Prefabs.GridGroupPanel)},
                {"Trade", Instantiate(Prefabs.Panel)}
            };
            foreach (var namesToPanels in buttonPanels)
            {
                var panel = namesToPanels.Value;
                SetGameObjectPosition(panel, _centerRect, transform);

                var buttonGameObject = Instantiate(Prefabs.CogwheelButton);
                buttonGameObject.name = namesToPanels + "Button";
                buttonGameObject.transform.SetParent(MainPanel.transform);
                AddNotRotatingTextToButton(buttonGameObject, namesToPanels.Key);
                buttonGameObject.GetComponent<Button>().onClick.AddListener(() =>
                {
                    foreach (var pair in buttonPanels)
                    {
                        pair.Value.SetActive(false);
                    }
                    panel.SetActive(true);
                });

                var exit = Instantiate(Prefabs.ExitButton);
                SetGameObjectPosition(exit, _exitRect, panel.transform);

                panel.SetActive(false);
            }

            FillBuildingsPanel();

            var globalMapButton = Instantiate(Prefabs.CasualButton);
            globalMapButton.transform.position = Vector3.zero;
            //globalMapButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(""));
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
            SetGameObjectPosition(ResourcePanel, _resourcePanelRect, transform);

            foreach (var type in Controllers.ConstantData.ResourceTypes)
            {
                var indicator = Instantiate(Prefabs.ResourceIndicator);
                indicator.transform.SetParent(ResourcePanel.transform);
                indicator.GetComponentInChildren<Image>().sprite = Sprites.ResourceSprite(type);
                indicator.GetComponentInChildren<Text>().text =
                    Controllers.CurrentInfo.Resources[type].Amount.ToString();
                indicator.GetComponent<ResourceData>().Type = type;
            }
        }


        public static Rect CenterOfScreenRect(float width, float height)
        {
            var relativeWidth = width/Screen.width;
            var relativeHeight = height/Screen.height;
            var posx = (Screen.width - width)/(2.0f * Screen.width);
            var posy = (Screen.height - height)/(2.0f * Screen.height);
            return new Rect(posx, posy, relativeWidth, relativeHeight);
        }

        private void FillBuildingsPanel()
        {
            var buildingPanel = buttonPanels["Build"];
            foreach (var building in Controllers.ConstantData.BuildingCosts.Keys)
            {
                var button = Instantiate(Prefabs.BuildButton);
                button.transform.SetParent(buildingPanel.transform);
                button.GetComponent<BuildButton>().SetUp(building, buildingPanel);
            }
        }
    }
}
