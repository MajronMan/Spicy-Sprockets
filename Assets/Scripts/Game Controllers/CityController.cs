using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class CityController : MonoBehaviour {
    private Map mapInstance=null;
    private BuildingManager buildingManagerInstance=null;
	public Info info;

	public void BeginGame(Map mapPrefab)
    { 
        mapInstance = Instantiate(mapPrefab, transform.position, transform.rotation) as Map;
        mapInstance.transform.localScale = new Vector3(100, 100, 100);
        mapInstance.transform.SetParent(transform);
        mapInstance.name = "Map Instance";
        var newGameObject = new GameObject("Building Manager", typeof(BuildingManager));
        buildingManagerInstance = newGameObject.GetComponent<BuildingManager>();
        buildingManagerInstance.transform.SetParent(transform);
        buildingManagerInstance.name = "Building Manager";
        buildingManagerInstance.SetMapInstance(mapInstance);
        buildingManagerInstance.info = info;
        info = new Info ();
        
    }

    private void Update()
    {
        
    }
		
    public BuildingManager GetBuildingManager()
    {
        return buildingManagerInstance;
    }
}
