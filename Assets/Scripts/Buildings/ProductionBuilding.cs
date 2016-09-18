using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class ProductionBuilding : Building
    {
        public new void Start()
        {
            MyColor = new Color(0.5f, 0.2f, 0.25f);
            SpriteRenderer myRenderer = gameObject.GetComponent<SpriteRenderer>();
            myRenderer.sprite = MySprite;
            myRenderer.color = MyColor;
            myRenderer.sortingOrder = 1;
        }
    }
}
