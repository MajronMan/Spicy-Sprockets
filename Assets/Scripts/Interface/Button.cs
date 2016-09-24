using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour
{
    public bool anyButtonActive = false;
    public bool thisButtonActive = false;
    public GameObject panel;

    void Start()
    {

    }

    public void thisClicked()
    {
        if(anyButtonActive == false)
        {
            thisButtonActive = true;
            panel.SetActive(true);
        }
        else if(thisButtonActive == true)
        {
            thisButtonActive = false;
            panel.SetActive(false);

        }
    }

    public void otherClicked()
    {
        if (thisButtonActive == false)
            anyButtonActive = true;
    }

}
