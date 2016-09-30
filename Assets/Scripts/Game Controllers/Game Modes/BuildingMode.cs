using UnityEngine;
using System.Collections;
using GameControllers;

public class BuildingMode : GameMode
{
    private CityController cityControllerInstance;
	private GameController GameControllerInstance;
    private BuildingManager buildingManagerInstance;
    public System.Type toBeBuiltType;
    private Building preview;

	public BuildingMode(GameController GameControllerInstance, CityController strategyManagerInstance, BuildingManager buildingManagerInstance)
    {
        
        this.cityControllerInstance = strategyManagerInstance;
        this.buildingManagerInstance = buildingManagerInstance;
		this.GameControllerInstance = GameControllerInstance;
        this.toBeBuiltType = typeof(ProductionBuilding);
        setPreview();
    }

    public void RightMouseClicked()
    {
        Exit();
    }

    public void LeftMouseClicked()
    {
        buildingManagerInstance.Build(toBeBuiltType, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
        Exit();
    }

    public void Update()
    {
        if (preview == null) return;
        preview.transform.position= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
    }

    public void setPreview()
    {
        this.preview = buildingManagerInstance.preview(toBeBuiltType);
    }

    public void setToBeBuiltType(System.Type buildingType)
    {
        this.toBeBuiltType = buildingType;
    }
    public void Exit()
    {
<<<<<<< HEAD
        BuildingManager.Destroy(preview);
        GameControllerInstance.enterDefaultMode();
=======
        BuildingManager.Destroy(preview.gameObject);
        strategyManagerInstance.enterDefaultMode();
>>>>>>> develop
    }

    public void Select(GameObject gameObject)
    {
        setToBeBuiltType(gameObject.GetType());
        setPreview();
    }
}
