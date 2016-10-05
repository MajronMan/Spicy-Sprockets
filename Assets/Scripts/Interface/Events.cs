using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Events : MonoBehaviour {

    private const int LayerUI = 5;
    public GameObject canvasObject;
    //private int nextevent;
    //public GameObject EventPanel;

    void Start ()
    {
        //System.Random rnd = new System.Random();
        //nextevent = rnd.Next(60, 120);
        StartCoroutine("GetEvent");
    }

    public IEnumerator GetEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(new System.Random().Next(1, 5));
            Event();
        }
    }
	
	void Update ()
    {

       /* if ((int)Time.time == nextevent)
        {
            System.Random rnd = new System.Random();
            int period = rnd.Next(60, 120);
            nextevent = (int)Time.time + period;
            Event();
        }
        */
    }
    void Event()
    {
        //var eventGameObject = new GameObject("Event", typeof(Sprite));
        //eventGameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(650, 280, 50));

        var eventGameObject = new GameObject("Panel");
        eventGameObject.transform.SetParent(canvasObject.transform);
        eventGameObject.layer = LayerUI;

        RectTransform trans = eventGameObject.AddComponent<RectTransform>();
        trans.anchorMin = new Vector2(0, 0);
        trans.anchorMax = new Vector2(1, 1);
        trans.anchoredPosition3D = new Vector3(0, 0, 0);
        trans.anchoredPosition = new Vector2(0, 0);
        trans.offsetMin = new Vector2(0, 0);
        trans.offsetMax = new Vector2(0, 0);
        trans.localPosition = new Vector3(0, 0, 0);
        trans.sizeDelta = new Vector2(0, 0);
        trans.localScale = new Vector3(0.4f, 0.4f, 1.0f);
        eventGameObject.AddComponent<CanvasRenderer>();

        Image i = eventGameObject.AddComponent<Image>();
        i.color = Color.cyan;

        eventGameObject.GetComponent<Image> ().sprite = Resources.Load("Panel", typeof(Sprite)) as Sprite;
    }
}
