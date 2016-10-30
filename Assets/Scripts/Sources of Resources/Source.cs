using System;
using Assets.Scripts.Resources;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Sources_of_Resources
{
    public class Source : MonoBehaviour
    {
        public string MyResource;
        //Colliders are troublesome
        public float Radius;
        public int Magnitude;

        public void Start()
        {
            MyResource = "coal";
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
    }
}
