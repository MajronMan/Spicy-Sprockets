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
    public Info info;
    
    
    public Building Build(System.Type buildingType, Vector3 location)
    {
        BuildingStub stub = GetBuildingStub();
        Building newBuilding = stub.init(buildingType, info);
        Vector3 buildingPosition = Camera.main.ScreenToWorldPoint(location);
        buildingPosition.z = 0;
        newBuilding.transform.position = buildingPosition;
        newBuilding.transform.SetParent(mapInstance.transform, true);
        Destroy(newBuilding.gameObject.GetComponent<BuildingStub>());
        Built.Add(newBuilding);
        return newBuilding;
    }

    public void SetMapInstance(Map MapInstance)
    {
        this.mapInstance = MapInstance;
    }

    public void Start()
    {
        // load that from a xml pls
        availableBuildings.Add("Production Building", typeof(ProductionBuilding));
    }
    
    public Building preview(System.Type buildingType)
    {
        Building res=Build(buildingType, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        res.transform.name = "Building Preview";
        return res;
    }
    
    // I'd like to replace all Instantiate(shittyPrefab) with something like this, it's way easier to test
    private BuildingStub GetBuildingStub()
    {
        //that's pretty much what instantiate does
        var go = new GameObject("Building Stub", typeof(BuildingStub), typeof(SpriteRenderer));
        return go.GetComponent<BuildingStub>();
    }

    public Map GetMapInstance()
    {
        return mapInstance;
    }
}
