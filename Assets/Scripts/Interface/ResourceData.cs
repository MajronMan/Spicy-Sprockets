using System;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface {
    /// <summary>
    /// Controls the numbers on resource panel in the bottom of the screen
    /// </summary>
    public class ResourceData : MonoBehaviour {
        public Text ResourceText;
        public ICountable Resource;

        public void Start() {
            ResourceText = GetComponent<Text>();
        }

//        public void Update() {
//            //show current value
//            try {
//                ResourceText.text = Resource.Amount.ToString();
//            } catch (Exception e) {
//                Debug.Log(e.Message);
//                Debug.Log(e.InnerException);
//                ResourceText.text = "dupa";
//            }
//        }
    }
}