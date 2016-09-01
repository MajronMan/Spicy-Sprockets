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
        Build();
    }
    public void SwitchHighlight(bool on = true)
    {
        try
        {
            if (on)
                rend.color = Color.magenta;
            else
                rend.color = Color.cyan;
        }
        catch (NullReferenceException e)
        {
            print(e.Message + " " + coords.x + ", " + coords.y);
            rend = gameObject.GetComponentInChildren<SpriteRenderer>();
        }
    }
    private void Build()
    {
        if (building != null) return;

        building = Instantiate < Building >(map.buildingPrefab);
        building.transform.SetParent(transform, false);
        building.transform.localPosition = Vector3.zero;
    }
}
