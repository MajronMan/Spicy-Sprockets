using UnityEngine;
using System.Collections;
using System;

public class Cell : MonoBehaviour {
    public IntVector2 coords;
    private SpriteRenderer rend;
    public BoxCollider col;
    public Building building;
    public Map map;
  
    void Start()
    {
        rend = gameObject.GetComponentInChildren<SpriteRenderer>();
        col = gameObject.GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        SwitchHighlight();
    }
    void OnMouseExit()
    {
        SwitchHighlight(false);
    }
    
    void OnMouseDown()
    {
        if (building != null) return;

        if (map.chosenOne != null)
            Build();
        else
            map.chosenOne = this;
    }
    
    public void SwitchHighlight(bool on = true)
    {
        try
        {
            if (on)
                rend.color = Color.magenta;
            else
                rend.color = Color.white;
        }
        catch (NullReferenceException e)
        {
            print(e.Message + " " + coords.x + ", " + coords.y);
            rend = gameObject.GetComponentInChildren<SpriteRenderer>();
        }
    }
    private IntVector2 getSize(Cell another)
    {
        int x = coords.x - another.coords.x;
        int y = coords.y - another.coords.y;
        int size = Math.Min(Math.Abs(x), Math.Abs(y));
        size = Math.Min((int)BuildingSize.Big, size);
        return new IntVector2(Math.Sign(x) * size, Math.Sign(y) * size);
    }
    private void Build()
    {
        IntVector2 buildingSize = getSize(map.chosenOne);
        building = Instantiate < Building >(map.buildingPrefab);
        building.Occupy(map.getOccupiedCells(buildingSize), buildingSize, map.chosenOne);
        map.chosenOne = null;
    }
}
