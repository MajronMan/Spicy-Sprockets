
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
        public Money MoneyRef;
        public PopulationManager PopulationRef;

        public void Start ()
        {
            ResourceText = GetComponentInChildren<Text>();
            if (MoneyRef != null)
            {
                Controllers.CurrentInfo.MoneyChanged +=
                    (sender, args) => ResourceText.text = MoneyRef.Amount.ToString();
                ResourceText.text = MoneyRef.Amount.ToString();
            }
            else if (PopulationRef != null)
            {
                PopulationRef.Changed +=
                    (sender, args) => ResourceText.text = PopulationRef.Amount.ToString();
                ResourceText.text = PopulationRef.Amount.ToString();
            }
            else
            {
                Controllers.CurrentInfo.Changed += 
                    (sender, args) => ResourceText.text = Controllers.CurrentInfo[Type].Amount.ToString();
                ResourceText.text = Controllers.CurrentInfo[Type].Amount.ToString();
            }
        }

    }
}
