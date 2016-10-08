using UnityEngine;
using System.Collections;
using GameControllers;
using Assets.Scripts.Resources;

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
        //CheckIfAffordable();
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
        Vector3 previewPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previewPosition.z = 0;
        preview.transform.position = previewPosition;
        //Debug.Log(preview.transform.position);

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
        BuildingManager.Destroy(preview.gameObject);
        GameControllerInstance.enterDefaultMode();
    }

    public void Select(GameObject gameObject)
    {
        setToBeBuiltType(gameObject.GetType());
        setPreview();
    }

    //public void CheckIfAffordable()
    //{
    //    for (int i = 0; i < ProductionBuilding.GetCount(); i++)
    //    {
    //        string resName = ProductionBuilding.GetCostByIndex(i).GetResType();
    //        if (ProductionBuilding.GetCostByIndex(i).GetQuantity() > buildingManagerInstance.info.Resources[resName].GetQuantity())
    //            Exit();
    //    }
    //}
}
