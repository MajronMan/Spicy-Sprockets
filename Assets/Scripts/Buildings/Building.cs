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
    protected List<Cell> occupiedCells = new List<Cell>();
    protected Cell theChosenCell;

    public void Occupy(List<Cell> cells, IntVector2 size, Cell chosenOne)
    {
        mySize = (BuildingSize)Math.Abs(size.x)+1;
        occupiedCells.AddRange(cells);
        theChosenCell = chosenOne;
        transform.SetParent(chosenOne.transform, false);
        transform.localPosition = new Vector3(size.x/2.0f, size.y/2.0f, 0);
        transform.localScale = new Vector3((float)mySize-0.1f, (float)mySize-0.1f, 1);
    }
}
