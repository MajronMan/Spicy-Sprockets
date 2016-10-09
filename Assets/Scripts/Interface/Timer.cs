using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class Timer : MonoBehaviour {

        public Text TimerText;
        private float _seconds, _minutes, _hours;

        public void Start()
        {
            TimerText = GetComponent<Text>() as Text;
        }
        public void Update()
        {
            _hours = (int)(Time.time / 3600f);
            _minutes = (int)((Time.time / 60f) % 60);
            _seconds = (int)(Time.time % 60f);

            TimerText.text = _hours.ToString() + ":" + _minutes.ToString("00") + ":" + _seconds.ToString("00");
        }
    }
}
