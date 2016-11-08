using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

/// <summary>
/// Creates random game events
/// </summary>
public class Events : MonoBehaviour {

    public GameObject Content;
    private bool ActiveEvent = false;
    public GameObject eventPrefab;
    public GameObject eventbuttonPrefab;

    void Start ()
    {
        StartCoroutine("GetEvent");
    }

    /// <summary>
    /// Uses Event() method after random amount of time
    /// </summary>
    public IEnumerator GetEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(new System.Random().Next(60, 120));
            if (ActiveEvent == false)
            {
                Event();
            }
        }
    }

    /// <summary>
    /// A method used to create new event panel from a prefab
    /// </summary>
    void Event()
    {
        ActiveEvent = true; //Prevents from opening new event when other is active

        GameObject EventInstance = Instantiate(eventPrefab) as GameObject; //New instance of event panel
        EventInstance.transform.SetParent(transform, false); //Somehow it sets prefab position where it used to be when it was GameObject
        EventInstance.name = "EventPanel";

        //TODO: Here there would be reading information from a file and loading it into panel elements like text, title and image

        //TODO: Here there would be reading button options from file and also creating earlier defined amount of options
        //for(int i=1, i<=options i++){}
        GameObject OptionInstance = Instantiate(eventbuttonPrefab) as GameObject; //New instance of event option button
        OptionInstance.transform.SetParent(EventInstance.transform.Find("Options"), false);
        OptionInstance.name = "Option";
        OptionInstance.GetComponent<Button>().onClick.AddListener(() => { Destroy(EventInstance); SetEventFalse(); }); //On click function which closes event for now

        News();
    }

    /// <summary>
    /// A method used to save last events to the newspaper in the info panel
    /// </summary>
    void News() //It's just a stub
    {
        GameObject NewsInstance = Instantiate(eventPrefab) as GameObject;
        NewsInstance.transform.SetParent(Content.transform, false);
        NewsInstance.name = "News";
    }
    /// <summary>
    /// Used in onClick function, permits to open new event
    /// </summary>
    void SetEventFalse()
    {
        ActiveEvent = false;
    }

}
