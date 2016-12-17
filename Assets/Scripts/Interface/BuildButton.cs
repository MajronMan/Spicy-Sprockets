using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Game_Controllers;
using Assets.Static;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class BuildButton: Button
    {
        private Type myType;

        public void SetType(Type type)
        {
            myType = type;
            GetComponent<Image>().sprite = Sprites.BuildingSprite(type);
            onClick.AddListener(() => Controllers.GameController.EnterBuildingMode(type));
        }
    }
}
