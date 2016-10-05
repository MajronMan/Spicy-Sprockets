using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {

    private int nextevent;
    public GameObject EventPanel;

    void Start ()
    {
        System.Random rnd = new System.Random();
        nextevent = rnd.Next(60, 120);
        StartCoroutine("GetEvent");
    }

    public IEnumerator GetEvent()
    {
        while (true)
        {
            Event();
            yield return new WaitForSeconds(new System.Random().Next(60, 120));
        }
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
        var eventGameObject = new GameObject("Event", typeof(Sprite));
        eventGameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(50, 50, 50));
    }
}
