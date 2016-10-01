using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class CityController : MonoBehaviour {
    private Map mapInstance=null;
    private BuildingManager buildingManagerInstance=null;
	public Info info;

	public void BeginGame(Map mapPrefab, BuildingManager buildingManagerPrefab)
    { 
        mapInstance = Instantiate(mapPrefab, transform.position, transform.rotation) as Map;
        mapInstance.transform.localScale = new Vector3(50, 50, 50);
        mapInstance.transform.SetParent(transform);
        mapInstance.name = "Map Instance";
        var go = new GameObject();
        go.AddComponent<BuildingManager>();
        buildingManagerInstance = go.GetComponent<BuildingManager>();
        buildingManagerInstance.transform.SetParent(transform);
        buildingManagerInstance.name = "Building Manager";
        buildingManagerInstance.SetMapInstance(mapInstance);
		info = new Info ();
    }

    private void Update()
    {
        //gameMode.Update();
		//pretty sure we don't want to check things every frame, but delegate events to change the state
        
    }
		
    public BuildingManager GetBuildingManager()
    {
        return buildingManagerInstance;
    }
}
