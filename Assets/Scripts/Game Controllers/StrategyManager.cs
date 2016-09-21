﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class StrategyManager : MonoBehaviour {
    public Map mapPrefab;
    private Map mapInstance=null;
    public BuildingManager buildingManagerPrefab;
    private BuildingManager buildingManagerInstance=null;

    private void Start()
    {
        BeginGame();
    }

    private void BeginGame()
    {
        mapInstance = Instantiate(mapPrefab, transform.position, transform.rotation) as Map;
        mapInstance.transform.localScale = new Vector3(50, 50, 50);
        mapInstance.transform.SetParent(transform);
        mapInstance.name = "Map Instance";
        buildingManagerInstance = Instantiate(buildingManagerPrefab);
        buildingManagerInstance.transform.SetParent(transform);
        buildingManagerInstance.name = "Building Manager";
        buildingManagerInstance.SetMapInstance(mapInstance);
       
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mapInstance.gameObject);
        BeginGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void mapClicked()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        try
        {
            string val = buildingManagerInstance.getValue();
            buildingManagerInstance.Build(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20), val);
        }
        catch (NullReferenceException e)
        {
        }
    }

    public BuildingManager GetBuildingManager()
    {
        return buildingManagerInstance;
    }

    public void ButtonClicked(string value)
    {
        buildingManagerInstance.setActive(true);
        buildingManagerInstance.setValue(value);
    }

}