using Assets.Scripts.Res;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.ResourcePools {
    /// <summary>
    /// A general concept of something which gives resources
    /// </summary>
    public class ResourcePool : MonoBehaviour {
        public ResourceType Type;
        //Colliders are troublesome
        public float Radius;

        /// <summary>
        /// How much of resource it yields
        /// </summary>
        public int Magnitude;

        public void Start() {
            Radius = 100.0f;
            var mag = 500;
            var r = new Random();
            while (r.Next(2) == 0) {
                Radius *= 2;
                mag *= 2;
            }
            Magnitude = mag;
        }
    }
}