using Assets.Static;
using UnityEngine;

namespace Assets.Scripts.Interface {
    class Grid : MonoBehaviour {
        private Vector2[] _corners;
        private int _sideTiles;

        public void Draw(Vector2[] corners, int sideTiles) {
            _corners = corners;
            _sideTiles = sideTiles;

            Vector2 bottom = _corners[0];
            Vector2 left = _corners[1];
            Vector2 top = _corners[2];
            Vector2 right = _corners[3];

            float tileFrac = 1.0f / _sideTiles;

            for (int i = 0; i <= sideTiles; ++i) {
                var start = Vector2.Lerp(left, top, i * tileFrac);
                var end = Vector2.Lerp(bottom, right, i * tileFrac);
                DrawLine(start, end);

                start = Vector2.Lerp(left, bottom, i * tileFrac);
                end = Vector2.Lerp(top, right, i * tileFrac);
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

        public bool ToggleVisibility() {
            var newState = !gameObject.activeSelf;
            gameObject.SetActive(newState);
            return newState;
        }
    }
}