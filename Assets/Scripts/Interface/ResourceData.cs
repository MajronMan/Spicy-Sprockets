using System;
using Assets.Scripts.Game_Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface {
    /// <summary>
    /// Controls the numbers on resource panel in the bottom of the screen
    /// </summary>
    public class ResourceData : MonoBehaviour {
        public Text ResourceText;
        public string Type;

        public void Start() {
            ResourceText = GetComponent<Text>();
        }

        public void Update() {
            //show current value
            try {
                switch (Type) {
                    case "people":
                        ResourceText.text = Controllers.CurrentInfo.ThePeople.Number.ToString();
                        break;
                    case "money":
                        ResourceText.text = Controllers.CurrentInfo.MyMoney.GetAmount().ToString();
                        break;
                    default:
                        ResourceText.text = Controllers.CurrentInfo[Type].GetQuantity().ToString();
                        break;
                }
            } catch (Exception e) {
                Debug.Log(e.Message);
                Debug.Log(e.InnerException);
                ResourceText.text = "dupa";
            }
        }
    }
}