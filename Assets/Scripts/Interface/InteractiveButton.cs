using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Interface {
    public class InteractiveButton : MonoBehaviour {
        //TODO fukin' generate'em, 10^6 references are not what we want
        public GameObject UI;

        private Transform _buildButton;
        private Transform _productionButton;
        private Transform _diplomacyButton;
        private Transform _scienceButton;
        private Transform _lawButton;
        private Transform _characterButton;
        private Transform _tradeButton;

        private GameObject _buildPanel;
        private GameObject _productionPanel;
        private GameObject _diplomacyPanel;
        private GameObject _sciencePanel;
        private GameObject _lawPanel;
        private GameObject _characterPanel;
        private GameObject _tradePanel;

        private Transform _systemButton;
        private Transform _toggleMapButton;
        private Transform _res1;
        private Transform _res2;
        private Transform _res3;
        private Transform _res4;
        private Transform _res5;
        private Transform _res6;
        private Transform _infoButton;

        private GameObject _myPanel;
        private Transform _myButton;
        private List<GameObject> _panelList;
        private bool _clicked = false;
        private bool _buttonsDisabled = false;

        // Needs big refactor
        public void Start() {
            UI = GameObject.Find("UI").gameObject;
            _buildButton = UI.transform.Find("MainPanel/Buttons/BuildButton");
            _productionButton = UI.transform.Find("MainPanel/Buttons/ProductionButton");
            _diplomacyButton = UI.transform.Find("MainPanel/Buttons/DiplomacyButton");
            _scienceButton = UI.transform.Find("MainPanel/Buttons/ScienceButton");
            _lawButton = UI.transform.Find("MainPanel/Buttons/LawButton");
            _characterButton = UI.transform.Find("MainPanel/Buttons/CharacterButton");
            _tradeButton = UI.transform.Find("MainPanel/Buttons/TradeButton");


            _buildPanel = UI.transform.Find("ButtonPanels/BuildPanel").gameObject;
            _productionPanel = UI.transform.Find("ButtonPanels/ProductionPanel").gameObject;
            _diplomacyPanel = UI.transform.Find("ButtonPanels/DiplomacyPanel").gameObject;
            _sciencePanel = UI.transform.Find("ButtonPanels/SciencePanel").gameObject;
            _lawPanel = UI.transform.Find("ButtonPanels/LawPanel").gameObject;
            _characterPanel = UI.transform.Find("ButtonPanels/CharacterPanel").gameObject;
            _tradePanel = UI.transform.Find("ButtonPanels/TradePanel").gameObject;

            _panelList = new List<GameObject> {
                _buildPanel,
                _productionPanel,
                _diplomacyPanel,
                _sciencePanel,
                _lawPanel,
                _characterPanel,
                _tradePanel
            };


            string name = gameObject.transform.name;

            switch (name) {
                case "BuildButton":
                    _myPanel = _buildPanel;
                    _myButton = _buildButton;
                    break;
                case "ProductionButton":
                    _myPanel = _productionPanel;
                    _myButton = _productionButton;
                    break;
                case "DiplomacyButton":
                    _myPanel = _diplomacyPanel;
                    _myButton = _diplomacyButton;
                    break;
                case "ScienceButton":
                    _myPanel = _sciencePanel;
                    _myButton = _scienceButton;
                    break;
                case "LawButton":
                    _myPanel = _lawPanel;
                    _myButton = _lawButton;
                    break;
                case "CharacterButton":
                    _myPanel = _characterPanel;
                    _myButton = _characterButton;
                    break;
                case "TradeButton":
                    _myPanel = _tradePanel;
                    _myButton = _tradeButton;
                    break;
                default:
                    Debug.Log("Button not added!");
                    break;
            }

            _systemButton = UI.transform.Find("SystemButton");
            _toggleMapButton = UI.transform.Find("ToggleMapButton");
            _res1 = UI.transform.Find("StoragePanel/Images/Image");
            _res2 = UI.transform.Find("StoragePanel/Images/Image (1)");
            _res3 = UI.transform.Find("StoragePanel/Images/Image (2)");
            _res4 = UI.transform.Find("StoragePanel/Images/Image (3)");
            _res5 = UI.transform.Find("StoragePanel/Images/Image (4)");
            _res6 = UI.transform.Find("StoragePanel/Images/Image (5)");
            _infoButton = UI.transform.Find("InfoButton");
        }

        public void Update() {
            if (_clicked && _myPanel.activeSelf == false)
                _clicked = false;
            if (!_buttonsDisabled || _clicked) return;
            EnableButtons();
            _buttonsDisabled = false;
        }

        public void Clicked() {
            StartCoroutine(Clicker());
        }

        public IEnumerator Clicker() {
            if (!_clicked) {
                _clicked = true;
                ClosePanels();
                _myPanel.SetActive(true);
                yield return null;
                DisableButtons();
            } else {
                _clicked = false;
                _myPanel.SetActive(false);
                EnableButtons();
            }
        }

        private void ClosePanels() {
            foreach (var panel in _panelList)
                panel.SetActive(false);
        }

        private void DisableButtons() {
            _buttonsDisabled = true;

            _systemButton.GetComponent<Toggle>().interactable = false;
            _toggleMapButton.GetComponent<Toggle>().interactable = false;
            _infoButton.GetComponent<Toggle>().interactable = false;
            _res1.GetComponent<EventTrigger>().enabled = false;
            _res2.GetComponent<EventTrigger>().enabled = false;
            _res3.GetComponent<EventTrigger>().enabled = false;
            _res4.GetComponent<EventTrigger>().enabled = false;
            _res5.GetComponent<EventTrigger>().enabled = false;
            _res6.GetComponent<EventTrigger>().enabled = false;
        }

        private void EnableButtons() {
            _buttonsDisabled = false;

            _systemButton.GetComponent<Toggle>().interactable = true;
            _toggleMapButton.GetComponent<Toggle>().interactable = true;
            _infoButton.GetComponent<Toggle>().interactable = true;
            _res1.GetComponent<EventTrigger>().enabled = true;
            _res2.GetComponent<EventTrigger>().enabled = true;
            _res3.GetComponent<EventTrigger>().enabled = true;
            _res4.GetComponent<EventTrigger>().enabled = true;
            _res5.GetComponent<EventTrigger>().enabled = true;
            _res6.GetComponent<EventTrigger>().enabled = true;
        }
    }
}