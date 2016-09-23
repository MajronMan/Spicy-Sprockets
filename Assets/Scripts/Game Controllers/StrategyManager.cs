using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class StrategyManager : MonoBehaviour {
    public Map mapPrefab;
    private Map mapInstance=null;
    public BuildingManager buildingManagerPrefab;
    private BuildingManager buildingManagerInstance=null;
    private GameMode gameMode;
	private static string dataPath = string.Empty;

   
    private void Start()
    {
        BeginGame();
		dataPath = System.IO.Path.Combine(Application.dataPath, "Resources/Data.xml");
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

	public void Save(){
//		SaveData.Save
		SaveData.ClearBuildings();
		for (int i = 0; i < buildingManagerInstance.Built.Count; i++) {
			SaveData.AddBuildingData (buildingManagerInstance.Built [i]);
			gameMode=new BuildingMode(this, buildingManagerInstance);
		}
		SaveData.Save(dataPath, SaveData.buildingContainer);
//		SaveData.Save(dataPath, SaveData.actorContainer); 
//		Debug.Log (buildingManagerInstance.Built.Count);

	}

	public void Load(){

		SaveData.Load(dataPath);
		for (int i = 0; i < SaveData.buildingContainer.bulidings.Count; i++) {
			Debug.Log (SaveData.buildingContainer.bulidings[i].posX);
			Building toBeBuiltPrefab;
			toBeBuiltPrefab = this.buildingManagerInstance.TMPBuildingPrefab;
			buildingManagerInstance.Build(toBeBuiltPrefab, new Vector3(SaveData.buildingContainer.bulidings[i].posX, SaveData.buildingContainer.bulidings[i].posY, SaveData.buildingContainer.bulidings[i].posZ));
		}
		SaveData.ClearBuildings();
	}

}
