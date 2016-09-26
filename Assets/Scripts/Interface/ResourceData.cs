using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameControllers;
using System;

public class ResourceData : MonoBehaviour {
	public Text ResourceText;
	public CityController cityController;
	public string type;
	// Use this for initialization
	void Start () {
		ResourceText = GetComponent<Text>() as Text;
		cityController = GameObject.Find ("Game Controller").GetComponent<GameController> ().GetCurrentCity ();
	}
	
	// Update is called once per frame
	void Update () {
		//just shut up, make it work later
		try{
		ResourceText.text = cityController.info.Resources [type].GetQuantity ().ToString ();
		}
		catch(NullReferenceException e){
			ResourceText.text = "dupa";
		}
	}

}
