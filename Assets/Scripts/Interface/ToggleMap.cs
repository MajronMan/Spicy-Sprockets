using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    /// <summary>
    /// Class made to switch between maps
    /// </summary>
    public class ToggleMap : MonoBehaviour
    {
        /// <summary>
        /// Game object representing local map
        /// </summary>
        private GameObject LocalMap;
        /// <summary>
        /// Game object representing global map
        /// </summary>
        public GameObject GlobalMap; //For now it's just a picture

        /// <summary>
        /// A method used to toggle between local and global map
        /// </summary>
        public void Toggle()
        {
            LocalMap = Controllers.CurrentCityController.MapInstance.gameObject;
            bool globalActive = GlobalMap.activeInHierarchy; //If one map is active, method deactivates it and activates another
            GlobalMap.SetActive(!globalActive);
            LocalMap.SetActive(globalActive);
        }
    }
}