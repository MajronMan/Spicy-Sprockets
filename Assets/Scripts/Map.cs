using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    private StrategyManager strategyManager;
    public Cell cellPrefab;
    public Building buildingPrefab;
    private Cell [,] cells;
    public IntVector2 size;
    public Cell chosenOne;
    public void Generate()
    {
        
        cells = new Cell[size.x, size.y];
        for (int i = 0; i < size.x; i++)
            for (int j = 0; j < size.y; j++)
                cells[i, j] = CreateCell(i, j);
    }
    
    private Cell CreateCell(int x, int y)
    {
        Cell newCell = Instantiate < Cell >(cellPrefab);
        newCell.name = x + ", " +y;
        newCell.coords = new IntVector2(x, y);
        newCell.transform.SetParent(transform);
        newCell.transform.localPosition = new Vector3(x, y, 1);
        newCell.map = this;
        return newCell;
    }
    public List<Cell> getOccupiedCells(IntVector2 buildingSize)
    {
        List<Cell> occupied = new List<Cell>();
        int size = Math.Abs(buildingSize.x)+1;
        int right = buildingSize.x < 0? -1:1, up = buildingSize.y < 0? -1:1;
        for(int i=0; i<size; i++)
        {
            for(int j=0; j<size; j++)
            {
                int x = right * i + chosenOne.coords.x;
                int y = up * j + chosenOne.coords.y;
                occupied.Add(cells[x, y]);
            }
        }
        return occupied;
    }

    
    

    // Use this for initialization
    private void Start () {
        //Generate();
        Physics.queriesHitTriggers = true;
        strategyManager = gameObject.transform.parent.GetComponent<StrategyManager>();

    }

    private void OnMouseDown()
    {
        Debug.Log("I was clicked");
        strategyManager.mapClicked();
    }

    public int objectIndex()
    {
        return gameObject.transform.GetSiblingIndex();
    }

    private void Update()
    {
    
    }
}
