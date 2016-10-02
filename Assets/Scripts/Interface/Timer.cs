using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float seconds, minutes, hours;
    private int nextevent;

    void Start()
    {
        timerText = GetComponent<Text>() as Text;
        System.Random rnd = new System.Random();
        nextevent = rnd.Next(60, 120);
    }
    void Update()
    {
        hours = (int)(Time.time / 3600f);
        minutes = (int)((Time.time / 60f) % 60);
        seconds = (int)(Time.time % 60f);

        if((int) Time.time == nextevent)
        {
            System.Random rnd = new System.Random();
            int period = rnd.Next(60, 120);
            nextevent = (int) Time.time + period;
            Events();
        }

        timerText.text = hours.ToString() + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    void Events()
    {

    }
}
