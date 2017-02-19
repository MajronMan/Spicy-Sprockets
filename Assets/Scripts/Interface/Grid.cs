using System;
using Assets.Scripts.Buildings;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;

namespace Assets.Scripts.Interface {
    class Grid : MonoBehaviour {
        // all 4 corners are in worldSpace
        private Vector3 _bottom;
        private Vector3 _left;
        private Vector3 _top;
        private Vector3 _right;

        private int _sideTiles;

        // values used heavily when computing positions on the grid
        private Vector3 _iTileVec;
        private Vector3 _jTileVec;

        private float _iTileLen;
        private float _jTileLen;

        private float _gridSkewFactor;


        private void Init(Vector3[] corners, int sideTiles) {
            _bottom = corners[0];
            _left = corners[1];
            _top = corners[2];
            _right = corners[3];

            _sideTiles = sideTiles;

            _iTileVec = (_bottom - _left) / _sideTiles;
            _jTileVec = (_right - _bottom) / _sideTiles;
            _iTileLen = _iTileVec.magnitude;
            _jTileLen = _jTileVec.magnitude;

            _gridSkewFactor = 1 / Mathf.Tan(Mathf.PI * Vector3.Angle(_iTileVec, _jTileVec) / 180);
        }

        /// <summary>
        /// Initializes and draws grid
        /// </summary>
        /// <param name="corners">4 corners of the border rectangle {bottom, left, top, right}
        /// (see Grid class for details)</param>
        /// <param name="sideTiles">number of tiles on each side of the grid</param>
        public void Draw(Vector3[] corners, int sideTiles) {
            Init(corners, sideTiles);

            float tileFrac = 1.0f / _sideTiles;

            for (int i = 0; i <= sideTiles; ++i) {
                var start = Vector3.Lerp(_left, _top, i * tileFrac);
                var end = Vector3.Lerp(_bottom, _right, i * tileFrac);
                DrawLine(start, end);

                start = Vector3.Lerp(_left, _bottom, i * tileFrac);
                end = Vector3.Lerp(_top, _right, i * tileFrac);
                DrawLine(start, end);
            }
        }

        private void DrawLine(Vector2 start, Vector2 end) {
            var line = Instantiate(Prefabs.GridLine, transform).GetComponent<LineRenderer>();
            line.SetPositions(new[] {
                new Vector3(start.x, start.y),
                new Vector3(end.x, end.y),
            });
        }


        /// <returns>
        /// i / j grid index of the left corner of the cell
        /// in which lies position.
        /// <code>
        /// Directions:
        ///   i \    j /\
        ///     \/     /
        /// </code>
        /// </returns>
        public IntVector2 WorldToGrid(Vector3 position) {
            Vector3 posBase = position - _left;

            int i = FindIndexInDirection(posBase, _iTileVec, _iTileLen);
            int j = FindIndexInDirection(posBase, _jTileVec, _jTileLen);

            return new IntVector2(i, j);
        }

        private int FindIndexInDirection(Vector3 position, Vector3 direction, float directionTileLen) {
            Vector3 orthoProjection = Vector3.Project(position, direction);
            float gridSkewAmendment = (position - orthoProjection).magnitude * _gridSkewFactor;
            return (int) ((orthoProjection.magnitude - gridSkewAmendment) / directionTileLen);
        }

        /// <returns>
        /// Position of the left corner of the cell with index i / j
        /// <code>
        /// Directions:
        ///   i \    j /\
        ///     \/     /
        /// </code>
        /// </returns>
        public Vector3 GridToWorld(int i, int j) {
            return _left + (i * _iTileVec) + (j * _jTileVec);
        }

        /// <returns>
        /// Position of the left corner of the cell with the specified index
        /// <code>
        /// Directions:
        ///   index.X \    index.Y /\
        ///           \/           /
        /// </code>
        /// </returns>
        public Vector3 GridToWorld(IntVector2 index) {
            return GridToWorld(index.X, index.Y);
        }

        /// <summary>
        /// Convenience for GridToWorld(WorldToGrid(pos))
        /// </summary>
        public Vector3 Snap(Vector3 position) {
            return GridToWorld(WorldToGrid(position));
        }

        /// <summary>
        /// Convenience, which takes mouse position pos,
        /// sets pos.z = 0 and calls Snap(pos)
        /// </summary>
        public Vector3 SnapMouse() {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            return Snap(mouse);
        }


        public bool ToggleVisibility() {
            var newState = !gameObject.activeSelf;
            gameObject.SetActive(newState);
            return newState;
        }
    }
}