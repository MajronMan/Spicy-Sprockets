using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BuildingManager : MonoBehaviour
{

    public List<Building> Built;
    private Map mapInstance;
    public Building tentPrefab;
    public BuildingStub buildingStub;
    private StorageBuilding korwo;
	public Dictionary<string, System.Type> availableBuildings = new Dictionary<string, System.Type>();
    public StrategyManager strategyManager;
    
    
    public void Build(System.Type buildingType, Vector3 location)
    {
        BuildingStub stub = Instantiate(buildingStub);
        Building newBuilding = stub.init(buildingType);
        newBuilding.transform.position = Camera.main.ScreenToWorldPoint(location);
        newBuilding.transform.localScale = new Vector3(20, 20, 20);
        newBuilding.transform.SetParent(mapInstance.transform, true);
        newBuilding.info = this.strategyManager.info;
        Destroy(stub);
        Built.Add(newBuilding);
        for (int i = 0; i < newBuilding.cost.Count; i++)
            strategyManager.info.Resources[newBuilding.cost[i].GetResType()] = strategyManager.info.Resources[newBuilding.cost[i].GetResType()] - newBuilding.cost[0];
        strategyManager.UpgradeResourcesValues();
    }
    
    public void SetMapInstance(Map MapInstance)
    {
        this.mapInstance = MapInstance;
    }

    void Start()
    {
        Built=new List<Building>();
        availableBuildings=new Dictionary<string, Type>();
        availableBuildings.Add("Production Building", typeof(ProductionBuilding));
    }

	// Update is called once per frame
	void Update () {
	
	}
    
    public Building preview(System.Type buildingType)
    {
        BuildingStub resStub = Instantiate(buildingStub);
        Building res = resStub.init(buildingType);
        res.transform.localScale = new Vector3(20, 20, 20);
        res.name = "Building Preview";
        res.transform.parent = transform;
        Destroy(resStub);
        return res;
    }

    /*
    public void Build(Building buildingPrefab, Vector3 location)
    {
        Building newBuilding = Instantiate(buildingPrefab);
        newBuilding.transform.position = Camera.main.ScreenToWorldPoint(location);
        newBuilding.transform.localScale = new Vector3(20, 20, 20);
        newBuilding.transform.SetParent(mapInstance.transform, true);
        this.active = false;
    }
    */

}
