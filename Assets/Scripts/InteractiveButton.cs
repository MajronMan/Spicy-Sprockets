using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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

    private GameObject myPanel;
    private Transform myButton;
    private List<GameObject> panelList;
    private bool clicked = false;

    void Start ()
    {
        string name = gameObject.transform.name;
        panelList = new List<GameObject>();

        panelList.Add(buildPanel);
        panelList.Add(productionPanel);
        panelList.Add(diplomacyPanel);
        panelList.Add(sciencePanel);
        panelList.Add(lawPanel);
        panelList.Add(characterPanel);

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
    }

    public void Clicked()
    {
        if (!clicked)
        {
            clicked = true;
            ClosePanels();
            myPanel.SetActive(true);
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

    }

    private void EnableButtons()
    {

    }
}
