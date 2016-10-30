using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlideValue : MonoBehaviour {

    private GameObject Slider;
    public Text value;

    public void Start()
    {
        Slider = GameObject.Find("TradePanel/Slider");
    }

    public void Slide()
    {
        value.text = Slider.GetComponent<Slider>().value.ToString();
    }
}
