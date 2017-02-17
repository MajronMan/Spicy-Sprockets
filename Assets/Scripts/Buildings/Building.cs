using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// A class that represents all buildings
    /// </summary>
    public abstract class Building : MonoBehaviour {
        /// <summary>
        /// Optional colouring for the sprite
        /// </summary>
        protected Color Color;

        /// <summary>
        /// Scale factor for sprite size
        /// </summary>
        protected BuildingSize Size = BuildingSize.Medium;

        /// <summary>
        /// GetComponent takes too much time
        /// </summary>
        public SpriteRenderer Renderer;

        public int Collides = 0;

        public virtual void Start() {
            SetSprite(GetType());
        }

        /// <summary>
        /// Sets sprite for certain type from global data(loaded from file) as current sprite 
        /// </summary>
        /// <param name="type">Type of building which sprite we want to display (not always matches with current type)</param>
        public void SetSprite(System.Type type) {
            Renderer = gameObject.GetComponent<SpriteRenderer>();
            Renderer.sprite = Controllers.ConstantData.BuildingData[type];
            Renderer.sortingOrder = 1;

            Sprites.Rescale(Renderer, ((int) Size) * 0.2f, ((int) Size) * 0.2f);
        }

        void OnCollisionExit2D() {
            Collides--;
        }

        void OnCollisionEnter2D() {
            Collides++;
        }
    }
}