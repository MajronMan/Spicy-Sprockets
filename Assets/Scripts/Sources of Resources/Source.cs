using Assets.Scripts.Resources;
using UnityEngine;

namespace Assets.Scripts.Sources_of_Resources
{
<<<<<<< HEAD
    protected float radius;
    protected Resource resource;
    protected CircleCollider2D circle;

    public float recourceQuantity(float distance)
=======
    public abstract class Source : MonoBehaviour
>>>>>>> 6439ced2bb87cf113209892fd0cf0b70a62c90b6
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
<<<<<<< HEAD

	protected virtual void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}
=======
>>>>>>> 6439ced2bb87cf113209892fd0cf0b70a62c90b6
}
