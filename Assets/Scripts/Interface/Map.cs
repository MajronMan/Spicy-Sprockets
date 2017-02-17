using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.ResourcePools;
using Assets.Static;
using UnityEngine;

namespace Assets.Scripts.Interface {
    /// <summary>
    /// Controls the behaviour of a single map upon which a city is built
    /// </summary>
    public class Map : MonoBehaviour {
        private Grid _grid;

        public int SideTiles { get; set; }

        /// <summary>
        /// All sources present on this map
        /// </summary>
        public List<ResourcePool> Pools = new List<ResourcePool>();

        public void DrawGrid() {
            _grid = Instantiate(Prefabs.Grid, transform).GetComponent<Grid>();

            var cornersWorldSpace = GetComponent<PolygonCollider2D>()
                .points.Select(p => transform.TransformPoint(p))
                .Select(p => new Vector2(p.x, p.y))
                .ToArray();

            _grid.Draw(cornersWorldSpace, SideTiles);
        }

        public bool ToggleGrid() {
            return _grid.ToggleVisibility();
        }

        public void OnMouseDown() {
            //behave properly according to game mode
            if (Input.GetMouseButtonDown(0)) {
                Controllers.CurrentGameMode.LeftMouseClicked();
            }

            if (Input.GetMouseButtonDown(1)) {
                Controllers.CurrentGameMode.RightMouseClicked();
                InterfaceUtils.CreatePopup(this);
            }
        }

        public void OnMouseOver() {
            //just a hook
        }
    }
}