using Assets.Scripts.Res;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.ResourcePools {
    /// <summary>
    /// A general concept of something which gives resources
    /// </summary>
    public class ResourcePool : MonoBehaviour {
        //todo change initialization, so that fields are read-only
        public ResourceType Resource { get; set; }

        //Colliders are troublesome
        public float Radius { get; private set; }

        /// <summary>
        /// How much of resource it yields
        /// </summary>
        public int Magnitude { get; private set; }

        public void ChangeIntensity(float rad, int mag) {
            Radius = rad;
            Magnitude = mag;
        }

        public void RandomizeIntensity() {
            Radius = 20.0f;
            var mag = 50;
            var r = new Random();
            while (r.Next(2) == 0) {
                Radius *= 2;
                mag *= 2;
            }
            Magnitude = mag;
        }
    }
}