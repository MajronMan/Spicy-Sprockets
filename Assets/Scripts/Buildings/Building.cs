using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Resources;

public abstract class Building : MonoBehaviour
{
    public List<Resource> cost;
    public Info info;
    public Sprite mySprite;
    protected Color myColor;
    protected BuildingSize mySize;
    public string spriteFilePath;

    public void Start()
    {
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        cost = new List<Resource>();
        cost.Add(new Resource("coal", 5000, Quality.Lux, info));
        cost.Add(new Resource("metal", 10, Quality.Lux, info));
        cost.Add(new Resource("wood", 25, Quality.Lux, info));
        cost.Add(new Resource("stone", 20, Quality.Lux, info));
    }

    public Resource GetCostByIndex(int index)
    {
        if(index > cost.Count)
        {
            Debug.Log("Given index exceeds list");
            return null;
        }
        return cost[index];
    }

    public int GetCount()
    {
        if(cost != null)
            return cost.Count;
        else
        {
            Debug.Log("Cost is null!");
            return 0;
        }
    }
}
