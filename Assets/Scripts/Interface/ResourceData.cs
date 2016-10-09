using System;
using Assets.Scripts.Game_Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class ResourceData : MonoBehaviour {
        public Text ResourceText;
        public string Type;
        
        public void Start ()
        {
            ResourceText = GetComponent<Text>() as Text;
        }
	
        public void Update () {
            try{
                ResourceText.text = Controllers.CurrentInfo[Type].GetQuantity ().ToString ();
            }
            catch(Exception e){
                Debug.Log(e.Message + " " + e.StackTrace);
                ResourceText.text = "dupa";
            }
        }

    }
}
