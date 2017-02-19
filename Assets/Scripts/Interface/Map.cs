using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.ResourcePools;
using Assets.Scripts.Utils;
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

        /// <inheritdoc cref="Grid.Snap"/>
        public Vector3 Snap(Vector3 position) {
            return _grid.Snap(position);
        }

        /// <inheritdoc cref="Grid.SnapMouse"/>
        public Vector3 SnapMouse() {
            return _grid.SnapMouse();
        }

        /// <inheritdoc cref="Grid.WorldToGrid"/>
        public IntVector2 WorldToGrid(Vector3 position) {
            return _grid.WorldToGrid(position);
        }

        /// <inheritdoc cref="Grid.GridToWorld(int,int)"/>
        public Vector3 GridToWorld(int i, int j) {
            return _grid.GridToWorld(i, j);
        }

        /// <inheritdoc cref="Grid.GridToWorld(IntVector2)"/>
        public Vector3 GridToWorld(IntVector2 index) {
            return _grid.GridToWorld(index);
        }

        public void DrawGrid() {
            _grid = Instantiate(Prefabs.Grid, transform).GetComponent<Grid>();

            var cornersWorldSpace = GetComponent<PolygonCollider2D>()
                .points.Select(p => transform.TransformPoint(p))
                .Select(p => new Vector3(p.x, p.y))
                .ToArray();

            _grid.Draw(cornersWorldSpace, SideTiles);
        }

        public bool ToggleGrid() {
            return _grid.ToggleVisibility();
        }

        public void DisableGrid()
        {
            _grid.gameObject.SetActive(false);
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
    }
}