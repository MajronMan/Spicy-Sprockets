using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Resources;



public abstract class Building : MonoBehaviour
{
    protected List<Resource> cost;
    public Sprite mySprite;
    protected Color myColor;
    protected BuildingSize mySize;
    public string spriteFilePath;
    public Info info;
}
