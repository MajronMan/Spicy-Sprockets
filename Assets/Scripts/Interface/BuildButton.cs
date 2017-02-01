using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Game_Controllers;
using Assets.Static;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class BuildButton: Button
    {
        private Type _myType;
        private GameObject _myPanel;

        public void SetUp(Type type, GameObject myPanel)
        {
            _myType = type;
            _myPanel = myPanel;
            GetComponent<Image>().sprite = Sprites.BuildingSprite(type);
            onClick.AddListener(() =>
            {
                Controllers.GameController.EnterBuildingMode(type);
                _myPanel.SetActive(false);
            });

        }
    }
}
