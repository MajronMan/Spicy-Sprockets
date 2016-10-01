using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BuildingManager : MonoBehaviour
{

    public List<Building> Built = new List<Building>();
    private Map mapInstance;
    public Building tentPrefab;
    public BuildingStub buildingStub;
    private StorageBuilding korwo;
	public Dictionary<string, System.Type> availableBuildings = new Dictionary<string, System.Type>();

    
    
    public void Build(System.Type buildingType, Vector3 location)
    {
        BuildingStub stub = GetBuildingStub();
        Building newBuilding = stub.init(buildingType);
        newBuilding.transform.position = Camera.main.ScreenToWorldPoint(location);
        newBuilding.transform.localScale = new Vector3(20, 20, 20);
        newBuilding.transform.SetParent(mapInstance.transform, true);
        Built.Add(newBuilding);
    }
    
    public void SetMapInstance(Map MapInstance)
    {
        this.mapInstance = MapInstance;
    }

    public void Start()
    {
        // load that from an xml pls
        availableBuildings.Add("Production Building", typeof(ProductionBuilding));
    }
    
    public Building preview(System.Type buildingType)
    {
        BuildingStub resStub = GetBuildingStub();
        Building res = resStub.init(buildingType);
        res.transform.localScale = new Vector3(20, 20, 20);
        res.name = "Building Preview";
        res.transform.parent = transform;
        return res;
    }
    
    // I'd like to replace all Instantiate(shittyPrefab) with something like this, it's way easier to test
    private BuildingStub GetBuildingStub()
    {
        var go = new GameObject();
        go.AddComponent<BuildingStub>();
        go.AddComponent<SpriteRenderer>();
        return go.GetComponent<BuildingStub>();
    }

    public Map GetMapInstance()
    {
        return mapInstance;
    }
}
