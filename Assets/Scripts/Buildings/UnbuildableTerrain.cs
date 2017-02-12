using UnityEngine;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// A class that is supposed to prevent building in certain place
    /// </summary>
    public sealed class UnbuildableTerrain : MonoBehaviour {
        private BoxCollider2D _collider;

        public void Start() {
            _collider = gameObject.AddComponent<BoxCollider2D>();
            _collider.size = new Vector2(5, 5);
            _collider.isTrigger = false;
        }
    }
}