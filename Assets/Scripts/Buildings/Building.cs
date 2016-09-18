using System.Collections.Generic;
using Assets.Scripts.Resources;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public abstract class Building : MonoBehaviour
    {
        protected List<Resource> Cost;
        public Sprite MySprite;
        protected Color MyColor;
        protected BuildingSize MySize;

        public void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = MySprite;
        }
    }
}
