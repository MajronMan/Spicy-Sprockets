using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Resources;
using Assets.Scripts.Utils;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Buildings
{
    public abstract class Building : MonoBehaviour
    {
        protected Color MyColor;
        protected BuildingSize MySize = BuildingSize.Medium;
        public SpriteRenderer MyRenderer;
        public bool Collides = false;
        public virtual void Start()
        {
            SetSprite(GetType());
        }

        public void SetSprite(System.Type type)
        {
            MyRenderer = gameObject.GetComponent<SpriteRenderer>();
            MyRenderer.sprite = Controllers.ConstantData.BuildingData[type];
            MyRenderer.sortingOrder = 1;
            Util.Rescale(MyRenderer, (int)MySize * 20, (int)MySize * 20);
        }

        void OnCollisionExit2D()
        {
            Collides = false;
        }
        
        void OnCollisionStay2D()
        {   
            Collides = true;
        }
        
    }   
}
