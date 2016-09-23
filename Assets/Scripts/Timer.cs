using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float seconds, minutes, hours;

    void Start()
    {
        timerText = GetComponent<Text>() as Text;
    }
    void Update()
    {
        hours = (int)(Time.time / 3600f);
        minutes = (int)((Time.time / 60f) % 60);
        seconds = (int)(Time.time % 60f);

        timerText.text = hours.ToString() + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
