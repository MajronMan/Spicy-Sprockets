using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.IO;
using System.Collections.Generic;

public class StrategyManager : MonoBehaviour
{
    public Map mapPrefab;
    private Map mapInstance = null;
    public BuildingManager buildingManagerPrefab;
    private BuildingManager buildingManagerInstance = null;
    private GameMode gameMode;
    public Info info;
    public GameObject buildPanel;

    private void Start()
    {
        BeginGame();
    }

    private void BeginGame()
    {
        gameMode = new DefaultMode();
        mapInstance = Instantiate(mapPrefab, transform.position, transform.rotation) as Map;
        mapInstance.transform.localScale = new Vector3(50, 50, 50);
        mapInstance.transform.SetParent(transform);
        mapInstance.name = "Map Instance";
        buildingManagerInstance = Instantiate(buildingManagerPrefab);
        buildingManagerInstance.transform.SetParent(transform);
        buildingManagerInstance.name = "Building Manager";
        buildingManagerInstance.SetMapInstance(mapInstance);
        buildingManagerInstance.strategyManager = this;
        info = new Info();
        foreach (var res in info.Resources)
        {
            Debug.Log(res.ToString());
        }
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mapInstance.gameObject);
        BeginGame();
    }

    private void Update()
    {
        gameMode.Update();
        if (Input.GetKeyDown(KeyCode.Space))
            RestartGame();
    }


    public BuildingManager GetBuildingManager()
    {
        return buildingManagerInstance;
    }

    public GameMode GetGameMode()
    {
        return gameMode;
    }

    public void enterBuildingMode(Building toBeBuilt)
    {
        for (int i = 0; i < toBeBuilt.cost.Count; i++)
        {
            if (toBeBuilt.cost[i].GetQuantity() > info.Resources[toBeBuilt.cost[i].GetResType()].GetQuantity())
                return;
        }
        buildPanel.SetActive(false);
        gameMode = new BuildingMode(this, buildingManagerInstance);
    }

    public void enterDefaultMode()
    {
        gameMode = new DefaultMode();
    }

    public void UpgradeResourcesValues()
    {
        var data = info.ResourceTypes.Data;
        foreach (var key in data.Keys)
        {
            Resource res = new Resource(key, Int32.Parse(data[key]["initial"]), Quality.Lux, this);
            info.Resources.Add(key, res);
        }
    }
}
