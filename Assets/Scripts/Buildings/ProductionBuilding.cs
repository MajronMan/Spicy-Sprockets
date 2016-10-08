using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Assets.Scripts.Resources;


public class ProductionBuilding : Building
{
    
    private int time;
    private int resQuantity;
    private int processTime = 300;
    
    public void Start()
    {
        //TODO: make it more non-coder-friendly and definitely not hard-coded
        //e.g. write just a name of a sprite and hold them all in the same folder
        Debug.Log("position= "+transform.position);
        spriteFilePath = "Assets/Graphics/Buildings/building.png";
        mySprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteFilePath);
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = mySprite;
        renderer.sortingOrder = 1;
        Util.rescale(renderer, 30, 30);
        time = 0;
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        cost = new List<Resource>();
        cost.Add(new Resource("coal", 5000, Quality.Lux, info));
        cost.Add(new Resource("metal", 10, Quality.Lux, info));
        cost.Add(new Resource("wood", 25, Quality.Lux, info));
        cost.Add(new Resource("stone", 20, Quality.Lux, info));
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
