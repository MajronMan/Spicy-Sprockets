using System;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class GlobalInterface : MonoBehaviour
    {
        public GameObject CustomPanel;
        private Rect _customPanelRect = new Rect(0, 0, 1.0f, 0.05f);
/*
        private string[] _mainButtons =
        {
            "Production",
            "Character",
            "Diplomacy",
            "Law",
            "Science",
            "Build",
            "Trade"
        };
*/
        public void Start()
        {
            CreatePanels();
            //CreateButtons();
        }


        private void CreatePanels()
        {
            CustomPanel = Instantiate(Prefabs.HorizontalGroupPanel);
            SetObjectPosition(CustomPanel, _customPanelRect);
        }

        private void SetObjectPosition(GameObject what, Rect how)
        {
            var rectTransform = what.GetComponent<RectTransform>();
            rectTransform.SetParent(this.gameObject.transform);
            rectTransform.anchorMax = how.position + new Vector2(how.width, how.height);
            rectTransform.anchorMin = how.position;
            rectTransform.offsetMax = rectTransform.offsetMin = Vector2.zero;
        }
        /*
        private void CreateButtons()
        {
            foreach (var buttonName in _mainButtons)
            {
                var buttonGameObject = Instantiate(Prefabs.CogwheelButton);
                buttonGameObject.name = buttonName + "Button";
                buttonGameObject.transform.SetParent(MainPanel.transform);
                AddNotRotatingTextToButton(buttonGameObject, buttonName);
            }
            var globalMapButton = Instantiate(Prefabs.CasualButton);
            Vector2 A = new Vector2(globalMapButton.GetComponent<Image>().sprite.bounds.size.x / Screen.width * 15, globalMapButton.GetComponent<Image>().sprite.bounds.size.y / Screen.height * 15);
            Rect _globalMapButtonRect = new Rect(0.02f, 0.9f, A.x, A.y);
            globalMapButton.transform.SetParent(this.gameObject.transform);
            SetPanelPosition(globalMapButton, _globalMapButtonRect);
        }
        */
    }
}
