using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class InteractiveButton : MonoBehaviour
{
    public Transform buildButton;
    public Transform productionButton;
    public Transform diplomacyButton;
    public Transform scienceButton;
    public Transform lawButton;
    public Transform characterButton;

    public GameObject buildPanel;
    public GameObject productionPanel;
    public GameObject diplomacyPanel;
    public GameObject sciencePanel;
    public GameObject lawPanel;
    public GameObject characterPanel;

    public Transform systemButton;
    public Transform toggleMapButton;
    public Transform res1;
    public Transform res2;
    public Transform res3;
    public Transform res4;
    public Transform res5;
    public Transform res6;
    public Transform infoButton;

    private GameObject myPanel;
    private Transform myButton;
    private List<GameObject> panelList;
    private bool clicked = false;
    private bool buttonsDisabled = false;

    void Start ()
    {
        panelList = new List<GameObject>();

        panelList.Add(buildPanel);
        panelList.Add(productionPanel);
        panelList.Add(diplomacyPanel);
        panelList.Add(sciencePanel);
        panelList.Add(lawPanel);
        panelList.Add(characterPanel);

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
            default:
                Debug.Log("Button not added!");
                break;
        }
    }
	
	void Update ()
    {
        if (clicked && myPanel.activeSelf == false)
            clicked = false;
        if (buttonsDisabled && !clicked)
        {
            EnableButtons();
            buttonsDisabled = false;
        }
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
        for (int i = 0; i < panelList.Count; i++)
            panelList[i].SetActive(false);
    }

    private void DisableButtons()
    {
        buttonsDisabled = true;

        systemButton.GetComponent<Toggle>().interactable = false;
        toggleMapButton.GetComponent<Toggle>().interactable = false;
        infoButton.GetComponent<Button>().interactable = false;
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
        infoButton.GetComponent<Button>().interactable = true;
        res1.GetComponent<EventTrigger>().enabled = true;
        res2.GetComponent<EventTrigger>().enabled = true;
        res3.GetComponent<EventTrigger>().enabled = true;
        res4.GetComponent<EventTrigger>().enabled = true;
        res5.GetComponent<EventTrigger>().enabled = true;
        res6.GetComponent<EventTrigger>().enabled = true;
    }
}
