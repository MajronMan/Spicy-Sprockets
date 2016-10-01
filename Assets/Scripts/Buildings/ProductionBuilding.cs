using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class ProductionBuilding : Building
{
    //private ResourceType.Type processedResource = ResourceType.Type.Coal;
    private int time;
    private int resQuantity;
    private int processTime = 300;
   // private List<Resource> playerResources;
    //Predicate<Resource> ironFinder = (Resource res) => { return res.name == "Iron"; };

    void Start()
    {
        spriteFilePath = "Assets/Graphics/Buildings/building.png";
        mySprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteFilePath);
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = mySprite;
        renderer.sortingOrder = 1;
        
        //processedResource = res;
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
