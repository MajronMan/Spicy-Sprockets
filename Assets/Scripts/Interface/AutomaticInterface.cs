using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface {
    public class AutomaticInterface : MonoBehaviour {
        /// <summary>
        /// The panel which allows performing most of actions in game
        /// </summary>
        public GameObject MainPanel;

        private Rect _mainPanelRect = new Rect(0.9f, 0.3f, 0.1f, 0.7f);

        /// <summary>
        /// Panel with amounts of resources in current city
        /// </summary>
        public GameObject ResourcePanel;

        private Rect _resourcePanelRect = new Rect(0.1f, 0, 0.75f, 0.05f);

        /// <summary>
        /// Panel which shows minimap
        /// </summary>
        public GameObject MiniMapPanel;

        private Rect _miniMapPanelRect = new Rect(0.9f, 0, 0.1f, 0.25f);

        private Rect _centerRect = new Rect(0.2f, 0.1f, 0.6f, 0.8f);
        private Rect _exitRect = new Rect(0, 0.95f, 0.05f, 0.05f);
        private Rect _leftHalfRect = new Rect(0, 0, 0.5f, 0.5f);
        private Rect _rightHalfRect = new Rect(0.5f, 0, 0.5f, 0.5f);
        private Rect _fullRect = new Rect(0, 0, 1, 1);
        private Rect _peopleMoneyRect = new Rect(0, 0, 0.1f, 0.1f);

        private Dictionary<string, ExitablePanel> _buttonPanels;

        public void Start() {
            CreatePanels();
            CreateButtons();
        }


        private void CreatePanels() {
            MainPanel = Instantiate(Prefabs.VerticalGroupPanel);
            Util.SetUIObjectPosition(MainPanel, _mainPanelRect, transform);

            CreateMiniMapPanel();

            CreateResourcePanel();

            PeopleAndMoney();
        }

        private void CreateMiniMapPanel() {
            MiniMapPanel = Instantiate(Prefabs.Panel);
            Util.SetUIObjectPosition(MiniMapPanel, _miniMapPanelRect, transform);

            CreateToggleGridButton();
        }

        private void CreateToggleGridButton() {
            var gridToggleButton = Instantiate(Prefabs.TextButton);

            Util.SetUIObjectPosition(gridToggleButton, new Rect(0.0f, 0.75f, 1.0f, 0.25f), MiniMapPanel.transform);

            gridToggleButton.name = "GridToggleButton";

            var text = gridToggleButton.GetComponentInChildren<Text>();
            if (text == null) Debug.Log("Text component not found in the hierarchy of TextButton prefab");

            text.text = "Toggle grid";
            text.resizeTextMaxSize = 12;

            var button = gridToggleButton.GetComponentInChildren<Button>();
            if (button == null) Debug.Log("Button component not found in the hierarchy of TextButton prefab");

            button.onClick.AddListener(() => { Controllers.CurrentCityController.MapInstance.ToggleGrid(); });
        }

        private void CreateButtons() {
            _buttonPanels = new Dictionary<string, ExitablePanel> {
                {"Production", CreateExitablePanel(Prefabs.Panel)},
                {"Character", CreateExitablePanel(Prefabs.Panel)},
                {"Diplomacy", CreateExitablePanel(Prefabs.Panel)},
                {"Law", CreateExitablePanel(Prefabs.Panel)},
                {"Science", CreateExitablePanel(Prefabs.Panel)},
                {"Build", CreateExitablePanel(Prefabs.GridGroupPanel)},
                {"Trade", CreateExitablePanel(Prefabs.Panel)}
            };
            foreach (var namesToPanels in _buttonPanels) {
                var panel = namesToPanels.Value;
                panel.name = namesToPanels.Key + "Panel";
                Util.SetUIObjectPosition(panel.gameObject, _centerRect, transform);

                var buttonGameObject = Instantiate(Prefabs.CogwheelButton);
                buttonGameObject.name = namesToPanels.Key + "Button";
                buttonGameObject.transform.SetParent(MainPanel.transform);
                AddNotRotatingTextToButton(buttonGameObject, namesToPanels.Key);
                buttonGameObject.GetComponent<Button>().onClick.AddListener(() => {
                    foreach (var pair in _buttonPanels) {
                        pair.Value.gameObject.SetActive(false);
                    }
                    panel.gameObject.SetActive(true);
                });
                panel.gameObject.SetActive(false);
            }

            FillBuildingsPanel();
            _buttonPanels["Trade"].Content.AddComponent<Trade>();

            var globalMapButton = Instantiate(Prefabs.CasualButton);
            globalMapButton.transform.position = Vector3.zero;
            //globalMapButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(""));
        }

        private ExitablePanel CreateExitablePanel(GameObject child) {
            var panel = Instantiate(Prefabs.ExitablePanel);
            var inner = Instantiate(child);
            Util.SetUIObjectPosition(inner, _fullRect, panel.transform);
            var exitable = panel.GetComponent<ExitablePanel>();
            exitable.Content = inner;
            return exitable;
        }

        private void AddNotRotatingTextToButton(GameObject button, string text) {
            var buttonRectTransform = button.GetComponent<RectTransform>();
            var textGO = Instantiate(Prefabs.NotRotatingText);

            textGO.transform.SetParent(button.transform);
            textGO.GetComponent<Text>().text = text;

            var textRectTransform = textGO.GetComponent<RectTransform>();
            textRectTransform.anchorMax = textRectTransform.anchorMin = buttonRectTransform.pivot;
            textRectTransform.offsetMax = buttonRectTransform.sizeDelta;
            textRectTransform.offsetMin = -buttonRectTransform.sizeDelta;
        }

        private void CreateResourcePanel() {
            ResourcePanel = Instantiate(Prefabs.HorizontalGroupPanel);
            Util.SetUIObjectPosition(ResourcePanel, _resourcePanelRect, transform);

            foreach (var type in Controllers.ConstantData.ResourceTypes) {
                var indicator = Instantiate(Prefabs.ResourceIndicator);
                indicator.transform.SetParent(ResourcePanel.transform);
                indicator.GetComponentInChildren<Image>().sprite = Sprites.ResourceSprite(type);
                indicator.GetComponentInChildren<Text>().text =
                    Controllers.CurrentInfo.Resources[type].Amount.ToString();
                indicator.GetComponent<ResourceData>().Type = type;
            }
        }


        public static Rect CenterOfScreenRect(float width, float height) {
            var relativeWidth = width / Screen.width;
            var relativeHeight = height / Screen.height;
            var posx = (Screen.width - width) / (2.0f * Screen.width);
            var posy = (Screen.height - height) / (2.0f * Screen.height);
            return new Rect(posx, posy, relativeWidth, relativeHeight);
        }

        private void FillBuildingsPanel() {
            var buildingPanel = _buttonPanels["Build"];
            foreach (var building in Controllers.ConstantData.BuildingCosts.Keys) {
                var button = Instantiate(Prefabs.BuildButton);
                button.transform.SetParent(buildingPanel.Content.transform);
                button.GetComponent<BuildButton>().SetUp(building, buildingPanel.gameObject);
            }
        }

        private void PeopleAndMoney() {
            var panel = Instantiate(Prefabs.VerticalGroupPanel);
            Util.SetUIObjectPosition(panel, _peopleMoneyRect, transform);

            var people = Instantiate(Prefabs.ResourceIndicator);
            var peopleData = people.GetComponent<ResourceData>();
            peopleData.PopulationRef = Controllers.CurrentInfo.ThePeople;
            people.transform.SetParent(panel.transform);
            people.GetComponentInChildren<Image>().sprite = Sprites.SpecialResourceSprite(typeof(Population));
            var rt = (RectTransform) people.transform;
            rt.sizeDelta = new Vector2(0, 0);

            var money = Instantiate(Prefabs.ResourceIndicator);
            var moneyData = money.GetComponent<ResourceData>();
            moneyData.MoneyRef = Controllers.CurrentInfo.MyMoney;
            money.transform.SetParent(panel.transform);
            money.GetComponentInChildren<Image>().sprite = Sprites.SpecialResourceSprite(typeof(Money));
            rt = (RectTransform) money.transform;
            rt.sizeDelta = new Vector2(0, 0);
        }
    }
}