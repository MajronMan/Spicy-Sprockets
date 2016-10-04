using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {

    private int nextevent;
    public GameObject EventPanel;

    void Start ()
    {
        System.Random rnd = new System.Random();
        nextevent = rnd.Next(60, 120);
    }
	
	void Update ()
    {

        if ((int)Time.time == nextevent)
        {
            System.Random rnd = new System.Random();
            int period = rnd.Next(60, 120);
            nextevent = (int)Time.time + period;
            Event();
        }
    }
    void Event()
    {
        EventPanel.SetActive(true);
    }
}
