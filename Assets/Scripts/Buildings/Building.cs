using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public abstract class Building : MonoBehaviour
{
    protected List<Resource> cost;
    public Sprite mySprite;
    protected Color myColor;
    protected BuildingSize mySize;

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = mySprite;
    }
}
