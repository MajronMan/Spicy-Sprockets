using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Resources;



public abstract class Building : MonoBehaviour
{
    public List<Resource> cost = new List<Resource>();
    public Sprite mySprite;
    protected Color myColor;
    protected BuildingSize mySize;
    public string spriteFilePath;
    public Info info;

    private void Start()
    {
        //all buildings have th same cost for now, it will be changed later
        cost.Add(new Resource("coal", 5000, Quality.Lux, info));
        cost.Add(new Resource("metal", 10, Quality.Lux, info));
        cost.Add(new Resource("wood", 25, Quality.Lux, info));
        cost.Add(new Resource("stone", 20, Quality.Lux, info));
    }
}
