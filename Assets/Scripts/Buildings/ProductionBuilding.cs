using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class ProductionBuilding : Building
{
    void Start()
    {
        spriteFilePath = "Assets/Graphics/Buildings/building.png";
        mySprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteFilePath);
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = mySprite;
        renderer.sortingOrder = 1;
        
    }
}
