using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class InteractiveButton : MonoBehaviour
    {
        //TODO fukin' generate'em, 10^6 references are not what we want
        public GameObject UI;

        private Transform buildButton;
        private Transform productionButton;
        private Transform diplomacyButton;
        private Transform scienceButton;
        private Transform lawButton;
        private Transform characterButton;
        private Transform tradeButton;

        private GameObject buildPanel;
        private GameObject productionPanel;
        private GameObject diplomacyPanel;
        private GameObject sciencePanel;
        private GameObject lawPanel;
        private GameObject characterPanel;
        private GameObject tradePanel;

        private Transform systemButton;
        private Transform toggleMapButton;
        private Transform res1;
        private Transform res2;
        private Transform res3;
        private Transform res4;
        private Transform res5;
        private Transform res6;
        private Transform infoButton;

        private GameObject myPanel;
        private Transform myButton;
        private List<GameObject> panelList;
        private bool clicked = false;
        private bool buttonsDisabled = false;

        // Needs big refactor
        public void Start()
        {
            UI = GameObject.Find("UI").gameObject;
            buildButton = UI.transform.Find("MainPanel/Buttons/BuildButton");
            productionButton = UI.transform.Find("MainPanel/Buttons/ProductionButton");
            diplomacyButton = UI.transform.Find("MainPanel/Buttons/DiplomacyButton");
            scienceButton = UI.transform.Find("MainPanel/Buttons/ScienceButton");
            lawButton = UI.transform.Find("MainPanel/Buttons/LawButton");
            characterButton = UI.transform.Find("MainPanel/Buttons/CharacterButton");
            tradeButton = UI.transform.Find("MainPanel/Buttons/TradeButton");


            buildPanel = UI.transform.Find("ButtonPanels/BuildPanel").gameObject;
            productionPanel = UI.transform.Find("ButtonPanels/ProductionPanel").gameObject;
            diplomacyPanel = UI.transform.Find("ButtonPanels/DiplomacyPanel").gameObject;
            sciencePanel = UI.transform.Find("ButtonPanels/SciencePanel").gameObject;
            lawPanel = UI.transform.Find("ButtonPanels/LawPanel").gameObject;
            characterPanel = UI.transform.Find("ButtonPanels/CharacterPanel").gameObject;
            tradePanel = UI.transform.Find("ButtonPanels/TradePanel").gameObject;

            panelList = new List<GameObject>();

            panelList.Add(buildPanel);
            panelList.Add(productionPanel);
            panelList.Add(diplomacyPanel);
            panelList.Add(sciencePanel);
            panelList.Add(lawPanel);
            panelList.Add(characterPanel);
            panelList.Add(tradePanel);

            string name = gameObject.transform.name;

            switch (name)
            {
                case "BuildButton":
                    myPanel = buildPanel;
                    myButton = buildButton;
                    break;
                case "ProductionButton":
                    myPanel = productionPanel;
                    myButton = productionButton;
                    break;
                case "DiplomacyButton":
                    myPanel = diplomacyPanel;
                    myButton = diplomacyButton;
                    break;
                case "ScienceButton":
                    myPanel = sciencePanel;
                    myButton = scienceButton;
                    break;
                case "LawButton":
                    myPanel = lawPanel;
                    myButton = lawButton;
                    break;
                case "CharacterButton":
                    myPanel = characterPanel;
                    myButton = characterButton;
                    break;
                case "TradeButton":
                    myPanel = tradePanel;
                    myButton = tradeButton;
                    break;
                default:
                    Debug.Log("Button not added!");
                    break;
            }

            systemButton = UI.transform.Find("SystemButton");
            toggleMapButton = UI.transform.Find("ToggleMapButton");
            res1 = UI.transform.Find("StoragePanel/Images/Image");
            res2 = UI.transform.Find("StoragePanel/Images/Image (1)");
            res3 = UI.transform.Find("StoragePanel/Images/Image (2)");
            res4 = UI.transform.Find("StoragePanel/Images/Image (3)");
            res5 = UI.transform.Find("StoragePanel/Images/Image (4)");
            res6 = UI.transform.Find("StoragePanel/Images/Image (5)");
            infoButton = UI.transform.Find("InfoButton");
        }

        public void Update()
        {
            if (clicked && myPanel.activeSelf == false)
                clicked = false;
            if (!buttonsDisabled || clicked) return;
            EnableButtons();
            buttonsDisabled = false;
        }

        public void Clicked()
        {
            StartCoroutine("Clicker");
        }

        public IEnumerator Clicker()
        {
            if (!clicked)
            {
                clicked = true;
                ClosePanels();
                myPanel.SetActive(true);
                yield return null;
                DisableButtons();
            }
            else
            {
                clicked = false;
                myPanel.SetActive(false);
                EnableButtons();
            }
        }

        private void ClosePanels()
        {
            foreach (var panel in panelList)
                panel.SetActive(false);
        }

        private void DisableButtons()
        {
            buttonsDisabled = true;

            systemButton.GetComponent<Toggle>().interactable = false;
            toggleMapButton.GetComponent<Toggle>().interactable = false;
            infoButton.GetComponent<Toggle>().interactable = false;
            res1.GetComponent<EventTrigger>().enabled = false;
            res2.GetComponent<EventTrigger>().enabled = false;
            res3.GetComponent<EventTrigger>().enabled = false;
            res4.GetComponent<EventTrigger>().enabled = false;
            res5.GetComponent<EventTrigger>().enabled = false;
            res6.GetComponent<EventTrigger>().enabled = false;
        }

        private void EnableButtons()
        {
            buttonsDisabled = false;

            systemButton.GetComponent<Toggle>().interactable = true;
            toggleMapButton.GetComponent<Toggle>().interactable = true;
            infoButton.GetComponent<Toggle>().interactable = true;
            res1.GetComponent<EventTrigger>().enabled = true;
            res2.GetComponent<EventTrigger>().enabled = true;
            res3.GetComponent<EventTrigger>().enabled = true;
            res4.GetComponent<EventTrigger>().enabled = true;
            res5.GetComponent<EventTrigger>().enabled = true;
            res6.GetComponent<EventTrigger>().enabled = true;
        }
    }
}