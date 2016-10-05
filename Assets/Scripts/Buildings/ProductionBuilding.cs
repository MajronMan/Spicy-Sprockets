using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class ProductionBuilding : Building
{
    
    private int time;
    private int resQuantity;
    private int processTime = 300;
    
    public void Start()
    {
        //TODO: make it more non-coder-friendly and definitely not hard-coded
        //e.g. write just a name of a sprite and hold them all in the same folder
        spriteFilePath = "Assets/Graphics/Buildings/building.png";
        mySprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteFilePath);
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = mySprite;
        renderer.sortingOrder = 1;
        Util.rescale(renderer, 30, 30);
        time = 0;
    }

    void Update()
    {   //coroutine pls
        if (resQuantity != 0)
        {
            time++;
            if (time == processTime)
            {
                time = 0;
                Process();
            }
        }
    }

    private void Process()
    {
        //Resource product;

        resQuantity--;

        /*switch (processedResource)
        {
            case ResourceType.Type.Coal:
                playerResources[playerResources.FindIndex(ironFinder)]++;
                break;
        } */

    }
}
