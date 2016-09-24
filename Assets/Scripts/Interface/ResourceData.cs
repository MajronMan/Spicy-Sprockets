using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceData : MonoBehaviour {
	public Text ResourceText;
	public StrategyManager strategyManager;
	public string type;
	// Use this for initialization
	void Start () {
		ResourceText = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update () {
		ResourceText.text = strategyManager.info.Resources [type].GetQuantity ().ToString ();
	}
}
