using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class StrategyManager : MonoBehaviour {
    public Map mapPrefab;
    private Map mapInstance=null;
    public BuildingManager buildingManagerPrefab;
    private BuildingManager buildingManagerInstance=null;
    private GameMode gameMode;
	public Info info;
    

    private void Start()
    {
        BeginGame();
    }

    private void BeginGame()
    { 
        gameMode=new DefaultMode();
        mapInstance = Instantiate(mapPrefab, transform.position, transform.rotation) as Map;
        mapInstance.transform.localScale = new Vector3(50, 50, 50);
        mapInstance.transform.SetParent(transform);
        mapInstance.name = "Map Instance";
        buildingManagerInstance = Instantiate(buildingManagerPrefab);
        buildingManagerInstance.transform.SetParent(transform);
        buildingManagerInstance.name = "Building Manager";
        buildingManagerInstance.SetMapInstance(mapInstance);
		info = new Info ();
		foreach (var res in info.Resources) {
			Debug.Log (res.ToString ());
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
        {
            RestartGame();
        }
        
    }

    
    public BuildingManager GetBuildingManager()
    {
        return buildingManagerInstance;
    }

    public GameMode GetGameMode()
    {
        return gameMode;
    }

    public void enterBuildingMode()
    {
        gameMode=new BuildingMode(this, buildingManagerInstance);
    }

    public void enterDefaultMode()
    {
        gameMode=new DefaultMode();
    }
}
