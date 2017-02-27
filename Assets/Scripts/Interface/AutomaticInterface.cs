using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;
using Assets.Scripts.Interface;
using Assets.Static;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

        /// <summary>
        /// A button that switches between maps (interfaces)
        /// </summary>
        public GameObject GlobalMapButton;
        private Rect _globalMapButtonRect = new Rect(0.01f, 0.85f, 0.05f, 0.1f);

        public GameObject PeopleAndMoneyPanel;
        private Rect _peopleMoneyRect = new Rect(0, 0, 0.1f, 0.1f);

        public GameObject TraitsPanel;
        private Rect _traitsPanelRect = new Rect(0, 0.95f, 0.5f, 0.05f);

        //Local map elements
        public GameObject LocalMap;
        public Component[] localMapChildren;

        //Global map elements
        public Map GlobalMap;
        private IntVector2 _globalMapSize = new IntVector2(10000, 10000);
        //TODO: Place the cities - but how to set their position relative to map?

        //Temporary TODO
        public GameObject OurCity;
        public GameObject Dude;

        private Rect _centerRect = new Rect(0.2f, 0.1f, 0.6f, 0.8f);
        private Rect _exitRect = new Rect(0, 0.95f, 0.05f, 0.05f);
        private Rect _leftHalfRect = new Rect(0, 0, 0.5f, 0.5f);
        private Rect _rightHalfRect = new Rect(0.5f, 0, 0.5f, 0.5f);
        private Rect _fullRect = new Rect(0, 0, 1, 1);

        private Dictionary<string, ExitablePanel> _buttonPanels;

        /// <summary>
        /// List of local map elements (without repeating ones)
        /// </summary>
        private List<GameObject> Local = new List<GameObject>();
        /// <summary>
        /// List of global map elements (without repeating ones)
        /// </summary>
        private List<GameObject> Global = new List<GameObject>();

        //All available interfaces
        private enum Interface {Local, Global};

        public void Start ()
        {
            LocalMap = GameObject.Find("Map"); //Finds local map (so we can disable its sprite renderer)   
            CreateInterface(); //Creates all the interfaces           

            Local.Add(MainPanel);
            Local.Add(ResourcePanel);
            Local.Add(MiniMapPanel);
            Local.Add(PeopleAndMoneyPanel);
            Local.Add(GlobalMapButton);
            //TODO: Add also the panels activated through the main panel buttons (because they stay open)
            //Or find another way like disabling buttons while some panel is open (maybe interactive button script?)
            Global.Add(ResourcePanel);
            Global.Add(PeopleAndMoneyPanel);
            Global.Add(GlobalMapButton);
            Global.Add(TraitsPanel);
            Global.Add(OurCity); //Should be some list of all cities TODO

            SwitchToInterface(Interface.Local); //Starting at local interface (can change) - means that any other interfaces are created but deactivated
        }

       /// <summary>
       /// A method used to create all the interfaces of the game
       /// </summary>
        private void CreateInterface()
        {
            //Local Interface
            CreateLocalInterface();
            //Global Interface
            CreateGlobalInterface();
        }

        /// <summary>
        /// Activates 'name' interface and deactivates others. Important note: Firstly deactivating, later activating (for repeating elements)
        /// </summary>
        /// <param name="name">Defines which interface will be active</param>
        private void SwitchToInterface(Interface name)
        {
            localMapChildren = LocalMap.GetComponentsInChildren<SpriteRenderer>(); //Checks whether any new children of local map have been found
            //There should be something like that in global too TODO
            switch (name)
            {
                case Interface.Local:
                    foreach (var item in Global)
                    {       
                        item.SetActive(false); //Produces lags after some time (no idea why). TODO
                    }
                    foreach (var item in Local)
                    {
                        item.SetActive(true);
                    }

                    foreach (SpriteRenderer sr in localMapChildren) //Activating elements of local map
                        sr.enabled = true;
                    LocalMap.GetComponent<SpriteRenderer>().enabled = true; //Activating local map sprite renderer 
                                      
                    GlobalMap.GetComponent<SpriteRenderer>().enabled = false; //Deactivating global map spirte renderer

                    //TODO: Deactivate collider(?) so the local/global map won't be clickable

                    GlobalMapButton.GetComponent<Button>().onClick.AddListener(() => SwitchToInterface(Interface.Global)); //Changing listener of globalmapbutton


                    var globalButton = GlobalMapButton.GetComponent<Button>();
                    globalButton.onClick.AddListener(() => SwitchToInterface(Interface.Global)); //Changing listener of globalmapbutton
                    globalButton.onClick.AddListener(() => { Controllers.CurrentCityController.MapInstance.DisableGrid(); });
                    break;

                case Interface.Global:
                    foreach (var item in Local)
                    {
                        item.SetActive(false);
                    }
                    foreach (var item in Global)
                    {
                        item.SetActive(true);
                    }

                    foreach (SpriteRenderer sr in localMapChildren) //Deactivating elements of local map
                        sr.enabled = false;
                    LocalMap.GetComponent<SpriteRenderer>().enabled = false; //Deactivating local map sprite renderer

                    GlobalMap.GetComponent<SpriteRenderer>().enabled = true; //Activating global map sprite renderer

                    GlobalMapButton.GetComponent<Button>().onClick.AddListener(() => SwitchToInterface(Interface.Local)); //Changing listener of globalmapbutton

                    break;
            }
        }

        /// <summary>
        /// A method used to create elements of the local interface
        /// </summary>
        private void CreateLocalInterface()
        {
            CreateLocalPanels();
            CreateLocalButtons();
            CreateMovingObjects();
        }

        /// <summary>
        /// A method used to create elements of the global interface
        /// </summary>
        private void CreateGlobalInterface()
        {
            CreateGlobalPanels();
            CreateGlobalButtons();
            CreateGlobalMap();
        }

        //Elements of the local interface

        private void CreateMovingObjects() //Just temporary TODO: In another script
        {
            Dude = Instantiate(Prefabs.MovingObject, LocalMap.transform.position, LocalMap.transform.rotation);
            Dude.transform.SetParent(LocalMap.transform, true);

            StartCoroutine(MoveDudes());
        }

        public IEnumerator MoveDudes()
        {
            while (true)
            {
                int x = new System.Random().Next(1, 20); //TODO: Make them move only on the map
                int y = new System.Random().Next(1, 20);
                Vector3 vec = new Vector3(x, y, 0);
                float dist = vec.magnitude;
                float vel = 2; //Some constant velocity
                float time = dist / vel; //This doesn't work as planned
                //TODO: Make them actually move with constant velocity
                //Also they appear to be moving on some line
                iTween.MoveTo(Dude, vec, time);
                yield return new WaitForSeconds(time);
            }
        }

        private void CreateLocalPanels()
        {
            MainPanel = Instantiate(Prefabs.VerticalGroupPanel);
            Util.SetUIObjectPosition(MainPanel, _mainPanelRect, transform);

            MiniMapPanel = Instantiate(Prefabs.Panel);
            Util.SetUIObjectPosition(MiniMapPanel, _miniMapPanelRect, transform);
            
            CreateResourcePanel(); //Instantiated as local elements - then added to global elements list
            PeopleAndMoney();
        }

        private void CreateToggleGridButton()
        {
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

        private void CreateLocalButtons()
        {
            _buttonPanels = new Dictionary<string, ExitablePanel>
            {
                {"Production", CreateExitablePanel(Prefabs.Panel)},
                {"Character", CreateExitablePanel(Prefabs.Panel)},
                {"Diplomacy", CreateExitablePanel(Prefabs.Panel)},
                {"Law", CreateExitablePanel(Prefabs.Panel)},
                {"Science", CreateExitablePanel(Prefabs.VerticalGroupPanel)},
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

            CreateToggleGridButton();

            FillSciencePanel();

            //There is no need for another method for repeating elements. Simply adding element to both lists (firstly it's deactivated and later activated - so no problem here)
            GlobalMapButton = Instantiate(Prefabs.CasualButton);
            Util.SetUIObjectPosition(GlobalMapButton, _globalMapButtonRect, transform);
        }

        //Elements of the global interface

        private void CreateGlobalButtons()
        {

        }

        private void CreateGlobalPanels()
        {
            TraitsPanel = Instantiate(Prefabs.HorizontalGroupPanel);
            Util.SetUIObjectPosition(TraitsPanel, _traitsPanelRect, transform);
        }

        private void CreateGlobalMap()
        {
            //Global map - for now here. Because there is no other script like CityController. TODO
            //Maybe another method?
            var mapPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2));
            mapPosition.z = 0;

            var mapGameObject = Instantiate(Prefabs.Map, mapPosition, transform.rotation) as GameObject;
            GlobalMap = mapGameObject.GetComponent<Map>();
            Util.Rescale(GlobalMap.GetComponent<SpriteRenderer>(), _globalMapSize.X, _globalMapSize.Y);
            GlobalMap.transform.SetParent(transform);
            GlobalMap.name = "GlobalMap";

            //TODO: Change global map sprite
            //GlobalMap.GetComponent<Sprite>() =

            //Cities, maybe another method? TODO
            OurCity = Instantiate(Prefabs.City, GlobalMap.transform.position, GlobalMap.transform.rotation);
            OurCity.transform.SetParent(GlobalMap.transform, true);
        }

        //Other methods

        private ExitablePanel CreateExitablePanel(GameObject child)
        {
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

        private void FillSciencePanel()
        {
            var sciencePanel = _buttonPanels["Science"];
            sciencePanel.Content.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            foreach (var branch in Controllers.Science.Branches)
            {
                var button = Instantiate(Prefabs.Toggle);
                button.transform.SetParent(sciencePanel.Content.transform);
                button.GetComponentInChildren<Text>().text = branch.name;

                var toggle = button.GetComponent<Toggle>();
                toggle.onValueChanged.AddListener((value => branch.setFinanced(value)));
            }
        }

        private void PeopleAndMoney()
        {
            PeopleAndMoneyPanel = Instantiate(Prefabs.VerticalGroupPanel);
            Util.SetUIObjectPosition(PeopleAndMoneyPanel, _peopleMoneyRect, transform);

            var people = Instantiate(Prefabs.ResourceIndicator);
            var peopleData = people.GetComponent<ResourceData>();
            peopleData.PopulationRef = Controllers.CurrentInfo.ThePeople;
            people.transform.SetParent(PeopleAndMoneyPanel.transform);
            people.GetComponentInChildren<Image>().sprite = Sprites.SpecialResourceSprite(typeof(Population));
            var rt = (RectTransform) people.transform;
            rt.sizeDelta = new Vector2(0, 0);

            var money = Instantiate(Prefabs.ResourceIndicator);
            var moneyData = money.GetComponent<ResourceData>();
            moneyData.MoneyRef = Controllers.CurrentInfo.MyMoney;
            money.transform.SetParent(PeopleAndMoneyPanel.transform);
            money.GetComponentInChildren<Image>().sprite = Sprites.SpecialResourceSprite(typeof(Money));
            rt = (RectTransform) money.transform;
            rt.sizeDelta = new Vector2(0, 0);
        }
    }
}