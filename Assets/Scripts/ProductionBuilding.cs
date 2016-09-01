using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ProductionBuilding : Building
{
    void Start()
    {
        myColor = new Color(0.5f, 0.2f, 0.25f);
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = mySprite;
        renderer.color = myColor;
    }
}
