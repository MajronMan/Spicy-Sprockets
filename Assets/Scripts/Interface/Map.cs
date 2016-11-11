using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Sources_of_Resources;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class Map : MonoBehaviour
    {
        public List<Source> Sources = new List<Source>();

        public void Start ()
        {
            Physics.queriesHitTriggers = true;
        }

        public void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Controllers.CurrentGameMode.LeftMouseClicked();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Controllers.CurrentGameMode.RightMouseClicked();
            }  
        }

        public void OnMouseOver()
        {
            //just a hook
        }
    }
}
