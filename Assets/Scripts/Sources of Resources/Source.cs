using System;
using Assets.Scripts.Resources;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Sources_of_Resources
{
    public class Source : MonoBehaviour
    {
        public float Radius;
        public Resource Resource;
        //well, maybe just calculate it, there won't be like 10^6 sources anyway
        protected CircleCollider2D Circle;

        public void Start()
        {
            float r0 = 25.0f;
            var r = new Random();
            while (r.Next(2) == 0)
                r0 *= 2;
            Radius = r0;
        }

        public float GatheringSpeed(float distance)
        {
            float speed;
            try
            {
                speed = 1/(distance+5);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                speed = 0;
            }
            return speed;
        }
    }
}
