using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class UnbuildableTerrain : MonoBehaviour
    {

        private BoxCollider2D _collider;
        public void Start ()
        {
            gameObject.AddComponent < BoxCollider2D>();
            _collider = gameObject.GetComponent<BoxCollider2D>();
            _collider.size=new Vector2(5,5);
            _collider.isTrigger = false;
        }
    }
}
