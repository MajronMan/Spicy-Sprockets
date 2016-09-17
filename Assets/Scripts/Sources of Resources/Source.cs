using Assets.Scripts.Resources;
using UnityEngine;

namespace Assets.Scripts.Sources_of_Resources
{
    public abstract class Source : MonoBehaviour
    {
        protected float Radius;
        protected Resource Resource;

        public float RecourceQuantity(float distance)
        {
            float res;
            if (distance > Radius) res = 0;
            else res = Radius*Radius - distance*distance;
            return res;
        }
    }
}
