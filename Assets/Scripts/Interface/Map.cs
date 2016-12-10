using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.ResourcePools;
using UnityEngine;

namespace Assets.Scripts.Interface {
    /// <summary>
    /// Controls the behaviour of a single map upon which a city is built
    /// </summary>
    public class Map : MonoBehaviour {
        /// <summary>
        /// All sources present on this map
        /// </summary>
        public List<ResourcePool> Pools = new List<ResourcePool>();

        public void OnMouseDown() {
            //behave properly according to game mode
            if (Input.GetMouseButtonDown(0)) {
                Controllers.CurrentGameMode.LeftMouseClicked();
            }

            if (Input.GetMouseButtonDown(1)) {
                Controllers.CurrentGameMode.RightMouseClicked();
            }
        }

        public void OnMouseOver() {
            //just a hook
        }
    }
}