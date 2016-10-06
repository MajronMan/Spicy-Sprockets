using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

public class Events : MonoBehaviour {

    private const int LayerUI = 5;
    public GameObject canvasObject;
    private bool ActiveEvent = false;
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
            if (ActiveEvent == false)
            {
                Event();
            }
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

        var eventGameObject = new GameObject("EventPanel"); //New event panel
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
        trans.localScale = new Vector3(0.4f, 0.8f, 1.0f);
        eventGameObject.AddComponent<CanvasRenderer>();

        Image i = eventGameObject.AddComponent<Image>();
        i.color = Color.cyan;

        string spriteFilePath = "Assets/Graphics/Interface graphics&textures/Panel.png";
        eventGameObject.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteFilePath);

        ActiveEvent = true;

        var eventButton = new GameObject("EventButton"); //New event button
        eventButton.transform.SetParent(eventGameObject.transform);
        eventButton.layer = LayerUI;

        RectTransform buttontrans = eventButton.AddComponent<RectTransform>();
        buttontrans.anchorMin = new Vector2(0, 0);
        buttontrans.anchorMax = new Vector2(1, 1);
        buttontrans.anchoredPosition3D = new Vector3(0, 0, 0);
        buttontrans.anchoredPosition = new Vector2(0, 0);
        buttontrans.offsetMin = new Vector2(0, 0);
        buttontrans.offsetMax = new Vector2(0, 0);
        buttontrans.localPosition = new Vector3(0, -200, 0);
        buttontrans.sizeDelta = new Vector2(0, 0);
        buttontrans.localScale = new Vector3(0.2f, 0.1f, 0);
        eventButton.AddComponent<CanvasRenderer>();
        eventButton.AddComponent<Image>();
        eventButton.AddComponent<Button>();

        string buttonFilePath = "Assets/Graphics/Interface graphics&textures/Trybik.png";
        eventButton.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(buttonFilePath);
        eventButton.GetComponent<Image>().preserveAspect = true;

        eventButton.GetComponent<Button>().onClick.AddListener(() => { Destroy(eventGameObject); SetEventFalse(); });

        var eventText = new GameObject("EventText"); //New event text
        eventText.transform.SetParent(eventGameObject.transform);
        eventText.layer = LayerUI;

        RectTransform texttrans = eventText.AddComponent<RectTransform>();
        texttrans.anchorMin = new Vector2(0, 0);
        texttrans.anchorMax = new Vector2(1, 1);
        texttrans.anchoredPosition3D = new Vector3(0, 0, 0);
        texttrans.anchoredPosition = new Vector2(0, 0);
        texttrans.offsetMin = new Vector2(0, 0);
        texttrans.offsetMax = new Vector2(0, 0);
        texttrans.localPosition = new Vector3(0, -65, 0);
        texttrans.sizeDelta = new Vector2(0, 0);
        texttrans.localScale = new Vector3(0.85f, 0.3f, 0);
        eventText.AddComponent<CanvasRenderer>();
        eventText.AddComponent<Text>();

        eventText.GetComponent<Text>().text = "Zrób tutorial do gita ;_;";
        eventText.GetComponent<Text>().font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Data/Fonts/utsaah.ttf");
        eventText.GetComponent<Text>().fontSize = 130;

        var eventImage = new GameObject("EventImage"); //New event image
        eventImage.transform.SetParent(eventGameObject.transform);
        eventImage.layer = LayerUI;

        RectTransform imagetrans = eventImage.AddComponent<RectTransform>();
        imagetrans.anchorMin = new Vector2(0, 0);
        imagetrans.anchorMax = new Vector2(1, 1);
        imagetrans.anchoredPosition3D = new Vector3(0, 0, 0);
        imagetrans.anchoredPosition = new Vector2(0, 0);
        imagetrans.offsetMin = new Vector2(0, 0);
        imagetrans.offsetMax = new Vector2(0, 0);
        imagetrans.localPosition = new Vector3(0, 165, 0);
        imagetrans.sizeDelta = new Vector2(0, 0);
        imagetrans.localScale = new Vector3(0.85f, 0.4f, 0);
        eventImage.AddComponent<CanvasRenderer>();
        eventImage.AddComponent<Image>();

        string eventimageFilePath = "Assets/Graphics/Interface graphics&textures/Event.png";
        eventImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(eventimageFilePath);

    }

    void SetEventFalse()
    {
        ActiveEvent = false;
    }

}
