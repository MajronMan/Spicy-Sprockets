using UnityEngine;
using System.Collections;

public class BuildingMode : GameMode
{
    private StrategyManager strategyManagerInstance;
    private BuildingManager buildingManagerInstance;
    public Building toBeBuiltPrefab;
   

    public BuildingMode(StrategyManager strategyManagerInstance, BuildingManager buildingManagerInstance)
    {
        this.strategyManagerInstance = strategyManagerInstance;
        this.buildingManagerInstance = buildingManagerInstance;
        this.toBeBuiltPrefab = this.buildingManagerInstance.TMPBuildingPrefab;
        this.buildingManagerInstance.createPreview(toBeBuiltPrefab);
        
    }

    public void RightMouseClicked()
    {
        Exit();
    }

    public void LeftMouseClicked()
    {
        buildingManagerInstance.Build(toBeBuiltPrefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
        
        Exit();
    }

    public void Update()
    {
        buildingManagerInstance.preview.transform.position= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
    }

    public void Exit()
    {
        buildingManagerInstance.DestroyPreview();
        strategyManagerInstance.enterDefaultMode();
    }

    public void setToBeBuiltPrefab(Building buildingPrefab)
    {
        this.toBeBuiltPrefab = buildingPrefab;
    }

    
}
