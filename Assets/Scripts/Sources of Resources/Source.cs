using System;
using Assets.Scripts.Resources;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Sources_of_Resources
{
    /// <summary>
    /// A general concept of something which gives resources
    /// </summary>
    public class Source : MonoBehaviour
    {
        public string MyResource;
        //Colliders are troublesome
        private float Radius;
        /// <summary>
        /// How much of resource it yields
        /// </summary>
        public int Magnitude;

        public void Start()
        {
            Radius = 100.0f; 
            var mag = 500;
            var r = new Random();
            while (r.Next(2) == 0)
            {
                Radius *= 2;
                mag *= 2;
            }
            Magnitude = mag;
        }

        public void ChangeVar(float rad, int mag)
        {
            Radius = rad;
            Magnitude = mag;
        }

        public float GetRadius()
        {
            return Radius;
        }

        public int GetMagnitude()
        {
            return Magnitude;
        }
    }
}
