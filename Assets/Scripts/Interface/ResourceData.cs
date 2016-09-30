using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameControllers;
using System;

public class ResourceData : MonoBehaviour {
	public Text ResourceText;
    public GameController gameController;
	public string type;
	// Use this for initialization
	void Start () {
		ResourceText = GetComponent<Text>() as Text;
	}
	
	void Update () {
		try{
		ResourceText.text = gameController.GetCurrentCity().info.Resources [type].GetQuantity ().ToString ();
		}
		catch(NullReferenceException e){
			ResourceText.text = "dupa";
		}
	}

}
