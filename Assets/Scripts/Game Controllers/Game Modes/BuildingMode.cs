using UnityEngine;
using System.Collections;

public class BuildingMode : GameMode
{
    private StrategyManager strategyManagerInstance;
    private BuildingManager buildingManagerInstance;
    public Building toBeBuiltPrefab;
    private Building toBeBuilt;
   

    public BuildingMode(StrategyManager strategyManagerInstance, BuildingManager buildingManagerInstance)
    {
        this.strategyManagerInstance = strategyManagerInstance;
        this.buildingManagerInstance = buildingManagerInstance;
        this.toBeBuiltPrefab = this.buildingManagerInstance.buildingPrefab;
        this.buildingManagerInstance.createPreview();
        this.toBeBuilt = this.buildingManagerInstance.preview;

    }

    public void RightMouseClicked()
    {
        Exit();
    }

    public void LeftMouseClicked()
    {
        Debug.Log("Build");
        buildingManagerInstance.Build(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
        Exit();
    }

    public void Update()
    {
        toBeBuilt.transform.position= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
    }

    public void Exit()
    {
        buildingManagerInstance.DestroyPreview();
        strategyManagerInstance.enterDefaultMode();
    }

    
}
