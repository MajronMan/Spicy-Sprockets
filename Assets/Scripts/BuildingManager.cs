﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class BuildingManager : MonoBehaviour
{

    private List<Building> Built;
    private Map mapInstance;
    public Building buildingPrefab;
    public bool active;

    public void Build(Vector3 location)
    {
        Building newBuilding = Instantiate(buildingPrefab);
        newBuilding.transform.position = Camera.main.ScreenToWorldPoint(location);
        newBuilding.transform.localScale=new Vector3(20,20,20);
        newBuilding.transform.SetParent(mapInstance.transform, true);



    }

    public void SetMapInstance(Map MapInstance)
    {
        this.mapInstance = MapInstance;
    }

    public void setActive(bool active)
    {
        this.active = active;
    }

    public bool getActive()
    {
        return active;
    }
}
