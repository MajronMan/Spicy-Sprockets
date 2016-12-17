
using System;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    /// <summary>
    /// Controls the numbers on resource panel in the bottom of the screen
    /// </summary>
    public class ResourceData : MonoBehaviour {
        public Text ResourceText;
        public Text MaxText;
        public ResourceType Type;
        
        public void Start ()
        {
            ResourceText = GetComponent<Text>();
            Controllers.CurrentInfo.Changed += (sender, args) => { Debug.Log(Type); };
        }

    }
}
